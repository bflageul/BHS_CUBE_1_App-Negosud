using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegosudApp.PasswordHasher
{
    public sealed class HashingOption
    {
        public int Iterations { get; set; } = 10000;
    }
}
