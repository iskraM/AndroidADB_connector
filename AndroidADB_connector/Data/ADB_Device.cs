using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidADB_connector.Data
{
    internal class ADB_Device
    {
        public string DeviceID { get; set; }
        public string DeviceName { get; set; }

        private string _ip;
        public string IP 
        {
            get { return _ip; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _ip = value;
                else
                    _ip = "NOT CONNECTED";
            }
        }
        private int _port;
        public int Port 
        {
            get { return _port; }
            set
            {
                _port = value;
                this.Status = true;
            }
        }
        public bool Status { get; set; }
    }
}
