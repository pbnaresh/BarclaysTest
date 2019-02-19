using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    //create this for referring in DI if implemented and make it loosly coupled 
     interface IConfigSettings
    {
        string[] GetConfigValuesByKey(string configKey);
    }
}
