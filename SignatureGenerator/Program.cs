using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace SignatureGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            HMACSHA512 hmac = new HMACSHA512();
            string key = Convert.ToBase64String(hmac.Key);

            Console.WriteLine(key);
            Console.ReadLine();
        }
    }
}
