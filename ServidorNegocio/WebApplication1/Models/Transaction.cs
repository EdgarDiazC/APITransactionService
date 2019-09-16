using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Transaction
    {

        public long id { get; set; }
        public string titular { get; set; }
        public string nif { get; set; }
        public string cuenta { get; set; }
        public float importe { get; set; }

    }
}
