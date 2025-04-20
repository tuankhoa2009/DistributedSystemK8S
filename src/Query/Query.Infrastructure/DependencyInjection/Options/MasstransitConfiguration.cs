using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quary.Infrastructure.DependencyInjection.Options
{
    public class MasstransitConfiguration
    {
        public string Host { get; set; }
        public string VHost { get; set; }
        public ushort Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
