using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    class CreateReport
    {
        public string _author { get; set; }
        public string _buildVersion { get; set; }
        public string _date { get; set; }
        public string _priority { get; set; }
        public string _type { get; set; }
        public string _state { get; set; }

        public CreateReport(string author, string buildVersion, string date, string priority, string type, string state)
        {
            this._author = author;
            this._buildVersion = buildVersion;
            this._date = date;
            this._priority = priority;
            this._state = state;
            this._type = type;
        }
    }
}
