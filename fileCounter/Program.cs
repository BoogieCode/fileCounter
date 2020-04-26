using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {              
                //Console.Write("Enter path of file you want to rename: ");
                //string s = Console.ReadLine();

                //Get files from a folder
                List<FileInfo> dirs = new DirectoryInfo(@"C:\\Users\\Boogie\\Desktop\\all").GetFiles()
                                                  .OrderBy(f => f.LastWriteTime)
                                                  .ToList();
                const string path = @"C:\\Users\\Boogie\\Desktop\\all";

                //Informations about rename
                Console.WriteLine("The number of files in {0} is {1}.", path, dirs.Count);


                //Rename files
                int fileName = 1;
                string currentPath, extention, newPath, auxiliarPath;
                foreach (FileInfo dir in dirs)
                {
                    currentPath = dir.FullName;

                    extention = dir.Extension;
                    newPath = path + "/" + fileName + "" + extention;
                    auxiliarPath = path + "/newName" + extention;
                   

                    File.Move(currentPath, auxiliarPath);

                    File.Move(auxiliarPath, newPath);

                    Console.WriteLine("File: " + dir.Name + " was changed in " + fileName + "" + extention);

                    fileName++;
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("A problem occured and the process failed: {0}", e.ToString());
                Console.ReadLine();
            }
        }
    }
}
