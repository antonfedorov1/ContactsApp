namespace ContactsApp.View
{
    using System;
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// Преобразование Image в String и обратно.
    /// </summary>
    public class ConvertingImgToStrAndBack
    {
        /// <summary>
        /// Преобразование строки в картинку.
        /// </summary>
        /// <param name="StrImg">Картинка в строке.</param>
        /// <returns>Картинка.</returns>
        public Image StrToImg(string StrImg)
        {
            if (StrImg == null)
            {
                return Properties.Resources.photo_placeholder_100x100;
            }
            byte[] arrayimg = Convert.FromBase64String(StrImg);
            Image imageStr = Image.FromStream(new MemoryStream(arrayimg));
            return imageStr;
        }

        /// <summary>
        /// Преобразование картинки в строку.
        /// </summary>
        /// <param name="filename">Картинка.</param>
        /// <returns>Строка.</returns>
        public string ImgToStr(string filename)
        {
            MemoryStream Memostr = new MemoryStream();
            Image Img = Image.FromFile(filename);
            Img.Save(Memostr, Img.RawFormat);
            byte[] arrayimg = Memostr.ToArray();
            return Convert.ToBase64String(arrayimg);
        }
    }
}
