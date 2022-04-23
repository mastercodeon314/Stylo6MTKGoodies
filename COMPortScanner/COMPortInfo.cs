using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPortScanner
{
    public class COMPortInfo
    {
        private string _portDescription;
        private string _portNumber;

        public string PortNumber { get { return _portNumber; } set { _portNumber = value; } }
        public string PortDescription { get { return _portDescription; } set { _portDescription = value; } }


        public string FriendlyName
        {
            get
            {
                return _portDescription + " (COM" + _portNumber + ")";
            }
        }

        public string PortName
        {
            get
            {
                return "COM" + _portNumber;
            }
        }

        public COMPortInfo(string num, string desc)
        {
            this.PortNumber = num;
            this.PortDescription = desc;
        }        
    }
}
