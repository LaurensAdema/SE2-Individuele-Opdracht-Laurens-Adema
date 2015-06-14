using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Tweakers
{
    public class OS
    {
        public OS(int osid, string osString)
        {
            this.OSID = osid;
            this.OSString = osString;
        }

        public int OSID { get; set; }

        public string OSString { get; set; }
    }
}
