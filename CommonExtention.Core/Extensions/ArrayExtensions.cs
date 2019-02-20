using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;

namespace CommonExtention.Core.Extensions
{
    /// <summary>
    /// <see cref="Array"/> 扩展
    /// </summary>
    public static class ArrayExtensions
    {
        #region 将一种将当前数组转换为另一种类型的数组
        /// <summary>
        /// 将一种将当前数组转换为另一种类型的数组
        /// </summary>
        /// <typeparam name="TInput">源数组元素的类型</typeparam>
        /// <typeparam name="TOutput">目标数组元素的类型</typeparam>
        /// <param name="TArray">要转换为目标类型的从零开始的一维 <see cref="Array"/></param>
        /// <param name="converter">用于将每个元素从一种类型转换为另一种类型</param>
        /// <returns>目标类型的数组，包含从源数组转换而来的元素</returns>
        public static TOutput[] ConvertAll<TInput, TOutput>(this TInput[] TArray, Converter<TInput, TOutput> converter) => Array.ConvertAll(TArray, converter);
        #endregion

        #region 将当前数组转换为 string[]
        /// <summary>
        /// 将当前数组转换为 <see cref="string"/><see cref="Array"/>
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="TArray">要转换的数组</param>
        /// <returns><see cref="string"/><see cref="Array"/></returns>
        public static string[] ToStringArray<T>(this T[] TArray)
        {
            if (TArray == null || TArray.Length <= 0) return null;

            return Array.ConvertAll(TArray, a => a.ToString());
        }
        #endregion

        #region 将当前 System.String 转换为 string[]
        /// <summary>
        /// 将当前 <see cref="string"/> 转换为 <see cref="string"/><see cref="Array"/>
        /// </summary>
        /// <param name="value"><see cref="string"/></param>
        /// <param name="symbol">分隔符，默认为英文逗号</param>
        /// <returns><see cref="string"/><see cref="Array"/></returns>
        public static string[] ToSplitArray(this string value, char symbol = ',')
        {
            if (value.IsNullOrEmpty()) return null;
            return value.Split(symbol);
        }
        #endregion

        #region 将当前数组转化为 System.String 表示形式
        /// <summary>
        /// 将当前数组转化为 <see cref="string"/> 表示形式
        /// </summary>
        /// <typeparam name="T">数组类型的元素</typeparam>
        /// <param name="Tarry">要转换的数组</param>
        /// <param name="symbol">分隔符号,默认英文逗号分隔</param>
        /// <returns>英文逗号分隔的 <see cref="string"/></returns>
        public static string ToStringValue<T>(this T[] Tarry, string symbol = ",")
        {
            var str = string.Empty;
            if (Tarry == null || Tarry.Length == 0) return str;
            for (int i = 0; i < Tarry.Length; i++)
            {
                var item = Tarry[i];
                if (item != null)
                {
                    str += Tarry[i];
                    if (i != Tarry.Length - 1) str += symbol;
                }
            }
            return str;
        }
        #endregion

        #region 统计与条件相匹配的元素在序列中出现过的次数
        /// <summary>
        /// 统计与条件相匹配的元素在序列中出现过的次数
        /// </summary>
        /// <typeparam name="T">数组类型的元素</typeparam>
        /// <param name="Tarray">要搜索的数组</param>
        /// <param name="value">要搜索的元素</param>
        /// <returns>与条件相匹配的元素在数组序列中出现过的次数</returns>
        public static int CountIndex<T>(this T[] Tarray, T value)
        {
            if (Tarray == null || Tarray.Length <= 0) return -1;
            if (!Tarray.Exists(value)) return 0;

            var count = 0;
            for (int i = 0; i < Tarray.Length; i++)
            {
                if (Tarray[i].Equals(value)) count++;
            }
            return count;
        }
        #endregion

        #region 统计与条件相匹配和包含的元素在 string[] 序列中出现过的次数
        /// <summary>
        /// 统计与条件相匹配和包含的元素在<see cref="string"/><see cref="Array"/>中出现过的次数
        /// </summary>
        /// <param name="stringArray"><see cref="string"/><see cref="Array"/></param>
        /// <param name="value">要搜索的条件</param>
        /// <returns>与条件相匹配的元素在<see cref="string"/><see cref="Array"/>序列中出现过的次数</returns>
        public static int CountContainIndex(this string[] stringArray, string value)
        {
            if (!stringArray.Exists(value)) return 0;
            var count = 0;
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (stringArray[i].Contains(value)) count++;
            }
            return count;
        }
        #endregion

        #region 寻找与条件相匹配的元素，并返回整个序列中第一个匹配元素的从零开始的索引
        /// <summary>
        /// 寻找与条件相匹配的元素，并返回整个序列中第一个匹配元素的从零开始的索引
        /// </summary>
        /// <typeparam name="T">数组类型的元素</typeparam>
        /// <param name="Tarray">要搜索的数组</param>
        /// <param name="value">与条件相匹配的元素</param>
        /// <returns>序列中第一个匹配元素的从零开始的索引</returns>
        public static int FindIndex<T>(this T[] Tarray, T value)
        {
            if (Tarray.Length == 0) return -1;
            if (!Tarray.Exists(value)) return -1;

            return Tarray.FindIndex((item) => item.Equals(value));
        }
        #endregion

        #region 寻找与条件相匹配的元素，并返回整个序列中第一个匹配元素的从结尾开始的索引
        /// <summary>
        /// 寻找与条件相匹配的元素，并返回整个序列中第一个匹配元素的从结尾开始的索引
        /// </summary>
        /// <typeparam name="T">数组类型的元素</typeparam>
        /// <param name="Tarray">要搜索的数组</param>
        /// <param name="value">与条件相匹配的元素</param>
        /// <returns>序列中第一个匹配元素的从结尾开始的索引</returns>
        public static int FindLastIndex<T>(this T[] Tarray, T value)
        {
            if (Tarray.Length == 0) return -1;
            if (!Tarray.Exists(value)) return -1;
            return Tarray.FindLastIndex(item => item.Equals(value));
        }
        #endregion        

        #region 寻找与条件相匹配的元素，并返回整个序列中的每一个匹配元素的索引
        /// <summary>
        /// 寻找与条件相匹配的元素，并返回整个序列中的每一个匹配元素的索引
        /// </summary>
        /// <typeparam name="T">数组类型的元素</typeparam>
        /// <param name="Tarray">要搜索的数组</param>
        /// <param name="value">要搜索的条件</param>
        /// <returns>序列中的每一个匹配元素的索引</returns>
        public static int[] FindAllIndex<T>(this T[] Tarray, T value)
        {
            if (!Tarray.Exists(value)) return new int[0];
            var str = string.Empty;
            if (Tarray.Length == 0) return new int[0];
            for (int i = 0; i < Tarray.Length; i++)
            {
                if (Tarray[i].Equals(value))
                {
                    str += i;
                    if (i != Tarray.Length - 1) str += ",";
                }
            }
            return str.ToSplitArray().ConvertAll(a => a.ToInt());
        }
        #endregion

        #region 对当前 System.Array 的每个元素执行指定操作
        /// <summary>
        /// 对当前 <see cref="Array"/> 的每个元素执行指定操作
        /// </summary>
        /// <typeparam name="T">源数组元素的类型</typeparam>
        /// <param name="Tarray">源数组</param>
        /// <param name="action">要对 <see cref="Array"/> 的每个元素执行的 <see cref="Action"/> 委托</param>
        public static void ForEach<T>(this T[] Tarray, Action<T> action) => Array.ForEach(Tarray, action);

        #endregion

        #region 对当前 System.Array 的每个元素执行指定操作
        /// <summary>
        /// 对当前 <see cref="Array"/> 的每个元素执行指定操作
        /// </summary>
        /// <typeparam name="T">源数组元素的类型</typeparam>
        /// <param name="Tarray">源数组</param>
        /// <param name="action">要对 <see cref="Array"/> 的每个元素执行的 <see cref="Action"/> 委托</param>
        public static void ForEach<T>(this T[] Tarray, Action<T, int> action)
        {
            for (int i = 0; i < Tarray.Length; i++)
            {
                action(Tarray[i], i);
            }
        }
        #endregion

        #region 确定指定数组包含的元素是否与指定谓词定义的条件匹配
        /// <summary>
        /// 确定指定数组包含的元素是否与指定谓词定义的条件匹配
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="TArray">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="value">搜索的元素的条件</param>
        /// <returns>如果 array 包含一个或多个元素与指定谓词定义的条件匹配，则为 true；否则为 false</returns>
        public static bool Exists<T>(this T[] TArray, T value) => Array.Exists<T>(TArray, (item) => item.Equals(value));
        #endregion

        #region 确定指定数组包含的元素是否与指定谓词定义的条件匹配
        /// <summary>
        /// 确定指定数组包含的元素是否与指定谓词定义的条件匹配
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="TArray">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="match"><see cref="Predicate{T}"/>，定义要搜索的元素的条件</param>
        /// <returns>如果 array 包含一个或多个元素与指定谓词定义的条件匹配，则为 true；否则为 false</returns>
        public static bool Exists<T>(this T[] TArray, Predicate<T> match) => Array.Exists<T>(TArray, match);
        #endregion

        #region 在序列的起始处插入指定的元素，并返回一个新的数组
        /// <summary>
        /// 在序列的起始处插入指定的元素，并返回一个新的数组
        /// </summary>
        /// <typeparam name="T">数组类型的元素</typeparam>
        /// <param name="TArray">要插入的从零开始的一维 <see cref="Array"/></param>
        /// <param name="value">要插入的元素</param>
        /// <returns>插入元素后的新数组</returns>
        public static T[] Insert<T>(this T[] TArray, T value)
        {
            var _arr = new T[TArray.Length + 1];
            _arr[0] = value;
            for (int i = 1; i < TArray.Length; i++)
            {
                _arr[i] = TArray[i - 1];
            }
            return _arr;
        }
        #endregion

        #region 在序列的结尾处插入指定的元素，并返回一个新的数组
        /// <summary>
        /// 在序列的结尾处插入指定的元素，并返回一个新的数组
        /// </summary>
        /// <typeparam name="T">数组类型的元素</typeparam>
        /// <param name="TArray">要插入的从零开始的一维 <see cref="Array"/></param>
        /// <param name="value">要插入的元素</param>
        /// <returns>插入元素后的新数组</returns>
        public static T[] Add<T>(this T[] TArray, T value)
        {
            var _arr = new T[TArray.Length + 1];
            for (int i = 0; i < TArray.Length; i++)
            {
                _arr[i] = TArray[i];
            }
            _arr[TArray.Length] = value;
            return _arr;
        }
        #endregion

        #region 移除与条件相匹配的所有元素，并返回一个新的数组
        /// <summary>
        /// 移除与条件相匹配的所有元素，并返回一个新的数组
        /// </summary>
        /// <typeparam name="T">数组类型的元素</typeparam>
        /// <param name="TArray">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="value">移除的元素的条件</param>
        /// <returns>不包含搜索条件的元素的新数组</returns>
        public static T[] Remove<T>(this T[] TArray, T value) => Array.FindAll(TArray, (item) => !item.Equals(value));

        #endregion

        #region 移除序列中的指定索引的元素，并返回一个新的数组
        /// <summary>
        /// 移除序列中的指定索引的元素，并返回一个新的序列
        /// </summary>
        /// <typeparam name="T">数组类型的元素</typeparam>
        /// <param name="TArray">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="index">要移除的元素的索引</param>
        /// <returns>移除了指定索引元素的新数组</returns>
        public static T[] RemoveAt<T>(this T[] TArray, int index)
        {
            if (index < 0 || index > TArray.Length - 1) return new T[0];

            var newArray = new T[TArray.Length - 1];
            var _index = 0;
            for (int i = 0; i < TArray.Length; i++)
            {
                if (i != index) newArray[_index++] = TArray[i];
            }
            return newArray;
        }
        #endregion

        #region 移除序列中的指定索引之后元素，并返回一个新的序列
        /// <summary>
        /// 移除序列中的指定索引之后元素，并返回一个新的序列
        /// </summary>
        /// <typeparam name="T">数组类型的元素</typeparam>
        /// <param name="TArray">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="startIndex">指定的索引</param>
        /// <returns>移除了指定索引之后元素的新数组</returns>
        /// <exception cref="IndexOutOfRangeException">startIndex 参数小于 0 或者大于或者等于 TArray 的长度时</exception>
        public static T[] RemoveRange<T>(this T[] TArray, int startIndex)
        {
            if (startIndex < 0 || startIndex >= TArray.Length) throw new IndexOutOfRangeException("指定的索引超出了数组界限。");

            var newArray = new T[TArray.Length - startIndex];
            for (int i = 0; i < startIndex; i++)
            {
                newArray[i] = TArray[i];
            }
            return newArray;
        }
        #endregion

        #region 移除序列中指定的索引处一定范围的元素，并返回一个新的数组
        /// <summary>
        /// 移除序列中指定的索引处一定范围的元素，并返回一个新的数组
        /// </summary>
        /// <typeparam name="T">数组类型的元素</typeparam>
        /// <param name="TArray">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="startIndex">要移除的元素的范围从零开始的起始索引</param>
        /// <param name="length">要移除的元素数</param>
        /// <returns>移除了指定范围元素的新数组</returns>
        /// <exception cref="IndexOutOfRangeException">startIndex 参数小于 0 或者大于或者等于 TArray 的长度时</exception>
        /// <exception cref="IndexOutOfRangeException">startIndex 参数加上 length 参数的和大于或者等于 TArray 的长度时</exception>
        public static T[] RemoveRange<T>(this T[] TArray, int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= TArray.Length) throw new IndexOutOfRangeException("指定的索引超出了数组界限。");
            if ((startIndex + length) >= TArray.Length) throw new IndexOutOfRangeException("指定索引处的范围超出了数组界限。");
            var _arr = new T[TArray.Length - length];
            var j = 0;
            for (int i = 0; i < TArray.Length; i++)
            {
                if (i >= startIndex && i < (startIndex + length)) continue;
                _arr[j++] = TArray[i];
            }
            return _arr;
        }
        #endregion

        #region 返回指定数组的只读包装
        /// <summary>
        /// 返回指定数组的只读包装
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要包装在只读 <see cref="ReadOnlyCollection{T}"/> 包装中的从零开始的一维数组</param>
        /// <returns>指定数组的只读 <see cref="ReadOnlyCollection{T}"/> 包装</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this T[] array) => Array.AsReadOnly(array);
        #endregion

        #region 使用指定的 System.Collections.IComparer，在整个一维排序 System.Array 中搜索值
        /// <summary>
        /// 使用指定的 <see cref="IComparer"/> 接口，在整个一维排序 <see cref="Array"/> 中搜索值
        /// </summary>
        /// <param name="array">要搜索的已排序一维 <see cref="Array"/> </param>
        /// <param name="value">要搜索的对象</param>
        /// <param name="comparer">比较元素时要使用的 <see cref="IComparer"/> 实现。- 或 -若为 null，则使用每个元素的 <see cref="IComparable"/> 实现</param>
        /// <returns>如果找到 value，则为指定 array 中的指定 value 的索引。
        /// 如果找不到 value 且 value 小于 array 中的一个或多个元素，则为一个负数，该负数是大于value 的第一个元素的索引的按位求补。
        /// 如果找不到 value 且 value 大于 array 中的任何元素，则为一个负数，该负数是（最后一个元素的索引加1）的按位求补
        /// </returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        /// <exception cref="ArgumentException">comparer 是 null，而 value 是不与 array 的元素兼容的类型</exception>
        /// <exception cref="InvalidOperationException">comparer 为 null，value 没有实现 <see cref="IComparable"/> 接口，并且搜索时遇到没有实现 <see cref="IComparable"/> 接口的元素</exception>
        public static int BinarySearch(this Array array, object value, IComparer comparer) => Array.BinarySearch(array, value, comparer);
        #endregion

        #region 使用指定的 System.Collections.IComparer 接口，在一维排序 System.Array 的某个元素范围中搜索值
        /// <summary>
        /// 使用指定的 <see cref="IComparer"/> 接口，在一维排序 <see cref="Array"/> 的某个元素范围中搜索值
        /// </summary>
        /// <param name="array">要搜索的已排序一维 <see cref="Array"/> </param>
        /// <param name="index">要搜索的范围的起始索引</param>
        /// <param name="length">要搜索的范围的长度</param>
        /// <param name="value">要搜索的对象</param>
        /// <param name="comparer">比较元素时要使用的 <see cref="IComparer"/> 实现。- 或 -若为 null，则使用每个元素的 <see cref="IComparable"/> 实现</param>
        /// <returns>
        /// 如果找到 value，则为指定 array 中的指定 value 的索引。
        /// 如果找不到 value 且 value 小于 array 中的一个或多个元素，则为一个负数，该负数是大于value 的第一个元素的索引的按位求补。
        /// 如果找不到 value 且 value 大于 array 中的任何元素，则为一个负数，该负数是（最后一个元素的索引加1）的按位求补
        /// </returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 array 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">index 和 length 不指定 array 中的有效范围。- 或 -comparer 是 null，而 value 是不与 array 的元素兼容的类型。</exception>
        /// <exception cref="ArgumentException">comparer 为 null，value 没有实现 <see cref="IComparable"/> 接口，并且搜索时遇到没有实现 <see cref="IComparable"/> 接口的元素</exception>
        public static int BinarySearch(this Array array, int index, int length, object value, IComparer comparer) => Array.BinarySearch(array, index, length, value, comparer);
        #endregion

        #region 使用指定的 System.Collections.Generic.IComparer<T> 泛型接口，在整个一维排序 System.Array 中搜索值
        /// <summary>
        /// 使用指定的 <see cref="IComparer{T}"/> 泛型接口，在整个一维排序 <see cref="Array"/> 中搜索值
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维排序 <see cref="Array"/> </param>
        /// <param name="value">要搜索的对象</param>
        /// <param name="comparer">比较元素时要使用的 <see cref="IComparer{T}"/> 实现。- 或 -若为 null，则使用每个元素的 <see cref="IComparable{T}"/> 实现</param>
        /// <returns>
        /// 如果找到 value，则为指定 array 中的指定 value 的索引。
        /// 如果找不到 value 且 value 小于 array 中的一个或多个元素，则为一个负数，该负数是大于value 的第一个元素的索引的按位求补。
        /// 如果找不到 value 且 value 大于 array 中的任何元素，则为一个负数，该负数是（最后一个元素的索引加1）的按位求补。
        /// </returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="ArgumentException">comparer 是 null，而 value 是不与 array 的元素兼容的类型</exception>
        /// <exception cref="InvalidOperationException">comparer 为 null，value 没有实现 <see cref="IComparable{T}"/> 泛型接口，并且搜索时遇到没有实现 <see cref="IComparable{T}"/> 泛型接口的元素</exception>
        public static int BinarySearch<T>(this T[] array, T value, IComparer<T> comparer) => Array.BinarySearch(array, value, comparer);
        #endregion

        #region 使用指定的 System.Collections.Generic.IComparer<T> 泛型接口，在一维排序 System.Array 的某个元素范围中搜索值
        /// <summary>
        /// 使用指定的 <see cref="IComparer{T}"/> 泛型接口，在一维排序 <see cref="Array"/> 的某个元素范围中搜索值
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维排序 <see cref="Array"/></param>
        /// <param name="index">要搜索的范围的起始索引</param>
        /// <param name="length">要搜索的范围的长度</param>
        /// <param name="value">要搜索的对象</param>
        /// <param name="comparer">比较元素时要使用的 <see cref="IComparer{T}"/> 实现。- 或 -若为 null，则使用每个元素的 <see cref="IComparable{T}"/> 实现</param>
        /// <returns>
        /// 如果找到 value，则为指定 array 中的指定 value 的索引。
        /// 如果找不到 value 且 value 小于 array 中的一个或多个元素，则为一个负数，该负数是大于value 的第一个元素的索引的按位求补。
        /// 如果找不到 value 且 value 大于 array 中的任何元素，则为一个负数，该负数是（最后一个元素的索引加1）的按位求补
        /// </returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 array 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">index 和 length 不指定 array 中的有效范围。- 或 -value 是不与 array 的元素兼容的类型</exception>
        /// <exception cref="InvalidOperationException">value 没有实现 <see cref="IComparable{T}"/> 泛型接口，并且搜索时遇到没有实现 <see cref="IComparable{T}"/> 泛型接口的元素</exception>
        public static int BinarySearch<T>(this T[] array, int index, int length, T value, IComparer<T> comparer) => Array.BinarySearch(array, index, length, value, comparer);
        #endregion

        #region 使用由 System.Array 中每个元素和指定的对象实现的 System.IComparable 接口，在整个一维排序 System.Array 中搜索特定元素
        /// <summary>
        /// 使用由 <see cref="Array"/> 中每个元素和指定的对象实现的 <see cref="IComparable"/> 接口，在整个一维排序 <see cref="Array"/> 中搜索特定元素
        /// </summary>
        /// <param name="array">要搜索的已排序一维 <see cref="Array"/> </param>
        /// <param name="value">要搜索的对象</param>
        /// <returns>如果找到 value，则为指定 array 中的指定 value 的索引。
        /// 如果找不到 value 且 value 小于 array 中的一个或多个元素，则为一个负数，该负数是大于 value 的第一个元素的索引的按位求补。
        /// 如果找不到 value 且 value 大于 array 中的任何元素，则为一个负数，该负数是（最后一个元素的索引加1）的按位求补
        /// </returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        /// <exception cref="ArgumentException">value 是不与 array 的元素兼容的类型</exception>
        /// <exception cref="InvalidOperationException">value 没有实现 <see cref="IComparable"/> 接口，并且搜索时遇到没有实现 <see cref="IComparable"/> 接口的元素</exception>
        public static int BinarySearch(this Array array, object value) => Array.BinarySearch(array, value);
        #endregion

        #region 使用由 System.Array 中每个元素和指定的对象实现的 System.IComparable<T> 泛型接口，在整个一维排序 System.Array 中搜索特定元素
        /// <summary>
        /// 使用由 <see cref="Array"/> 中每个元素和指定的对象实现的 <see cref="IComparable{T}"/> 泛型接口，在整个一维排序 <see cref="Array"/> 中搜索特定元素
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维排序 <see cref="Array"/></param>
        /// <param name="value">要搜索的对象</param>
        /// <returns>
        /// 如果找到 value，则为指定 array 中的指定 value 的索引。
        /// 如果找不到 value 且 value 小于 array 中的一个或多个元素，则为一个负数，该负数是大于value 的第一个元素的索引的按位求补。
        /// 如果找不到 value 且 value 大于 array 中的任何元素，则为一个负数，该负数是（最后一个元素的索引加1）的按位求补。
        /// </returns>
        /// <exception cref="ArgumentNullException">array 为 null。</exception>
        /// <exception cref="InvalidOperationException">value 没有实现 <see cref="IComparable{T}"/> 泛型接口，并且搜索时遇到没有实现 <see cref="IComparable{T}"/> 泛型接口的元素</exception>
        public static int BinarySearch<T>(this T[] array, T value) => Array.BinarySearch(array, value);
        #endregion

        #region 使用由 System.Array 中每个元素和指定值实现的 System.IComparable<T> 泛型接口，在一维排序 System.Array 的某个元素范围中搜索值
        /// <summary>
        /// 使用由 <see cref="Array"/> 中每个元素和指定值实现的 <see cref="IComparable{T}"/> 泛型接口，在一维排序 <see cref="Array"/> 的某个元素范围中搜索值
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维排序 <see cref="Array"/></param>
        /// <param name="index">要搜索的范围的起始索引</param>
        /// <param name="length">要搜索的范围的长度</param>
        /// <param name="value">要搜索的对象</param>
        /// <returns>
        /// 如果找到 value，则为指定 array 中的指定 value 的索引。
        /// 如果找不到 value 且 value 小于 array 中的一个或多个元素，则为一个负数，该负数是大于value 的第一个元素的索引的按位求补。
        /// 如果找不到 value 且 value 大于 array 中的任何元素，则为一个负数，该负数是（最后一个元素的索引加1）的按位求补
        /// </returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 array 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">index 和 length 不指定 array 中的有效范围。- 或 -value 是不与 array 的元素兼容的类型</exception>
        /// <exception cref="InvalidOperationException">value 没有实现 <see cref="IComparable{T}"/> 泛型接口，并且搜索时遇到没有实现 <see cref="IComparable{T}"/> 泛型接口的元素</exception>
        public static int BinarySearch<T>(this T[] array, int index, int length, T value) => Array.BinarySearch(array, index, length, value);
        #endregion

        #region 使用由 System.Array 中每个元素和指定值实现的 System.IComparable 接口，在一维排序 System.Array 的某个范围中搜索值
        /// <summary>
        /// 使用由 <see cref="Array"/> 中每个元素和指定值实现的 <see cref="IComparable"/> 接口，在一维排序 <see cref="Array"/> 的某个范围中搜索值
        /// </summary>
        /// <param name="array">要搜索的已排序一维 <see cref="Array"/></param>
        /// <param name="index">要搜索的范围的起始索引</param>
        /// <param name="length">要搜索的范围的长度</param>
        /// <param name="value">要搜索的对象</param>
        /// <returns>
        /// 如果找到 value，则为指定 array 中的指定 value 的索引。
        /// 如果找不到 value 且 value 小于 array 中的一个或多个元素，则为一个负数，该负数是大于value 的第一个元素的索引的按位求补。
        /// 如果找不到 value 且 value 大于 array 中的任何元素，则为一个负数，该负数是（最后一个元素的索引加1）的按位求补
        /// </returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 array 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">index 和 length 不指定 array 中的有效范围。- 或 -value 是不与 array 的元素兼容的类型</exception>
        /// <exception cref="InvalidOperationException">value 没有实现 <see cref="IComparable{T}"/> 泛型接口，并且搜索时遇到没有实现 <see cref="IComparable{T}"/> 泛型接口的元素</exception>
        public static int BinarySearch(this Array array, int index, int length, object value) => Array.BinarySearch(array, index, length, value);
        #endregion

        #region 从指定的源索引开始，复制 System.Array 中的一系列元素，将它们粘贴到另一 System.Array 中（从指定的目标索引开始）。保证在复制未成功完成的情况下撤消所有更改


        /// <summary>
        /// 从指定的源索引开始，复制 <see cref="Array"/> 中的一系列元素，将它们粘贴到另一 <see cref="Array"/> 中（从指定的目标索引开始）。保证在复制未成功完成的情况下撤消所有更改
        /// </summary>
        /// <param name="sourceArray"><see cref="Array"/>，它包含要复制的数据</param>
        /// <param name="sourceIndex">一个 32 位整数，它表示 sourceArray 中复制开始处的索引</param>
        /// <param name="destinationArray"><see cref="Array"/>，它接收数据</param>
        /// <param name="destinationIndex">一个 32 位整数，它表示 destinationArray 中存储开始处的索引</param>
        /// <param name="length">一个 32 位整数，它表示要复制的元素数目</param>
        /// <exception cref="ArgumentNullException">sourceArray 为 null。- 或 -destinationArray 为 null</exception>
        /// <exception cref="RankException">sourceArray 和 destinationArray 的秩不同</exception>
        /// <exception cref="ArrayTypeMismatchException">sourceArray 类型不同于并且不是从 destinationArray 类型派生的</exception>
        /// <exception cref="InvalidCastException">sourceArray 中的至少一个元素无法强制转换为 destinationArray 类型</exception>
        /// <exception cref="ArgumentOutOfRangeException">sourceIndex 小于 sourceArray 的第一维的下限。- 或 -destinationIndex 小于 destinationArray的第一维的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">length 大于从 sourceIndex 到 sourceArray 末尾的元素数。- 或 -length 大于从 destinationIndex 到 destinationArray 末尾的元素数</exception>
        public static void ConstrainedCopy(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length) => Array.ConstrainedCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        #endregion

        #region 从第一个元素开始复制 System.Array 中的一系列元素，将它们粘贴到另一 System.Array 中（从第一个元素开始）。长度指定为 32 位整数
        /// <summary>
        /// 从第一个元素开始复制 <see cref="Array"/> 中的一系列元素，将它们粘贴到另一 <see cref="Array"/> 中（从第一个元素开始）。长度指定为 32 位整数
        /// </summary>
        /// <param name="sourceArray"><see cref="Array"/>，它包含要复制的数据</param>
        /// <param name="destinationArray"><see cref="Array"/>，它接收数据</param>
        /// <param name="length">一个 32 位整数，它表示要复制的元素数目</param>
        /// <exception cref="ArgumentNullException">sourceArray 为 null。- 或 -destinationArray 为 null</exception>
        /// <exception cref="RankException">sourceArray 和 destinationArray 的秩不同</exception>
        /// <exception cref="ArrayTypeMismatchException">sourceArray 和 destinationArray 是不兼容的类型</exception>
        /// <exception cref="InvalidCastException">sourceArray 中的至少一个元素无法强制转换为 destinationArray 类型</exception>
        /// <exception cref="ArgumentOutOfRangeException">length 小于零</exception>
        /// <exception cref="ArgumentException">length 大于 sourceArray 中的元素数。- 或 -length 大于 destinationArray 中的元素数</exception>
        public static void Copy(this Array sourceArray, Array destinationArray, int length) => Array.Copy(sourceArray, destinationArray, length);
        #endregion

        #region 从指定的源索引开始，复制 System.Array 中的一系列元素，将它们粘贴到另一 System.Array 中（从指定的目标索引开始）。长度和索引指定为64 位整数
        /// <summary>
        /// 从指定的源索引开始，复制 <see cref="Array"/> 中的一系列元素，将它们粘贴到另一 <see cref="Array"/> 中（从指定的目标索引开始）。长度和索引指定为64 位整数
        /// </summary>
        /// <param name="sourceArray"><see cref="Array"/>，它包含要复制的数据</param>
        /// <param name="sourceIndex">一个 64 位整数，它表示 sourceArray 中复制开始处的索引</param>
        /// <param name="destinationArray"><see cref="Array"/>，它接收数据</param>
        /// <param name="destinationIndex">一个 64 位整数，它表示 destinationArray 中存储开始处的索引</param>
        /// <param name="length"> 一个 64 位整数，它表示要复制的元素数目。该整数必须介于零和 <see cref="int.MaxValue"/> 之间（包括零和 <see cref="int.MaxValue"/>）</param>
        /// <exception cref="ArgumentNullException">sourceArray 为 null。- 或 -destinationArray 为 null</exception>
        /// <exception cref="RankException">sourceArray 和 destinationArray 的秩不同</exception>
        /// <exception cref="ArrayTypeMismatchException">sourceArray 和 destinationArray 是不兼容的类型</exception>
        /// <exception cref="InvalidCastException">sourceArray 中的至少一个元素无法强制转换为 destinationArray 类型</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// sourceIndex 不在 sourceArray 的有效索引范围内。- 或 -destinationIndex 不在 destinationArray 的有效索引范围。
        /// - 或 -length 小于零或大于 <see cref="int.MaxValue"/></exception>
        /// <exception cref="ArgumentException">length 大于从 sourceIndex 到 sourceArray 末尾的元素数。- 或 -length 大于从 destinationIndex 到 destinationArray 末尾的元素数</exception>
        public static void Copy(this Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length) => Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        #endregion

        #region 从第一个元素开始复制 System.Array 中的一系列元素，将它们粘贴到另一 System.Array 中（从第一个元素开始）。长度指定为 64 位整数
        /// <summary>
        /// 从第一个元素开始复制 <see cref="Array"/> 中的一系列元素，将它们粘贴到另一 <see cref="Array"/> 中（从第一个元素开始）。长度指定为 64 位整数
        /// </summary>
        /// <param name="sourceArray"><see cref="Array"/>，它包含要复制的数据</param>
        /// <param name="destinationArray"><see cref="Array"/>，它接收数据</param>
        /// <param name="length">一个 64 位整数，它表示要复制的元素数目。该整数必须介于零和 <see cref="int.MaxValue"/> 之间（包括零和 <see cref="int.MaxValue"/>）</param>
        /// <exception cref="ArgumentNullException">sourceArray 为 null。- 或 -destinationArray 为 null</exception>
        /// <exception cref="RankException">sourceArray 和 destinationArray 的秩不同</exception>
        /// <exception cref="ArrayTypeMismatchException">sourceArray 和 destinationArray 是不兼容的类型</exception>
        /// <exception cref="InvalidCastException">sourceArray 中的至少一个元素无法强制转换为 destinationArray 类型</exception>
        /// <exception cref="ArgumentOutOfRangeException">length 小于零或大于 <see cref="int.MaxValue"/></exception>
        /// <exception cref="ArgumentException">length 大于 sourceArray 中的元素数。- 或 -length 大于 destinationArray 中的元素数</exception>
        public static void Copy(this Array sourceArray, Array destinationArray, long length) => Array.Copy(sourceArray, destinationArray, length);
        #endregion

        #region 从指定的源索引开始，复制 System.Array 中的一系列元素，将它们粘贴到另一 System.Array 中（从指定的目标索引开始）。长度和索引指定为 32 位整数
        /// <summary>
        /// 从指定的源索引开始，复制 <see cref="Array"/> 中的一系列元素，将它们粘贴到另一 <see cref="Array"/> 中（从指定的目标索引开始）。长度和索引指定为 32 位整数
        /// </summary>
        /// <param name="sourceArray"><see cref="Array"/>，它包含要复制的数据</param>
        /// <param name="sourceIndex">一个 32 位整数，它表示 sourceArray 中复制开始处的索引</param>
        /// <param name="destinationArray"><see cref="Array"/>，它接收数据</param>
        /// <param name="destinationIndex">一个 32 位整数，它表示 destinationArray 中存储开始处的索引</param>
        /// <param name="length">一个 32 位整数，它表示要复制的元素数目</param>
        /// <exception cref="ArgumentNullException">sourceArray 为 null。- 或 -destinationArray 为 null</exception>
        /// <exception cref="RankException">sourceArray 和 destinationArray 的秩不同</exception>
        /// <exception cref="ArrayTypeMismatchException">sourceArray 和 destinationArray 是不兼容的类型</exception>
        /// <exception cref="InvalidCastException">sourceArray 中的至少一个元素无法强制转换为 destinationArray 类型</exception>
        /// <exception cref="ArgumentOutOfRangeException">sourceIndex 小于 sourceArray 的第一维的下限。- 或 -destinationIndex 小于 destinationArray的第一维的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">length 大于从 sourceIndex 到 sourceArray 末尾的元素数。- 或 -length 大于从 destinationIndex 到 destinationArray 末尾的元素数</exception>
        public static void Copy(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length) => Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        #endregion

        #region 搜索与指定谓词定义的条件匹配的元素，然后返回整个 System.Array 中的第一个匹配项
        /// <summary>
        /// 搜索与指定谓词定义的条件匹配的元素，然后返回整个 <see cref="Array"/> 中的第一个匹配项
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="match"><see cref="Predicate{T}"/>，定义要搜索的元素的条件</param>
        /// <returns>如果找到与指定谓词定义的条件匹配的第一个元素，则为该元素；否则为类型 T 的默认值</returns>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -match 为 null</exception>
        public static T Find<T>(this T[] array, Predicate<T> match) => Array.Find(array, match);
        #endregion

        #region 检索与指定谓词定义的条件匹配的所有元素
        /// <summary>
        /// 检索与指定谓词定义的条件匹配的所有元素
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="match"><see cref="Predicate{T}"/>，定义要搜索的元素的条件</param>
        /// <returns>如果找到一个其中所有元素均与指定谓词定义的条件匹配的 <see cref="Array"/>，则为该数组；否则为一个空 <see cref="Array"/></returns>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -match 为 null</exception>
        public static T[] FindAll<T>(this T[] array, Predicate<T> match) => Array.FindAll(array, match);
        #endregion

        #region 搜索与指定谓词定义的条件匹配的元素，然后返回 System.Array 中从指定索引到最后一个元素的元素范围内第一个匹配项的从零开始的索引
        /// <summary>
        /// 搜索与指定谓词定义的条件匹配的元素，然后返回 <see cref="Array"/> 中从指定索引到最后一个元素的元素范围内第一个匹配项的从零开始的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="startIndex">从零开始的搜索的起始索引</param>
        /// <param name="match"><see cref="Predicate{T}"/>，定义要搜索的元素的条件</param>
        /// <returns>如果找到与 match 定义的条件相匹配的第一个元素，则为该元素的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -match 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围</exception>
        public static int FindIndex<T>(this T[] array, int startIndex, Predicate<T> match) => Array.FindIndex(array, startIndex, match);
        #endregion

        #region 搜索与指定谓词定义的条件匹配的元素，然后返回 System.Array 中从指定索引开始并包含指定元素个数的元素范围内第一个匹配项的从零开始的索引
        /// <summary>
        /// 搜索与指定谓词定义的条件匹配的元素，然后返回 <see cref="Array"/> 中从指定索引开始并包含指定元素个数的元素范围内第一个匹配项的从零开始的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="startIndex">从零开始的搜索的起始索引</param>
        /// <param name="count">要搜索的部分中的元素数</param>
        /// <param name="match"><see cref="Predicate{T}"/>，定义要搜索的元素的条件</param>
        /// <returns>如果找到与 match 定义的条件相匹配的第一个元素，则为该元素的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -match 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围。- 或 -count 小于零。- 或 -startIndex 和 count 指定的不是 array 中的有效部分</exception>
        public static int FindIndex<T>(this T[] array, int startIndex, int count, Predicate<T> match) => Array.FindIndex(array, startIndex, count, match);
        #endregion

        #region 搜索与指定谓词定义的条件匹配的元素，然后返回整个 System.Array 中第一个匹配项的从零开始的索引
        /// <summary>
        /// 搜索与指定谓词定义的条件匹配的元素，然后返回整个 <see cref="Array"/> 中第一个匹配项的从零开始的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="match"><see cref="Predicate{T}"/>，定义要搜索的元素的条件</param>
        /// <returns>如果找到与 match 定义的条件相匹配的第一个元素，则为该元素的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -match 为 null</exception>
        public static int FindIndex<T>(this T[] array, Predicate<T> match) => Array.FindIndex(array, match);
        #endregion

        #region 搜索与指定谓词定义的条件匹配的元素，然后返回整个 System.Array 中的最后一个匹配项
        /// <summary>
        /// 搜索与指定谓词定义的条件匹配的元素，然后返回整个 <see cref="Array"/> 中的最后一个匹配项
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="match"><see cref="Predicate{T}"/>，定义要搜索的元素的条件</param>
        /// <returns>如果找到与指定谓词定义的条件匹配的最后一个元素，则为该元素；否则为类型 T 的默认值</returns>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -match 为 null</exception>
        public static T FindLast<T>(this T[] array, Predicate<T> match) => Array.FindLast(array, match);
        #endregion

        #region 搜索与指定谓词定义的条件匹配的元素，然后返回 System.Array 中包含指定元素个数并以指定索引结束的元素范围内最后一个匹配项的从零开始的索引
        /// <summary>
        /// 搜索与指定谓词定义的条件匹配的元素，然后返回 <see cref="Array"/> 中包含指定元素个数并以指定索引结束的元素范围内最后一个匹配项的从零开始的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="startIndex">向后搜索的从零开始的起始索引</param>
        /// <param name="count">要搜索的部分中的元素数</param>
        /// <param name="match"><see cref="Predicate{T}"/>，定义要搜索的元素的条件</param>
        /// <returns>如果找到与 match 定义的条件相匹配的最后一个元素，则为该元素的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -match 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围。- 或 -count 小于零。- 或 -startIndex 和 count 指定的不是 array 中的有效部分</exception>
        public static int FindLastIndex<T>(this T[] array, int startIndex, int count, Predicate<T> match) => Array.FindLastIndex(array, startIndex, count, match);
        #endregion

        #region 搜索与指定谓词定义的条件匹配的元素，然后返回 System.Array 中从第一个元素到指定索引的元素范围内最后一个匹配项的从零开始的索引
        /// <summary>
        /// 搜索与指定谓词定义的条件匹配的元素，然后返回 <see cref="Array"/> 中从第一个元素到指定索引的元素范围内最后一个匹配项的从零开始的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="startIndex">向后搜索的从零开始的起始索引</param>
        /// <param name="match"><see cref="Predicate{T}"/>，定义要搜索的元素的条件</param>
        /// <returns>如果找到与 match 定义的条件相匹配的最后一个元素，则为该元素的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -match 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围</exception>
        public static int FindLastIndex<T>(this T[] array, int startIndex, Predicate<T> match) => Array.FindLastIndex(array, startIndex, match);
        #endregion

        #region 搜索与指定谓词定义的条件匹配的元素，然后返回整个 System.Array 中最后一个匹配项的从零开始的索引
        /// <summary>
        /// 搜索与指定谓词定义的条件匹配的元素，然后返回整个 <see cref="Array"/> 中最后一个匹配项的从零开始的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="match"><see cref="Predicate{T}"/>，定义要搜索的元素的条件</param>
        /// <returns>如果找到与 match 定义的条件相匹配的最后一个元素，则为该元素的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -match 为 null</exception>
        public static int FindLastIndex<T>(this T[] array, Predicate<T> match) => Array.FindLastIndex(array, match);
        #endregion

        #region 搜索指定的对象，并返回 System.Array 中从指定索引开始包含指定个元素的这部分元素中第一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回 <see cref="Array"/> 中从指定索引开始包含指定个元素的这部分元素中第一个匹配项的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <param name="startIndex">从零开始的搜索的起始索引。空数组中 0（零）为有效值</param>
        /// <param name="count">要搜索的部分中的元素数</param>
        /// <returns>如果在 array 中从 startIndex 开始、包含 count 所指定的元素个数的这部分元素中，找到 value 的匹配项，则为第一个匹配项的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -match 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围。- 或 -count 小于零。- 或 -startIndex 和 count 指定的不是 array 中的有效部分</exception>
        public static int IndexOf<T>(this T[] array, T value, int startIndex, int count) => Array.IndexOf(array, value, startIndex, count);
        #endregion

        #region 搜索指定的对象，并返回 System.Array 中从指定索引到最后一个元素这部分元素中第一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回 <see cref="Array"/> 中从指定索引到最后一个元素这部分元素中第一个匹配项的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <param name="startIndex">从零开始的搜索的起始索引。空数组中 0（零）为有效值</param>
        /// <returns>如果在 array 中从 startIndex 到最后一个元素这部分元素中找到 value 的匹配项，则为第一个匹配项的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围</exception>
        public static int IndexOf<T>(this T[] array, T value, int startIndex) => Array.IndexOf(array, value, startIndex);
        #endregion

        #region 搜索指定的对象，并返回整个 System.Array 中第一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回整个 <see cref="Array"/> 中第一个匹配项的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <returns>如果在整个 array 中找到 value 的匹配项，则为第一个匹配项的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        public static int IndexOf<T>(this T[] array, T value) => Array.IndexOf(array, value);
        #endregion

        #region 搜索指定的对象，并返回一维 System.Array 中从指定索引到最后一个元素这部分元素中第一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回一维 <see cref="Array"/> 中从指定索引到最后一个元素这部分元素中第一个匹配项的索引
        /// </summary>
        /// <param name="array">要搜索的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <param name="startIndex">搜索的起始索引。空数组中 0（零）为有效值</param>
        /// <returns>如果在 array 中从 startIndex 到最后一个元素这部分元素中第一个与 value 匹配的项的索引；否则为该数组的下限减 1</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        public static int IndexOf(this Array array, object value, int startIndex) => Array.IndexOf(array, value, startIndex);
        #endregion

        #region 搜索指定的对象，并返回整个一维 System.Array 中第一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回整个一维 <see cref="Array"/> 中第一个匹配项的索引
        /// </summary>
        /// <param name="array">要搜索的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <returns>如果在整个 array 中找到 value 的匹配项，则为第一个匹配项的索引；否则为该数组的下限减 1</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        public static int IndexOf(this Array array, object value) => Array.IndexOf(array, value);
        #endregion

        #region 搜索指定的对象，并返回一维 System.Array 中从指定索引开始包含指定个元素的这部分元素中第一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回一维 <see cref="Array"/> 中从指定索引开始包含指定个元素的这部分元素中第一个匹配项的索引
        /// </summary>
        /// <param name="array">要搜索的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <param name="startIndex">搜索的起始索引。空数组中 0（零）为有效值</param>
        /// <param name="count">要搜索的部分中的元素数</param>
        /// <returns>如果在 array 中从 startIndex 开始并且包含的元素个数为在 count 中指定的个数的这部分元素中找到 value 的匹配项，则为第一个匹配项的索引；否则为该数组的下限减1</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围。- 或 -count 小于零。- 或 -startIndex 和 count 指定的不是 array 中的有效部分</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        public static int IndexOf(this Array array, object value, int startIndex, int count) => Array.IndexOf(array, value, startIndex, count);
        #endregion

        #region 搜索指定的对象，并返回一维 System.Array 中到指定索引为止包含指定个元素的这部分元素中最后一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回一维 <see cref="Array"/> 中到指定索引为止包含指定个元素的这部分元素中最后一个匹配项的索引
        /// </summary>
        /// <param name="array">要搜索的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <param name="startIndex">向后搜索的起始索引</param>
        /// <param name="count">要搜索的部分中的元素数</param>
        /// <returns>如果在 array 中到 startIndex 为止并且包含的元素个数为在 count 中指定的个数的这部分元素中找到 value 的匹配项，则为最后一个匹配项的索引；否则为该数组的下限减1</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围。- 或 -count 小于零。- 或 -startIndex 和 count 指定的不是 array 中的有效部分</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        public static int LastIndexOf(this Array array, object value, int startIndex, int count) => Array.LastIndexOf(array, value, startIndex, count);
        #endregion

        #region 搜索指定的对象，并返回一维 System.Array 中从第一个元素到指定索引这部分元素中最后一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回一维 <see cref="Array"/> 中从第一个元素到指定索引这部分元素中最后一个匹配项的索引
        /// </summary>
        /// <param name="array">要搜索的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <param name="startIndex">向后搜索的起始索引</param>
        /// <returns>如果在 array 中从第一个元素到 startIndex 这部分元素中找到 value 的匹配项，则为最后一个匹配项的索引；否则为该数组的下限减 1</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围。</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        public static int LastIndexOf(this Array array, object value, int startIndex) => Array.LastIndexOf(array, value, startIndex);
        #endregion

        #region 搜索指定的对象，并返回 System.Array 中从第一个元素到指定索引这部分元素中最后一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回 <see cref="Array"/> 中从第一个元素到指定索引这部分元素中最后一个匹配项的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <param name="startIndex">向后搜索的从零开始的起始索引</param>
        /// <returns>如果在 array 中从第一个元素到 startIndex 这部分元素中找到 value 的匹配项，则为最后一个匹配项的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围。</exception>
        public static int LastIndexOf<T>(this T[] array, T value, int startIndex) => Array.LastIndexOf(array, value, startIndex);
        #endregion

        #region 搜索指定的对象，并返回 System.Array 中到指定索引为止包含指定个元素的这部分元素中最后一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回 <see cref="Array"/> 中到指定索引为止包含指定个元素的这部分元素中最后一个匹配项的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <param name="startIndex">向后搜索的从零开始的起始索引</param>
        /// <param name="count">要搜索的部分中的元素数</param>
        /// <returns>如果在 array 中到 startIndex 为止、包含 count 所指定的元素个数的这部分元素中，找到 value 的匹配项，则为最后一个匹配项的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">startIndex 超出了 array 的有效索引范围。- 或 -count 小于零。- 或 -startIndex 和 count 指定的不是 array 中的有效部分</exception>
        public static int LastIndexOf<T>(this T[] array, T value, int startIndex, int count) => Array.LastIndexOf(array, value, startIndex, count);
        #endregion

        #region 搜索指定的对象，并返回整个 System.Array 中最后一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回整个 <see cref="Array"/> 中最后一个匹配项的索引
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要搜索的从零开始的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <returns>如果在整个 array 中找到 value 的匹配项，则为最后一个匹配项的从零开始的索引；否则为 -1</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        public static int LastIndexOf<T>(this T[] array, T value) => Array.LastIndexOf(array, value);
        #endregion

        #region 搜索指定的对象，并返回整个一维 System.Array 中最后一个匹配项的索引
        /// <summary>
        /// 搜索指定的对象，并返回整个一维 <see cref="Array"/> 中最后一个匹配项的索引
        /// </summary>
        /// <param name="array">要搜索的一维 <see cref="Array"/></param>
        /// <param name="value">要在 array 中查找的对象</param>
        /// <returns>如果在整个 array 中找到 value 的匹配项，则为最后一个匹配项的索引；否则为该数组的下限减 1</returns>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        public static int LastIndexOf(this Array array, object value) => Array.LastIndexOf(array, value);
        #endregion

        #region 将数组的大小更改为指定的新大小
        /// <summary>
        /// 将数组的大小更改为指定的新大小
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要调整大小的一维数组，该数组从零开始；如果为 null 则新建具有指定大小的数组</param>
        /// <param name="newSize">新数组的大小</param>
        /// <exception cref="ArgumentOutOfRangeException">newSize 小于零</exception>
        public static void Resize<T>(this T[] array, int newSize) => Array.Resize(ref array, newSize);
        #endregion

        #region 反转一维 System.Array 中某部分元素的元素顺序
        /// <summary>
        /// 反转一维 <see cref="Array"/> 中某部分元素的元素顺序
        /// </summary>
        /// <param name="array">要反转的一维 <see cref="Array"/></param>
        /// <param name="index">要反转的部分的起始索引</param>
        /// <param name="length">要反转的部分中的元素数</param>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 array 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">index 和 length 不指定 array 中的有效范围</exception>
        public static void Reverse(this Array array, int index, int length) => Array.Reverse(array, index, length);
        #endregion

        #region 反转整个一维 System.Array 中元素的顺序
        /// <summary>
        /// 反转整个一维 <see cref="Array"/> 中元素的顺序
        /// </summary>
        /// <param name="array">要反转的一维 <see cref="Array"/></param>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        public static void Reverse(this Array array) => Array.Reverse(array);
        #endregion

        #region 使用 System.Array 中每个元素的 System.IComparable 实现，对一维 System.Array 中某部分元素进行排序
        /// <summary>
        /// 使用 <see cref="Array"/> 中每个元素的 <see cref="IComparable"/> 实现，对一维 <see cref="Array"/> 中某部分元素进行排序
        /// </summary>
        /// <param name="array">要排序的一维 <see cref="Array"/></param>
        /// <param name="index">排序范围的起始索引</param>
        /// <param name="length">排序范围内的元素数</param>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 array 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">index 和 length 不指定 array 中的有效范围</exception>
        /// <exception cref="InvalidOperationException">array 中的一个或多个元素未实现 <see cref="IComparable"/> 接口</exception>
        public static void Sort(this Array array, int index, int length) => Array.Sort(array, index, length);
        #endregion

        #region 使用 System.Array 的每个元素的 System.IComparable<T> 泛型接口实现，对整个 System.Array 中的元素进行排序
        /// <summary>
        /// 使用 <see cref="Array"/> 的每个元素的 <see cref="IComparable{T}"/> 泛型接口实现，对整个 <see cref="Array"/> 中的元素进行排序
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要排序的从零开始的一维 <see cref="Array"/></param>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="InvalidOperationException">array 中的一个或多个元素未实现 <see cref="IComparable{T}"/> 泛型接口</exception>
        public static void Sort<T>(this T[] array) => Array.Sort(array);
        #endregion

        #region 使用 System.Array 中每个元素的 System.IComparable 实现，对整个一维 System.Array 中的元素进行排序
        /// <summary>
        /// 使用 <see cref="Array"/> 中每个元素的 <see cref="IComparable"/> 实现，对整个一维 <see cref="Array"/> 中的元素进行排序
        /// </summary>
        /// <param name="array">要排序的一维 <see cref="Array"/></param>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        /// <exception cref="InvalidOperationException">array 中的一个或多个元素未实现 <see cref="IComparable"/> 接口</exception>
        public static void Sort(this Array array) => Array.Sort(array);
        #endregion

        #region 使用 System.Array 的每个元素的 System.IComparable<T> 泛型接口实现，对 System.Array 中某个元素范围内的元素进行排序
        /// <summary>
        /// 使用 <see cref="Array"/> 的每个元素的 <see cref="IComparable{T}"/> 泛型接口实现，对 <see cref="Array"/> 中某个元素范围内的元素进行排序
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要排序的从零开始的一维 <see cref="Array"/></param>
        /// <param name="index">排序范围的起始索引</param>
        /// <param name="length">排序范围内的元素数</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static void Sort<T>(this T[] array, int index, int length) => Array.Sort(array, index, length);
        #endregion

        #region 基于第一个 System.Array 中的关键字，使用指定的 System.Collections.IComparer，对两个一维 System.Array 对象（一个包含关键字，另一个包含对应的项）进行排序
        /// <summary>
        /// 基于第一个 <see cref="Array"/> 中的关键字，使用指定的 <see cref="IComparer"/>，对两个一维 <see cref="Array"/> 对象（一个包含关键字，另一个包含对应的项）进行排序
        /// </summary>
        /// <param name="keys">一维 <see cref="Array"/>，它包含要排序的关键字</param>
        /// <param name="items">一维 <see cref="Array"/>，它包含与 keys <see cref="Array"/> 中的每一个关键字对应的项。- 或 -如果为 null，则只对 keys <see cref="Array"/> 进行排序</param>
        /// <param name="comparer">比较元素时要使用的 <see cref="IComparer"/> 实现。- 或 -若为 null，则使用每个元素的 <see cref="IComparable"/> 实现</param>
        /// <exception cref="ArgumentNullException">keys 为 null</exception>
        /// <exception cref="RankException">keys <see cref="Array"/> 是多维的。- 或 -items <see cref="Array"/> 是多维的</exception>
        /// <exception cref="ArgumentException">items 不是 null，且 keys 的下限与 items 的下限不匹配。- 或 -items 不是 null，并且 keys 的长度与 items 的长度不匹配。- 或 -comparer 的实现导致排序时出现错误。例如，将某个项与其自身进行比较时，comparer 可能不返回 0</exception>
        /// <exception cref="InvalidOperationException">comparer 为 null，并且 keys <see cref="Array"/> 中的一个或多个元素不实现 <see cref="IComparable"/> 接口</exception>
        public static void Sort(this Array keys, Array items, IComparer comparer) => Array.Sort(keys, items, comparer);
        #endregion

        #region 基于第一个 System.Array 中的关键字，使用每个关键字的 System.IComparable 实现，对两个一维 System.Array 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序
        /// <summary>
        /// 基于第一个 <see cref="Array"/> 中的关键字，使用每个关键字的 <see cref="IComparable"/> 实现，对两个一维 <see cref="Array"/> 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="items"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentNullException">keys 为 null</exception>
        /// <exception cref="RankException">keys <see cref="Array"/> 是多维的。- 或 -items <see cref="Array"/> 是多维的</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 keys 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">
        /// items 不是 null，且 keys 的下限与 items 的下限不匹配。
        /// - 或 -items 不是 null，并且 keys 的长度与 items的长度不匹配。
        /// - 或 -index 和 length 未指定 keys <see cref="Array"/> 中的有效范围。
        /// - 或 -items 不为 null，并且index 和 length 未在 items <see cref="Array"/> 中指定有效范围
        /// </exception>
        /// <exception cref="ArgumentNullException">keys <see cref="Array"/> 中的一个或多个元素未实现 <see cref="IComparable"/> 接口</exception>
        public static void Sort(this Array keys, Array items, int index, int length) => Array.Sort(keys, items, index, length);
        #endregion

        #region 基于第一个 System.Array 中的关键字，使用每个关键字的 System.IComparable 实现，对两个一维 System.Array 对象（一个包含关键字，另一个包含对应的项）进行排序
        /// <summary>
        /// 基于第一个 <see cref="Array"/> 中的关键字，使用每个关键字的 <see cref="IComparable"/> 实现，对两个一维 <see cref="Array"/> 对象（一个包含关键字，另一个包含对应的项）进行排序
        /// </summary>
        /// <param name="keys">一维 <see cref="Array"/>，它包含要排序的关键字</param>
        /// <param name="items">一维 <see cref="Array"/>，它包含与 keys <see cref="Array"/> 中的每一个关键字对应的项。- 或 -如果为 null，则只对 keys <see cref="Array"/> 进行排序</param>
        /// <exception cref="ArgumentNullException">keys 为 null</exception>
        /// <exception cref="RankException">keys <see cref="Array"/> 是多维的。- 或 -items <see cref="Array"/> 是多维的</exception>
        /// <exception cref="ArgumentException">items 不是 null，且 keys 的下限与 items 的下限不匹配。- 或 -items 不是 null，并且 keys 的长度与 items 的长度不匹配</exception>
        /// <exception cref="InvalidOperationException">keys <see cref="Array"/> 中的一个或多个元素未实现 <see cref="IComparable"/> 接口</exception>
        public static void Sort(this Array keys, Array items) => Array.Sort(keys, items);
        #endregion

        #region 基于第一个 System.Array 中的关键字，使用每个关键字的 System.IComparable<T> 泛型接口实现，对两个 System.Array 对象（一个包含关键字，另一个包含对应的项）进行排序
        /// <summary>
        /// 基于第一个 <see cref="Array"/> 中的关键字，使用每个关键字的 <see cref="IComparable{T}"/> 泛型接口实现，对两个 <see cref="Array"/> 对象（一个包含关键字，另一个包含对应的项）进行排序
        /// </summary>
        /// <typeparam name="TKey">关键字数组元素的类型</typeparam>
        /// <typeparam name="TValue">项数组元素的类型</typeparam>
        /// <param name="keys">从零开始的一维 <see cref="Array"/>，它包含要排序的关键字</param>
        /// <param name="items">从零开始的一维 <see cref="Array"/>，其中包含与 keys 中的关键字对应的项；如果为 null，则只对 keys 进行排序</param>
        /// <exception cref="ArgumentNullException">keys 为 null</exception>
        /// <exception cref="ArgumentException">items 不是 null，且 keys 的下限与 items 的下限不匹配。- 或 -items 不是 null，并且 keys 的长度与 items 的长度不匹配</exception>
        /// <exception cref="InvalidOperationException">keys <see cref="Array"/> 中的一个或多个元素未实现 <see cref="IComparable{T}"/> 泛型接口</exception>
        public static void Sort<TKey, TValue>(this TKey[] keys, TValue[] items) => Array.Sort(keys, items);
        #endregion

        #region 基于第一个 System.Array 中的关键字，使用每个关键字的 System.IComparable<T> 泛型接口实现，对两个 System.Array 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序
        /// <summary>
        /// 基于第一个 <see cref="Array"/> 中的关键字，使用每个关键字的 <see cref="IComparable{T}"/> 泛型接口实现，对两个 <see cref="Array"/> 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序
        /// </summary>
        /// <typeparam name="TKey">关键字数组元素的类型</typeparam>
        /// <typeparam name="TValue">项数组元素的类型</typeparam>
        /// <param name="keys">从零开始的一维 <see cref="Array"/>，它包含要排序的关键字</param>
        /// <param name="items">从零开始的一维 <see cref="Array"/>，其中包含与 keys 中的关键字对应的项；如果为 null，则只对 keys 进行排序</param>
        /// <param name="index">排序范围的起始索引</param>
        /// <param name="length">排序范围内的元素数</param>
        /// <exception cref="ArgumentNullException">keys 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 keys 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">
        /// items 不是 null，且 keys 的下限与 items 的下限不匹配。
        /// - 或 -items 不是 null，并且 keys 的长度与 items 的长度不匹配。
        /// - 或 -index 和 length 未指定 keys <see cref="Array"/> 中的有效范围。
        /// - 或 -items 不为 null，并且 index 和 length 未在 items <see cref="Array"/> 中指定有效范围
        /// </exception>
        /// <exception cref="InvalidOperationException">keys <see cref="Array"/> 中的一个或多个元素未实现 <see cref="IComparable{T}"/> 泛型接口</exception>
        public static void Sort<TKey, TValue>(this TKey[] keys, TValue[] items, int index, int length) => Array.Sort(keys, items, index, length);
        #endregion

        #region 基于第一个 System.Array 中的关键字，使用指定的 System.Collections.Generic.IComparer<T> 泛型接口，对两个 System.Array 对象（一个包含关键字，另一个包含对应的项）进行排序
        /// <summary>
        /// 基于第一个 <see cref="Array"/> 中的关键字，使用指定的 <see cref="IComparer{T}"/> 泛型接口，对两个 <see cref="Array"/> 对象（一个包含关键字，另一个包含对应的项）进行排序
        /// </summary>
        /// <typeparam name="TKey">关键字数组元素的类型</typeparam>
        /// <typeparam name="TValue">项数组元素的类型</typeparam>
        /// <param name="keys">从零开始的一维 <see cref="Array"/>，它包含要排序的关键字</param>
        /// <param name="items">从零开始的一维 <see cref="Array"/>，其中包含与 keys 中的关键字对应的项；如果为 null，则只对 keys 进行排序</param>
        /// <param name="comparer">比较元素时使用的 <see cref="IComparer{T}"/> 泛型接口实现；如果为 null，则使用每个元素的 <see cref="IComparable{T}"/> 泛型接口实现</param>
        /// <exception cref="ArgumentNullException">keys 为 null</exception>
        /// <exception cref="ArgumentException">
        /// items 不是 null，且 keys 的下限与 items 的下限不匹配。
        /// - 或 -items 不是 null，并且 keys 的长度与 items 的长度不匹配。
        /// - 或 -comparer 的实现导致排序时出现错误。
        /// 例如，将某个项与其自身进行比较时，comparer 可能不返回 0
        /// </exception>
        /// <exception cref="InvalidOperationException">comparer 为 null，并且 keys <see cref="Array"/> 中的一个或多个元素未实现 <see cref="IComparable{T}"/> 泛型接口</exception>
        public static void Sort<TKey, TValue>(this TKey[] keys, TValue[] items, IComparer<TKey> comparer) => Array.Sort(keys, items, comparer);
        #endregion

        #region 基于第一个 System.Array 中的关键字，使用指定的 System.Collections.Generic.IComparer<T> 泛型接口，对两个 System.Array 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序
        /// <summary>
        /// 基于第一个 <see cref="Array"/> 中的关键字，使用指定的 <see cref="IComparer{T}"/> 泛型接口，对两个 <see cref="Array"/> 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序
        /// </summary>
        /// <typeparam name="TKey">关键字数组元素的类型</typeparam>
        /// <typeparam name="TValue">项数组元素的类型</typeparam>
        /// <param name="keys">从零开始的一维 <see cref="Array"/>，它包含要排序的关键字</param>
        /// <param name="items">从零开始的一维 <see cref="Array"/>，其中包含与 keys 中的关键字对应的项；如果为 null，则只对 keys 进行排序</param>
        /// <param name="index">排序范围的起始索引</param>
        /// <param name="length">排序范围内的元素数</param>
        /// <param name="comparer">比较元素时使用的 <see cref="IComparer{T}"/> 泛型接口实现；如果为 null，则使用每个元素的 <see cref="IComparable{T}"/> 泛型接口实现</param>
        /// <exception cref="ArgumentNullException">keys 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 keys 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">
        /// items 不是 null，且 keys 的下限与 items 的下限不匹配。
        /// - 或 -items 不是 null，并且 keys 的长度与 items 的长度不匹配。
        /// - 或 -index 和 length 未指定 keys <see cref="Array"/> 中的有效范围。
        /// - 或 -items 不为 null，并且index 和 length 未在 items <see cref="Array"/> 中指定有效范围。
        /// - 或 -comparer 的实现导致排序时出现错误。例如，将某个项与其自身进行比较时，comparer可能不返回 0
        /// </exception>
        /// <exception cref="InvalidOperationException">comparer 为 null，并且 keys <see cref="Array"/> 中的一个或多个元素未实现 <see cref="IComparable{T}"/> 泛型接口</exception>
        public static void Sort<TKey, TValue>(this TKey[] keys, TValue[] items, int index, int length, IComparer<TKey> comparer) => Array.Sort(keys, items, index, length, comparer);
        #endregion

        #region 基于第一个 System.Array 中的关键字，使用指定的 System.Collections.IComparer，对两个一维 System.Array 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序
        /// <summary>
        /// 基于第一个 <see cref="Array"/> 中的关键字，使用指定的 <see cref="IComparer"/>，对两个一维 <see cref="Array"/> 对象（一个包含关键字，另一个包含对应的项）的部分元素进行排序
        /// </summary>
        /// <param name="keys">一维 <see cref="Array"/>，它包含要排序的关键字</param>
        /// <param name="items">一维 <see cref="Array"/>，它包含与 keys <see cref="Array"/> 中的每一个关键字对应的项。- 或 -如果为 null，则只对 keys <see cref="Array"/> 进行排序</param>
        /// <param name="index">排序范围的起始索引</param>
        /// <param name="length">排序范围内的元素数</param>
        /// <param name="comparer">比较元素时要使用的 <see cref="IComparer"/> 实现。- 或 -若为 null，则使用每个元素的 <see cref="IComparable"/> 实现</param>
        /// <exception cref="ArgumentNullException">keys 为 null</exception>
        /// <exception cref="RankException">keys <see cref="Array"/> 是多维的。- 或 -items <see cref="Array"/> 是多维的</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 keys 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">
        /// items 不是 null，且 keys 的下限与 items 的下限不匹配。
        /// - 或 -items 不是 null，并且 keys 的长度与 items 的长度不匹配。
        /// - 或 -index 和 length 未指定 keys <see cref="Array"/> 中的有效范围。
        /// - 或 -items 不为 null，并且 index 和 length 未在 items <see cref="Array"/> 中指定有效范围。
        /// - 或 -comparer 的实现导致排序时出现错误。例如，将某个项与其自身进行比较时，comparer 可能不返回 0。
        /// </exception>
        /// <exception cref="InvalidOperationException">comparer 为 null，并且 keys <see cref="Array"/> 中的一个或多个元素不实现 <see cref="IComparable"/> 接口</exception>
        public static void Sort(this Array keys, Array items, int index, int length, IComparer comparer) => Array.Sort(keys, items, index, length, comparer);
        #endregion

        #region 使用指定的 System.Collections.IComparer，对一维 System.Array 中的元素进行排序
        /// <summary>
        /// 使用指定的 <see cref="IComparer"/>，对一维 <see cref="Array"/> 中的元素进行排序
        /// </summary>
        /// <param name="array">要排序的一维 <see cref="Array"/></param>
        /// <param name="comparer">比较元素时要使用的 <see cref="IComparer"/> 实现。- 或 -若为 null，则使用每个元素的 <see cref="IComparable"/> 实现</param>
        /// <exception cref="ArgumentNullException">keys 为 null</exception>
        /// <exception cref="RankException">keys <see cref="Array"/> 是多维的</exception>
        /// <exception cref="InvalidOperationException">comparer 为 null，array 中的一个或多个元素不实现 <see cref="IComparable"/> 接口</exception>
        /// <exception cref="ArgumentException">comparer 的实现导致排序时出现错误。例如，将某个项与其自身进行比较时，comparer 可能不返回 0</exception>
        public static void Sort(this Array array, IComparer comparer) => Array.Sort(array, comparer);
        #endregion

        #region 使用指定的 System.Collections.IComparer，对一维 System.Array 的部分元素进行排序
        /// <summary>
        /// 使用指定的 <see cref="IComparer"/>，对一维 <see cref="Array"/> 的部分元素进行排序
        /// </summary>
        /// <param name="array">要排序的一维 <see cref="Array"/></param>
        /// <param name="index">排序范围的起始索引</param>
        /// <param name="length">排序范围内的元素数</param>
        /// <param name="comparer">比较元素时要使用的 <see cref="IComparer"/> 实现。- 或 -若为 null，则使用每个元素的 <see cref="IComparable"/> 实现</param>
        /// <exception cref="ArgumentNullException">array 为 nul</exception>
        /// <exception cref="RankException">array 是多维数组</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 array 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">index 和 length 不指定 array 中的有效范围。- 或 -comparer 的实现导致排序时出现错误。例如，将某个项与其自身进行比较时，comparer 可能不返回 0</exception>
        /// <exception cref="InvalidOperationException">comparer 为 null，array 中的一个或多个元素不实现 <see cref="IComparable"/> 接口</exception>
        public static void Sort(this Array array, int index, int length, IComparer comparer) => Array.Sort(array, index, length, comparer);
        #endregion

        #region 使用指定的 System.Collections.Generic.IComparer<T> 泛型接口，对 System.Array 中的元素进行排序
        /// <summary>
        /// 使用指定的 <see cref="IComparer{T}"/> 泛型接口，对 <see cref="Array"/> 中的元素进行排序
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要排序的从零开始的一维 <see cref="Array"/></param>
        /// <param name="comparer">比较元素时使用的 <see cref="IComparer{T}"/> 泛型接口实现；如果为 null，则使用每个元素的 <see cref="IComparable{T}"/> 泛型接口实现</param>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="InvalidOperationException">comparer 为 null，并且 array 中的一个或多个元素未实现 <see cref="IComparable{T}"/> 泛型接口</exception>
        /// <exception cref="ArgumentException">comparer 的实现导致排序时出现错误。例如，将某个项与其自身进行比较时，comparer 可能不返回 0</exception>
        public static void Sort<T>(this T[] array, IComparer<T> comparer) => Array.Sort(array, comparer);
        #endregion

        #region 使用指定的 System.Collections.Generic.IComparer<T> 泛型接口，对 System.Array 中某个元素范围内的元素进行排序
        /// <summary>
        /// 使用指定的 <see cref="IComparer{T}"/> 泛型接口，对 <see cref="Array"/> 中某个元素范围内的元素进行排序
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要排序的从零开始的一维 <see cref="Array"/></param>
        /// <param name="index">排序范围的起始索引</param>
        /// <param name="length">排序范围内的元素数</param>
        /// <param name="comparer">比较元素时使用的 <see cref="IComparer{T}"/> 泛型接口实现；如果为 null，则使用每个元素的 <see cref="IComparable{T}"/> 泛型接口实现</param>
        /// <exception cref="ArgumentNullException">array 为 null</exception>
        /// <exception cref="ArgumentOutOfRangeException">index 小于 array 的下限。- 或 -length 小于零</exception>
        /// <exception cref="ArgumentException">index 和 length 不指定 array 中的有效范围。- 或 -comparer 的实现导致排序时出现错误。例如，将某个项与其自身进行比较时，comparer 可能不返回 0</exception>
        /// <exception cref="InvalidOperationException">comparer 为 null，并且 array 中的一个或多个元素未实现 <see cref="IComparable{T}"/> 泛型接口</exception>
        public static void Sort<T>(this T[] array, int index, int length, IComparer<T> comparer) => Array.Sort(array, index, length, comparer);
        #endregion

        #region 使用指定的 System.Comparison<T> 对 System.Array 中的元素进行排序
        /// <summary>
        /// 使用指定的 <see cref="Comparison{T}"/> 对 <see cref="Array"/> 中的元素进行排序
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要排序的从零开始的一维 <see cref="Array"/></param>
        /// <param name="comparison">比较元素时要使用的 <see cref="Comparison{T}"/></param>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -comparison 为 null</exception>
        /// <exception cref="ArgumentException">comparison 的实现导致排序时出现错误。例如，将某个项与其自身进行比较时，comparison 可能不返回 0</exception>
        public static void Sort<T>(this T[] array, Comparison<T> comparison) => Array.Sort(array, comparison);
        #endregion

        #region 确定数组中的每个元素是否都与指定谓词定义的条件匹配
        /// <summary>
        /// 确定数组中的每个元素是否都与指定谓词定义的条件匹配
        /// </summary>
        /// <typeparam name="T">数组元素的类型</typeparam>
        /// <param name="array">要对照条件进行检查的从零开始的一维 <see cref="Array"/></param>
        /// <param name="match"><see cref="Predicate{T}"/> 定义检查元素时要对照的条件</param>
        /// <returns>如果 array 中的每个元素都与指定谓词定义的条件匹配，则为 true；否则为 false。如果数组中没有元素，则返回值为 true</returns>
        /// <exception cref="ArgumentNullException">array 为 null。- 或 -match 为 null</exception>
        public static bool TrueForAll<T>(this T[] array, Predicate<T> match) => Array.TrueForAll(array, match);
        #endregion

        #region 将当前的 Byte[]序列转换为 System.Drawing.Image
        /// <summary>
        /// 将当前的Byte[]序列转换为 <see cref="Image"/> 对象
        /// </summary>
        /// <param name="value">要转换的Byte[]</param>
        /// <returns>转换后的  <see cref="Image"/></returns>
        public static Image ToImage(this byte[] value)
        {
            var ms = new MemoryStream(value);
            return Image.FromStream(ms);
        }
        #endregion

        #region 将当前的 Byte[] 序列转换为 Base64 编码的字符串
        /// <summary>
        /// 将当前的 Byte[] 序列转换为 Base64 编码的字符串
        /// </summary>
        /// <param name="value">要转换的Byte[]</param>
        /// <returns>转换后的字符串表示形式，以 Base64 表示</returns>
        public static string ToBase64String(this byte[] value)
        {
            return Convert.ToBase64String(value, 0, value.Length);
        }
        #endregion

        #region 将当前的 Byte[] 序列转换为图片的 Base64 编码的字符串
        /// <summary>
        /// 将当前的Byte[]序列转换为图片的 Base64 编码的字符串
        /// </summary>
        /// <param name="value">要转换的Byte[]</param>
        /// <returns>转换图片后的字符串表示形式，以 Base64 表示</returns>
        public static string ToImageBase64String(this byte[] value) => $"data:image/jpeg;base64,{Convert.ToBase64String(value, 0, value.Length)}";

        #endregion
    }
}
