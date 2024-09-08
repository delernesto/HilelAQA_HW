namespace Course_Final_Hw.Infrastucture
{
    internal class HelperMethod
    {
        internal static string GetProjectFilePath()
        {
            string pathFile = Directory.GetCurrentDirectory();
            int index = pathFile.IndexOf("bin");
            if (index >= 0)
            {
                pathFile = pathFile.Remove(index);
            }
            return pathFile.Replace("\\", "/");
        }
    }
}
