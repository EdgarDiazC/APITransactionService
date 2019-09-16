using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Transactions
    {

        public long id { get; set; }
        public string titular { get; set; }
        public string nif { get; set; }
        public string cuenta { get; set; }
        public float importe { get; set; }

    }
}
