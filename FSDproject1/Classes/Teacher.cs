using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1.Classes
{
    public class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public int classID { get; set; }
        public string className { get; set; }
        public Teacher() { }
        public Teacher( int a, string b, int c, string d)
        {
            id = a;
            name = b;
            classID = c;
            className = d;
        }
        public override string ToString()
        {
            return $@"ID: {id}, Name: {name}, Class ID: {classID}, Class Name: {className}";
        }
    }
}
