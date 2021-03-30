using p1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1.Builders
{
    public class cTeacherBuilder : aTeacherBuilder
    {
        protected override void BuildClassID(Teacher teacher)
        {
            Console.WriteLine("Enter Class ID number: ");
            try
            {
               teacher.classID = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid Class ID entered, enter Class ID number.");
                BuildClassID(teacher);
            }
            
        }

        protected override void BuildClassName(Teacher teacher)
        {
            Console.WriteLine("Enter class name: ");
            teacher.className = Console.ReadLine();
        }

        protected override void BuildID(Teacher teacher)
        {
            Console.WriteLine("Enter employee ID number: ");
            try
            {
                teacher.id = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid Employee ID entered, enter Employee ID number.");
                BuildID(teacher);
            }
        }

        protected override void BuildName(Teacher teacher)
        {
            Console.WriteLine("Enter employee name: ");
            teacher.name = Console.ReadLine();
        }
    }
}
