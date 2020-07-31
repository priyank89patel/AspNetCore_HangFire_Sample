using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_HangFire_Sample.Models
{
    public class BackgroundJobParameters
    {
        public string Name { get; set; }
        public string ExePath { get; set; }
        public string Arguments { get; set; }
        public string WorkingDirectory { get; set; }
    }
}
