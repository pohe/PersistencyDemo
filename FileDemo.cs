using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistencyDemo
{
    public class FileDemo
    {
        public static void Run1()
        {
            FileStream F = new FileStream("test.dat", FileMode.OpenOrCreate,
                FileAccess.ReadWrite);

            for (int i = 1; i <= 20; i++)
            {
                F.WriteByte((byte)i);
            }
            F.Position = 0;
            for (int i = 0; i <= 20; i++)
            {
                Console.Write(F.ReadByte() + " ");
            }
            F.Close();
            Console.ReadKey();
        }


        public static void Run2()
        {
            // Get the directories currently on the C drive.
            DirectoryInfo[] cDirs = new DirectoryInfo(@"c:\").GetDirectories();

            // Write each directory name to a file.
            using (StreamWriter sw = new StreamWriter("CDriveDirs.txt"))
            {
                foreach (DirectoryInfo dir in cDirs)
                {
                    sw.WriteLine(dir.Name);

                }
            }

            // Read and show each line from the file.
            string line = "";
            using (StreamReader sr = new StreamReader("CDriveDirs.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static void Run3()
        {
            string[] names = new string[5];
            Console.WriteLine("Enter 5 names to a text file:");
            for (int i = 0; i < 5; i++)
            {
                names[i] = Console.ReadLine();
            }
            StreamWriter SW = new StreamWriter(@"names.txt");
            for (int i = 0; i < 5; i++)
            {
                SW.WriteLine(names[i]);
            }
            SW.Close();

        }

        public static void Run4()
        {
            string[] input_names = new string[5];
            Console.WriteLine("Reading 5 names from a text file:");
            StreamReader SR = null;
            try
            {
                SR = new StreamReader(@"names.txt");
                for (int i = 0; i < 5; i++)
                {
                    input_names[i] = SR.ReadLine();
                }
            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine("Noget gik galt " + fex.Message);
            }
            catch (IOException iox)
            {
                Console.WriteLine("Noget gik galt " + iox.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemer " + ex.Message);
            }
            finally
            {
                if (SR!= null)
                    SR.Close();
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(input_names[i]);
            }

        }


        public static void Run5()
        {
            FileStream toStream = null;
            StreamWriter fileWriter = null;
            try
            {
                if (File.Exists("data.txt"))
                {
                    File.Delete("data.txt");
                }
                toStream = new FileStream("data.txt", FileMode.Create, FileAccess.Write, FileShare.Write);
                fileWriter = new StreamWriter(toStream);
                fileWriter.WriteLine("This");
                fileWriter.WriteLine("is not");
                fileWriter.WriteLine("a");
                fileWriter.WriteLine("test!");
            }
            catch (FileNotFoundException flnExp)
            {
                Console.WriteLine("File not found Exception " + flnExp.Message);
            }
            catch (IOException io)
            {
                Console.WriteLine("General file Exception " + io.Message);
            }
            finally
            {
                if (fileWriter != null)
                    fileWriter.Close(); //notice you have to close the StreamWriter before the FileStream
                if (toStream != null)
                    toStream.Close();

            }




            FileStream fromStream = null;
            StreamReader filReader = null;
            try
            {
                fromStream = new FileStream("data2.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
                filReader = new StreamReader(fromStream);
                while (!filReader.EndOfStream)
                {
                    Console.WriteLine(filReader.ReadLine());
                }
            }
            //catch (FileNotFoundException flnExp)
            //{
            //    Console.WriteLine("File not found Exception " + flnExp.Message);
            //}
            catch (IOException e)
            {
                throw e;
            }
            finally
            {
                if (filReader != null)
                    filReader.Close();  //notice you have to close the StreamWriter before the FileStream
                if (toStream != null)
                    toStream.Close();
            }
            Console.ReadLine();




        }

    }
}
