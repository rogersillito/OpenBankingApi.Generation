using System.IO;
using System.Reflection;

namespace ApiGenerator.NSwagWrapper
{
    public interface IPrefixSourceCode
    {
        string AddPrefixTemplate(string sourceCode, string templateResourcePath = "ApiGenerator.FilePrefixTemplate.txt");
    }

    public class CSharpCodePrefixer : IPrefixSourceCode
    {
        public string AddPrefixTemplate(string sourceCode, string templateResourcePath = "ApiGenerator.FilePrefixTemplate.txt")
        {
            var template = ReadResourceFileContents(templateResourcePath);
            return template + sourceCode;
        }

        private static string ReadResourceFileContents(string resourcePath)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string result;
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}