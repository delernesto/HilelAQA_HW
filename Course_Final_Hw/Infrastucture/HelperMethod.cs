namespace Course_Final_Hw.Infrastucture
{
    internal class HelperMethod
    {
        internal static string GetProjectFilePath()
        {
            string pathFile = Directory.GetCurrentDirectory();
            return pathFile;
        }
    }
}
