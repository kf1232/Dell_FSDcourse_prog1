using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p1.Classes;

namespace p1.Builders
{
    public abstract class aTeacherBuilder
    {
        protected abstract void BuildID( Teacher teacher);
        protected abstract void BuildName(Teacher teacher);
        protected abstract void BuildClassID(Teacher teacher);
        protected abstract void BuildClassName(Teacher teacher );
        
        public Teacher Build()
        {
            var teacher = new Teacher();
            BuildID(teacher);
            BuildName(teacher);
            BuildClassID(teacher);
            BuildClassName(teacher);
            Console.WriteLine(teacher.ToString());
            return teacher;
        }
    }
}
