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
        /// <param name="strImg">Картинка в строке.</param>
        /// <returns>Картинка.</returns>
        public Image StrToImg(string strImg)
        {
            if (strImg == null)
            {
                return Properties.Resources.photo_placeholder_100x100;
            }
            byte[] arrayimg = Convert.FromBase64String(strImg);
            Image imageStr = Image.FromStream(new MemoryStream(arrayimg));
            return imageStr;
        }

        /// <summary>
        /// Преобразование картинки в строку.
        /// </summary>
        /// <param name="fileName">Картинка.</param>
        /// <returns>Строка.</returns>
        public string ImgToStr(string fileName)
        {
            if (fileName == null)
            {
                return null;
            }
            MemoryStream memostr = new MemoryStream();
            Image img = Image.FromFile(fileName);
            img.Save(memostr, img.RawFormat);
            img.Dispose();
            var arrayimg = memostr.ToArray();
            return Convert.ToBase64String(arrayimg);
        }
    }
}
