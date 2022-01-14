using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NegosudApp.PasswordHash
{
    public interface IPwdHasher
    {
        // Hash method with password privided by user as parameter 
        byte[] Hash(string password);

        // Check method with username and password privided by user as parameters
        bool Check(string username, string password);
    }
}
