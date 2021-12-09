using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegosudApp.PasswordHash
{
    public interface IPwdHasher
    {

        // changing strin type to byte[] type
        byte[] Hash(string password);

        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}
