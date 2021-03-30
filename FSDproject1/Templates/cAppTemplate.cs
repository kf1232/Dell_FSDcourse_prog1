using p1.Classes;
using p1.IO;
using p1.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace p1.Templates
{
    class cAppTemplate : aAppTemplate
    {
        // User Input
        protected override int getAction()
        {
            try
            {
                int input = Int32.Parse(Console.ReadLine());
                return input;
            }
            catch
            {
                return -1;
            }
            
        }

        public static void printError(string x)
        {
            Console.WriteLine(x);
            Console.ReadKey();
        }

        // File Management
        protected override void saveTeachers()
        {
            string fPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fileName = @$"{fPath}\teachers.txt";
            try
            {
                var teachersRepository = new FileManager(fileName);
                List<Teacher> tList = _teachers.Values.ToList();
                teachersRepository.Save(tList);
                Console.WriteLine("Data written to file.");
            }
            catch
            { printError("Unable to write to file."); }
        }
        protected override void loadTeachers()
        {
            string fPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fileName = @$"{fPath}\teacher.txt";
            try
            {
                var teachersRepository = new FileManager(fileName);
                var teachersAsList = teachersRepository.Load();
                _teachers = teachersAsList.ToDictionary(t => t.id);
                Console.WriteLine($"Loaded {_teachers.Count} teachers");
            }
            catch
            { printError($@"Unable to load {fileName}. Press any key to continue."); }
        }

        
        // User Management
        protected override void addTeachers()
        {
            var teacherBuilder = new cTeacherBuilder();
            var teacher = teacherBuilder.Build();
            if (_teachers.ContainsKey(teacher.id))
                Console.WriteLine("User ID is invalid. Request canceled. ");
            else
                _teachers[teacher.id] = teacher;
        }
        protected override void editTeachers()
        {
            var working = true;
            while (working)
            {
                Console.WriteLine("Enter Employee ID to edit:");
                Console.WriteLine("Enter -1 to exit editing:");
                try
                {
                    int id = Int32.Parse(Console.ReadLine());
                    if (id == -1)
                        working = false;
                    else if (_teachers.ContainsKey(id))
                    {
                        var editing = true;
                        while (editing)
                        {
                            printEdit(id);
                            try
                            {
                                int input = Int32.Parse(Console.ReadLine());
                                switch (input)
                                {
                                    case 1:
                                        Console.WriteLine("Enter new name:");
                                        Console.WriteLine($"Current class ID: {_teachers[id].name}");
                                        _teachers[id].name = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter new Class ID:");
                                        Console.WriteLine($"Current class ID: {_teachers[id].classID}");
                                        try
                                        {
                                            _teachers[id].classID = Int32.Parse(Console.ReadLine());
                                        }
                                        catch { Console.WriteLine("Invalid input.");  }
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter new class name:");
                                        Console.WriteLine($"Current class name: {_teachers[id].className}");
                                        _teachers[id].className = Console.ReadLine();
                                        break;
                                    case 4: editing = false; break;
                                    default: Console.WriteLine("Invalid input."); break;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Invalid input.");
                            }
                        }
                    }
                    else { Console.WriteLine("Invalid ID."); }
                }
                catch { Console.WriteLine("Invalid input."); }
            }
        }
        protected override void removeTeacher()
        {
            var working = true;
            while (working)
            {
                Console.WriteLine("Enter Employee ID to remove:");
                Console.WriteLine("Enter -1 to exit editing:");
                try
                {
                    int id = Int32.Parse(Console.ReadLine());
                    if (id == -1)
                        working = false;
                    else if (_teachers.ContainsKey(id))
                    {
                        _teachers.Remove(id);
                    }
                    else { Console.WriteLine("Invalid ID."); }
                }
                catch { Console.WriteLine("Invalid input."); }
            }
        }

        private void printEdit(int id)
        {
            Console.WriteLine("Select and option from below [1-x]: ");
            Console.WriteLine("1: Edit Teacher Name");
            Console.WriteLine("2: Edit Class ID");
            Console.WriteLine("3: Edit Class Name");
            Console.WriteLine(@$"4: Finish Editing {id}");
        }













    }
}
