using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using p1.Classes;

namespace p1.IO
{
    public interface iFileManager
    {
        void Save(IEnumerable<Teacher> teachers);
        IEnumerable<Teacher> Load();
    }
}
