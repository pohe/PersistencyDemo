using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistencyDemo
{

    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int NO { get; set; }

        public Person(string name, string mobile, int no)
        {
            Name = name;
            Mobile = mobile;
            NO = no;
        }
    }
}
