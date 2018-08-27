using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    public class ManualTestOptions
    {

        public string Name { get; set; }
        public ManualTestOptions(string name)
        {
            this.Name = name;
        }
    }
}
