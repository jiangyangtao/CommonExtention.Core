using System;
using System.Collections.Generic;
using System.Text;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// Twitter 分布式雪花算法。此类不可被继承
    /// </summary>
    public sealed class Snowflake
    {
        private static long MachineId;//机器ID
        private static long DatacenterId = 0L;//数据ID
        private static long Sequence = 0L;//计数从零开始
        private static readonly long twepoch = 687888001020L; //唯一时间随机量
        private static readonly long MachineIdBits = 5L; //机器码字节数
        private static readonly long DatacenterIdBits = 5L;//数据字节数        
        private static readonly long MaxDatacenterId = -1L ^ (-1L << (int)DatacenterIdBits);//最大数据ID
        private static readonly long SequenceBits = 12L; //计数器字节数，12个字节用来保存计数码        
        private static readonly long MachineIdShift = SequenceBits; //机器码数据左移位数，就是后面计数器占用的位数
        private static readonly long DatacenterIdShift = SequenceBits + MachineIdBits;
        private static readonly long TimestampLeftShift = SequenceBits + MachineIdBits + DatacenterIdBits; //时间戳左移动位数就是机器码+计数器总字节数+数据字节数        
        private static long LastTimestamp = -1L;//最后时间戳
        private static readonly object SyncRoot = new object();//加锁对象

        static Snowflake snowflake;

        /// <summary>
        /// 
        /// </summary>
        public static long maxMachineId = -1L ^ -1L << (int)MachineIdBits; //最大机器ID

        /// <summary>
        /// 
        /// </summary>
        public static long sequenceMask = -1L ^ -1L << (int)SequenceBits; //一微秒内可以产生计数，如果达到该值则等到下一微妙在进行生成

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Snowflake Instance()
        {
            if (snowflake == null)
                snowflake = new Snowflake();
            return snowflake;
        }

        /// <summary>
        /// 
        /// </summary>
        public Snowflake()
        {
            Snowflakes(0L, -1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="machineId"></param>
        public Snowflake(long machineId)
        {
            Snowflakes(machineId, -1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="machineId"></param>
        /// <param name="datacenterId"></param>
        public Snowflake(long machineId, long datacenterId)
        {
            Snowflakes(machineId, datacenterId);
        }

        private void Snowflakes(long machineId, long datacenterId)
        {
            if (machineId >= 0)
            {
                if (machineId > maxMachineId)
                {
                    throw new Exception("机器码ID非法");
                }
                Snowflake.MachineId = machineId;
            }
            if (datacenterId >= 0)
            {
                if (datacenterId > MaxDatacenterId)
                {
                    throw new Exception("数据中心ID非法");
                }
                Snowflake.DatacenterId = datacenterId;
            }
        }

        /// <summary>
        /// 生成当前时间戳
        /// </summary>
        /// <returns>毫秒</returns>
        private static long GetTimestamp() => (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;


        /// <summary>
        /// 获取下一微秒时间戳
        /// </summary>
        /// <param name="lastTimestamp"></param>
        /// <returns></returns>
        private static long GetNextTimestamp(long lastTimestamp)
        {
            long timestamp = GetTimestamp();
            if (timestamp <= lastTimestamp)
            {
                timestamp = GetTimestamp();
            }
            return timestamp;
        }

        /// <summary>
        /// 获取长整形的ID
        /// </summary>
        /// <returns></returns>
        public long GetId()
        {
            lock (SyncRoot)
            {
                long timestamp = GetTimestamp();
                if (Snowflake.LastTimestamp == timestamp)
                { //同一微妙中生成ID
                    Sequence = (Sequence + 1) & sequenceMask; //用&运算计算该微秒内产生的计数是否已经到达上限
                    if (Sequence == 0)
                    {
                        //一微妙内产生的ID计数已达上限，等待下一微妙
                        timestamp = GetNextTimestamp(Snowflake.LastTimestamp);
                    }
                }
                else
                {
                    //不同微秒生成ID
                    Sequence = 0L;
                }
                if (timestamp < LastTimestamp)
                {
                    throw new Exception("时间戳比上一次生成ID时时间戳还小，故异常");
                }
                Snowflake.LastTimestamp = timestamp; //把当前时间戳保存为最后生成ID的时间戳
                long Id = ((timestamp - twepoch) << (int)TimestampLeftShift)
                    | (DatacenterId << (int)DatacenterIdShift)
                    | (MachineId << (int)MachineIdShift)
                    | Sequence;
                return Id;
            }
        }
    }
}
