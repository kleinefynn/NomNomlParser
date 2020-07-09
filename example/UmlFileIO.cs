using System.Collections.Generic;
using System.IO;
using NomNoml.Languages;

namespace NomNoml
{
    public class UmlFileIO
    {
        public static string LoadUmlFromFile(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            using (StreamReader sr = File.OpenText(path))
                return sr.ReadToEnd();
        }

        public static bool WriteToFile(string outputFolder, IEnumerable<Class> classes)
        {
            string backupFolder = outputFolder + "backup";
            if (Directory.Exists(outputFolder))
            {
                if(Directory.Exists(backupFolder))
                    Directory.Delete(backupFolder, true);
                
                Directory.Move(
                    outputFolder,
                    backupFolder
                    );
            }
            Directory.CreateDirectory(outputFolder);
            

            foreach (var c in classes)
            {
                using (StreamWriter sw = File.CreateText(
                    $"{outputFolder}/{c.Name}.cs")
                )
                    sw.Write(c.ToCode());
            }
            return false;
        }
    }
}