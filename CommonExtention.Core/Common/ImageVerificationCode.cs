using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace CommonExtention.Core.Common
{
    /// <summary>
    /// 图片验证码。此类不可被继承
    /// </summary>
    public sealed class ImageVerificationCode
    {
        #region 构造函数
        /// <summary>
        /// 初始化 <see cref="ImageVerificationCode"/> 类的新实例
        /// </summary>
        /// <param name="number">验证码数量</param>
        public ImageVerificationCode(int number = 4)
        {
            _Number = number;
            Code = BuildRandomCode();
        }
        #endregion

        #region 私有属性

        /// <summary>
        /// 验证码数量
        /// </summary>
        private int _Number { set; get; }

        /// <summary>
        /// 验证码字符
        /// </summary>
        private readonly string _VerificationChar = "0123456789abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPPQRSTUVWXYZ";

        #endregion

        #region 公有属性
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { private set; get; }
        #endregion

        #region 构建随机验证码
        /// <summary>
        /// 构建随机验证码
        /// </summary>
        /// <returns>随机验证码</returns>
        private string BuildRandomCode()
        {
            var code = string.Empty;
            var random = new Random();
            for (int i = 1; i < _Number + 1; i++)
            {
                code += _VerificationChar[random.Next(0, 61)];
            }
            return code;
        }
        #endregion

        #region 生成图片验证码
        /// <summary>
        /// 生成图片验证码
        /// </summary>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <param name="fontSize">字体大小(单位：em)</param>
        /// <param name="fontFamily">字体</param>
        /// <param name="backgroundColor">背景色</param>
        /// <param name="lineNumber">干扰线数量</param>
        /// <param name="lineColor">干扰线颜色</param>
        /// <param name="drawPoint">是否画干扰点</param>
        /// <param name="dotNumber">干扰点数量</param>
        /// <returns><see cref="MemoryStream"/> 表示形式的图片验证码</returns>
        public MemoryStream CreateImage(
            int width = 100,
            int height = 40,
            float fontSize = 20,
            string fontFamily = "Microsoft YaHei",
            KnownColor backgroundColor = KnownColor.White,
            int lineNumber = 25,
            KnownColor lineColor = KnownColor.Black,
            bool drawPoint = true,
            int dotNumber = 100)
        {
            var image = new Bitmap(width, height);
            var graphics = Graphics.FromImage(image);
            var random = new Random();

            graphics.Clear(Color.FromKnownColor(backgroundColor));
            for (int i = 0; i < lineNumber; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                graphics.DrawLine(new Pen(Color.FromKnownColor(lineColor), 1), x1, y1, x2, y2);
            }

            var font = new Font(fontFamily, fontSize, (FontStyle.Bold | FontStyle.Italic));
            var brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
            graphics.DrawString(Code, font, brush, 2, 2);

            if (drawPoint)
            {
                for (int i = 0; i < dotNumber; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
            }

            graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            var memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            return memoryStream;
        }
        #endregion
    }
}
