using System;
using System.IO;

namespace WorkWithFile
{
    internal class Program
    {
        const string MyPath = "C:\\Users\\user\\Downloads";
        static void Main(string[] args)
        {
           GetFiles(MyPath);
        }

        public static void GetFiles(string MyPath)
        {
            var file=new DirectoryInfo(MyPath);
            var files = file.GetFiles();
            string path = "";

            foreach (var f in files) 
            {
               Console.WriteLine(f);

               if (!f.ToString().Contains("."))
                {
                    continue;
                }

               if (f.ToString().Split('.')[1].ToLower()=="jpg" || f.ToString().Split('.')[1].ToLower() == "png" || f.ToString().Split('.')[1].ToLower() == "gif" || f.ToString().Split('.')[1].ToLower() == "mov" || f.ToString().Split('.')[1].ToLower() == "heic" || f.ToString().Split('.')[1].ToLower() == "jpeg")
                {
                    CreateFolder("Photos",f);
                }

               else if ( f.ToString().Split('.')[1].ToLower() == "xlsx")
                {
                    CreateFolder("Excel",f);
                }


               else if (f.ToString().Split('.')[1].ToLower() == "docx")
                {
                    CreateFolder("Word",f);
                }

                else if (f.ToString().Split('.')[1].ToLower() == "mp4")
                {
                    CreateFolder("Video",f);
                }


                else if (f.ToString().Split('.')[1].ToLower() == "pptx")
                {
                    CreateFolder("PowerPoint",f);
                }

                else if (f.ToString().Split('.')[1].ToLower() == "zip")
                {
                    CreateFolder("Zip",f);
                }

                else if (f.ToString().Split('.')[1].ToLower() == "pdf")
                {
                    CreateFolder("Pdf", f);
                }
                else
                {
                    CreateFolder("Others",f);
                }




            }
        }

        public static void CreateFolder(string name, FileInfo a)
        {
            var path = MyPath + $"\\{name}";
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.Move(a.FullName,path+"\\"+a.Name);
        }


    }
}
