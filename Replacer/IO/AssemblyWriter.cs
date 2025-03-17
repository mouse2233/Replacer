namespace Replacer
{
    internal class AssemblyWriter
    {
        public void Write(string path, string text)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                file.Write(text);
            }
        }
    }
}
