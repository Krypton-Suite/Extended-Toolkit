namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class ImageOperations
    {
        public static string GetImageHtml(byte[] bytes, string imageType = "png")
        {
            var b64 = Convert.ToBase64String(bytes);
            return $"<img src=\"data:image/{imageType};base64,{b64}\"></img>";
        }
    }
}