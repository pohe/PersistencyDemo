using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PersistencyDemo
{
    public class SerializationDemo
    {

        public static void Serialization()
        {

            MyObject obj = new MyObject();
            obj.n1 = 1;
            obj.n2 = 24;
            obj.str = "Some String";

            IFormatter formatter = null;
            Stream stream = null;
            try
            {
                formatter = new BinaryFormatter();
                stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, obj);
            }

            catch (SerializationException sex)
            {
                Console.WriteLine("Serialization error");
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error when serializing the object");
            }

            finally
            {
                if (stream != null)
                    stream.Close();

            }

        }

        public static void Deserialization()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            MyObject obj = null;
            try
            {
                stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                obj = (MyObject)formatter.Deserialize(stream);

            }
            catch (SerializationException ser)
            {
                Console.WriteLine("Serialization error");
            }
            catch (IOException iox)
            {
                Console.WriteLine("IO error");
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }


            // Here's the proof.  
            Console.WriteLine($"n1: {obj.n1}");
            Console.WriteLine($"n2: {obj.n2}");
            Console.WriteLine($"str: {obj.str}");
        }




        public static void SerializePersons()
        {
            Person p1 = new Person("Poul", "1231231", 2);
            Person p2 = new Person("Charlotte", "66666", 3);
            Person p3 = new Person("Michael", "555", 4);

            List<Person> personer = new List<Person>();
            personer.Add(p1);
            personer.Add(p2);
            personer.Add(p3);


            IFormatter formatter = null;
            Stream stream = null;
            try
            {
                formatter = new BinaryFormatter();
                stream = new FileStream("MyPersons.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, personer);
            }

            catch (SerializationException sex)
            {
                Console.WriteLine("Serialization error");
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error when serializing the object");
            }

            finally
            {
                if (stream != null)
                    stream.Close();

            }


        }




        public static void DeserializationPersons()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            List<Person> people = null;
            try
            {
                stream = new FileStream("MyPersons.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                people = (List<Person>)formatter.Deserialize(stream);

            }
            catch (SerializationException ser)
            {
                Console.WriteLine("Serialization error");
            }
            catch (IOException iox)
            {
                Console.WriteLine("IO error");
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }


            // Here's the proof.  
            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name}  {person.Mobile} {person.NO}");
            }
        }




    }
}
