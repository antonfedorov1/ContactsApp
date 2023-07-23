namespace ContactsApp.View
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    /// <summary>
    /// Компрессор изображений.
    /// </summary>
    public class ImageCompressor
    {
        /// <summary>
        /// Уровень качества.
        /// </summary>
        private int _qualityLevel = 20;

        /// <summary>
        /// Компрессор.
        /// </summary>
        /// <param name="path">Путь к изображению.</param>
        /// <returns>Путь к сжатому изображению.</returns>
        public string Compressor(string path)
        {
            using (Bitmap bmp1 = new Bitmap(path))
            {
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                string pathToCopiedFile = Path.Combine(Path.GetDirectoryName(path), "PhotoForContactsApp.jpg");

                myEncoderParameters.Param[0] = new EncoderParameter(myEncoder, _qualityLevel);
                File.Copy(path, pathToCopiedFile, true);
                bmp1.Save(pathToCopiedFile, jpgEncoder, myEncoderParameters);
                return pathToCopiedFile;
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
