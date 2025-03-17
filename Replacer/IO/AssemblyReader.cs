namespace Replacer
{
    //Нужен для чтения файла сборки
    internal class AssemblyReader
    {
        public string Read(string path) {
            using (System.IO.StreamReader reader = System.IO.File.OpenText(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
