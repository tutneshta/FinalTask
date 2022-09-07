using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Security.Principal;

namespace FinalTask
{
    class Program
    {


        static async Task Main(string[] args)
        {

            string Filepath = @"C:\Users\s.bury\Desktop\Students.dat";

            CreateStudentOnDesktop(Filepath);

        }

        public static void CreateStudentOnDesktop(string Filepath)
        {
            string DirPath = @"C:\Users\s.bury\Desktop\Students\";

            DirectoryInfo directoryInfo = new DirectoryInfo(DirPath);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(Filepath, FileMode.OpenOrCreate))
            {
                Student[] student = (Student[])formatter.Deserialize(fs);

                for (int i = 0; i < student.Length; i++)
                {
                    using (StreamWriter writer = new StreamWriter($"{DirPath}{student[i].Group}.txt", true))
                    {
                        writer.WriteLine($"{student[i].Name}, {student[i].DateOfBirth}");
                    }

                }
            }

        }
    }

}
