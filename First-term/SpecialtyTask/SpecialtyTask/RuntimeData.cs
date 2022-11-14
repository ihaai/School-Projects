using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLTask
{
    public class RuntimeData
    {
        public int ID { get; set; }

        public string Specialty { get; set; }

        public int Variant { get; set; }

        public string FileLocation { get; set; }

        public override string ToString()
        {
            return $"{ID} || {Specialty} || {Variant} || {FileLocation}";
        }
    }
}
