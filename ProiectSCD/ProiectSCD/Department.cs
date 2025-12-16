using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectSCD
{
    class Department
    {
        public int id { get; set; } = 0;
        public string name { get; set; } = string.Empty;
        public int parentId { get; set; } = 0;

        public List<Doctor> doctors { get; set; } = new List<Doctor>();
    }
}
