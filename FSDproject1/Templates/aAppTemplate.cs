using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p1.Classes;

namespace p1.Templates
{
    public abstract class aAppTemplate
    {
        protected Dictionary<int, Teacher> _teachers = new Dictionary<int, Teacher>();

        public void Run()
        {
            int input = 0;
            var exit = false;
            while (!exit)
            {
                printMenu();
                printPrior(input);
                input = getAction();
                switch (input)
                {
                    case 1: loadTeachers();  break;
                    case 2: saveTeachers(); break;
                    case 3: addTeachers(); break;
                    case 4: editTeachers(); break;
                    case 5: removeTeacher(); break;
                    case 6: exit = true; break;
                    default: input = -1; break;
                }
            }
        }
            
            
            
        // Menus
        private void printMenu()
        {
            Console.Clear();
            Console.WriteLine("Select and option from below [1-x]: ");
            Console.WriteLine("1: Load Teachers");
            Console.WriteLine("2: Save Teachers");
            Console.WriteLine("3: Add Teacher");
            Console.WriteLine("4: Edit Teacher");
            Console.WriteLine("5: Remove Teacher");
            Console.WriteLine("6: Quit");
        }
        private void printPrior(int value)
        {
            if ( value == -1 )
               Console.WriteLine($@"{value}: Invalid input, please try again.");
        }
        protected abstract int getAction();


        // File Management
        protected abstract void loadTeachers();
        protected abstract void saveTeachers();


        // Entery Management
        protected abstract void editTeachers();
        protected abstract void addTeachers();
        protected abstract void removeTeacher();
    }
}
