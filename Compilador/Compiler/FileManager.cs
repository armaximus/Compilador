using System;
using System.IO;
using System.Windows.Forms;

namespace Main
{
    public class FileManager
    {
        private OpenFileDialog OpenFileDialog { get; set; }
        public string FilePath { get; set; }

        public string FileContent
        {
            get
            {
                if (!FileOpenExists())
                    throw new FileNotFoundException("Nenhum arquivo aberto");

                StreamReader streamReader = new StreamReader(FilePath);
                string text = streamReader.ReadToEnd();
                streamReader.Close();
                return text;
            }
        }

        public bool OpenFile()
        {
            return OpenFile("Text|*.txt");
        }

        public bool OpenFile(string filter)
        {
            OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = filter;

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = OpenFileDialog.FileName;
                return true;
            }

            return false;
        }

        public void SaveFile(string fileText)
        {
            if (FileOpenExists())
            {
                WriteFile(FilePath, fileText);
            }
            else
            {
                string path = SelectPathToSave();
                CreateFile(path);
                WriteFile(path, fileText);
                FilePath = path;
            }
        }

        private bool FileOpenExists()
        {
            return File.Exists(FilePath);
        }

        private void WriteFile(string path, string fileText)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(fileText);
                writer.Close();
            }
        }

        private string SelectPathToSave()
        {
            return SelectPathToSave("Text|*.txt");
        }

        private string SelectPathToSave(string filter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                return saveFileDialog.FileName;

            return string.Empty;
        }

        private void CreateFile(string path)
        {
            File.Create(path).Close();
        }

        public void Create(string content)
        {
            string fileName = string.Empty;

            if (string.IsNullOrWhiteSpace(FilePath))
                fileName = SelectPathToSave("ILASM|*.il");
            else
                fileName = FilePath.Substring(0, FilePath.Length - 4) + ".il";

            if (File.Exists(fileName))
                File.Delete(fileName);

            CreateFile(fileName);
            WriteFile(fileName, content);
        }
    }
}
