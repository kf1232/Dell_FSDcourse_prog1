using p1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace p1.IO
{
    class FileManager : iFileManager
    {
        private string _filename;

        public FileManager(string filename)
        {
            _filename = filename;
        }

        public IEnumerable<Teacher> Load()
        {
            var fileReader = File.ReadAllLines(_filename);
            var teachers = new List<Teacher>();
            foreach ( var x in fileReader)
            {
                var part = x.Split(',');
                try
                {
                    var teacher = new Teacher(Int32.Parse(part[0]), part[1], Int32.Parse(part[2]), part[3]);
                    teachers.Add(teacher);
                }
                catch
                {
                    Console.WriteLine(@$"Cannot Load Teacher from File:");
                    Console.WriteLine($@"     {part[0]}{part[1]}{part[2]}{part[3]}");
                    Console.WriteLine("Press any key to continue.");
                    Console.Read();
                }
            }
            return teachers;
        }

        public void Save(IEnumerable<Teacher> teachers)
        {
            var csvTeacherList = new List<string>();
            foreach( var t in teachers)
            {
                var csvTeacher = $@"{t.id},{t.name},{t.classID},{t.className}";
                csvTeacherList.Add(csvTeacher);
            }
            File.WriteAllLines(_filename, csvTeacherList);
        }
    }
}