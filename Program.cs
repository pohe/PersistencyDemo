using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistencyDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    FileDemo.Run5();
            //}
            //catch (IOException ioe)
            //{
            //    Console.WriteLine("Noget gik helt galt.");
            //}

            //SerializationDemo.Serialization();
            //SerializationDemo.Deserialization();
            SerializationDemo.DeserializationPersons();


            Console.ReadLine();
        }
    }
}
