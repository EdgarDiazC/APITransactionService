using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/GetTransactions")]
    public class TransactionController : Controller
    { 

        private Transaction[] transactions = new Transaction[]
        {
            new Transaction { id = 1, titular = "A", nif = "45882150X", cuenta = "1234", importe = 100},
            new Transaction { id = 2, titular = "B", nif = "45889103M", cuenta = "2345", importe = 450},
            new Transaction { id = 3, titular = "A", nif = "45882150X", cuenta = "4321", importe = 35},
            new Transaction { id = 4, titular = "C", nif = "47810350B", cuenta = "3456", importe = 18},
            new Transaction { id = 5, titular = "D", nif = "46902154R", cuenta = "4567", importe = 60}
        };
        // GET: api/<controller>
        [HttpGet("{code}")]
        public IActionResult GetTransactions(string code)
        {
            string MAC_code = "GetTransactions/Edgar/asdf/1/0/nsnc";

            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(MAC_code));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            string hash = sBuilder.ToString();

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if(comparer.Compare(hash, code) == 0)
            {
                return Ok(transactions);
            }

            return Forbid();
            
        }
    }
}
