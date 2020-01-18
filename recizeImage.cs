private ImageCodecInfo GetEncoder(ImageFormat format)
{
    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
    foreach (ImageCodecInfo codec in codecs)
    {
        if (codec.FormatID == format.Guid)
        {
            return codec;
        }
    }
    return null;
}

private void Resize(Stream img, int novaLargura, string nomeArquivo)
{
    // Cria um objeto de imagem baseado no stream do arquivo enviado
    Bitmap originalBMP = new Bitmap(img);

    // Calcula a nova dimensao da imagem
    int origWidth = originalBMP.Width;
    int origHeight = originalBMP.Height;
    double sngRatio = (double)novaLargura / origWidth;
    int newWidth = novaLargura;
    int newHeight = Convert.ToInt32(origHeight * sngRatio);

    // Cria uma nova imagem a partir da imagem original
    Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);

    // Grava a nova imagem no servidor
    Encoder myEncoder = Encoder.Quality;
    EncoderParameters myEncoderParameters = new EncoderParameters(1);
    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
    myEncoderParameters.Param[0] = myEncoderParameter;
    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
    newBMP.Save(nomeArquivo, jpgEncoder, myEncoderParameters);

    // Retira os objetos da memória
    originalBMP.Dispose();
    newBMP.Dispose();
}