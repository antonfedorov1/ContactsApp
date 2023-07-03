namespace ContactsApp.View
{
    using System;
    using System.Drawing;
    using System.IO;

    public class ConvertingImgToStrAndBack
    {
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
