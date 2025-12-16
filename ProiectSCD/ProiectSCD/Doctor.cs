using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectSCD
{
    public class Doctor
    {
        public int id { get; set; } = 0;
        public string name { get; set; } = string.Empty;
        public string specialization { get; set; } = string.Empty;


        public List<Shift> shifts { get; set; } = new List<Shift>();
    }
}
