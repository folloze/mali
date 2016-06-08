using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Collections;
using System.Text;
using System.Configuration;

namespace WebApplication2
{
    public class ApplicationSettings : ConfigurationSection
    {
        [ConfigurationProperty("path", DefaultValue = "", IsRequired = false)]
        public string path
        {
            get
            {
                return (string)this["path"];
            }
            set
            {
                this["path"] = value;
            }
        }
    }
}