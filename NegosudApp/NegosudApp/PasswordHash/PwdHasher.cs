using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using NegosudApp.Models;
using System.Text;

//$"{iterations}.{salt}.{hash}"
//c# handle password

namespace NegosudApp.PasswordHash
{

    //Remove the sealed modifier
    public sealed class PwdHasher //: IPwdHasher
    {
        private const int SaltSize = 16; // 128 bit 
        private const int PassSize = 20;  // ? bit
        readonly byte[] salt = new byte[SaltSize];

        public PwdHasher(IOptions<HashOption> options)
        {
            Options = options.Value;
        }

        private HashOption Options { get; }

// changing string type to byte[] type
        public byte[] Hash(string password)
        {
            var rng =  RandomNumberGenerator.Create();
            rng.GetNonZeroBytes(salt);

            Rfc2898DeriveBytes algorithm = new (
              password,
              salt,
              Options.Iterations,
              HashAlgorithmName.SHA512);

            byte[] hashsalt = algorithm.GetBytes(SaltSize);
            byte[] hashpass = algorithm.GetBytes(PassSize);
            
            byte[] hashBytes = new byte[SaltSize+PassSize];
            Array.Copy(hashsalt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hashpass, 0, hashBytes, SaltSize, PassSize);

            return hashBytes;


            //byte[] key = algorithm.GetBytes(PassSize + SaltSize);
            //return key;

            //using (var algorithm = new Rfc2898DeriveBytes(
            //  password,
            //  SaltSize,
            //  Options.Iterations,
            //  HashAlgorithmName.SHA512))
            //{
            //byte[] key = algorithm.GetBytes(PassSize+SaltSize);
            //    byte[] salt = algorithm.Salt;
            //    //var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
            //    //var salt = Convert.ToBase64String(algorithm.Salt);

            //return key;
            //    return [salt].[key];
            //}
        }




        //public (bool Verified, bool NeedsUpgrade) Check(byte[] hashBytes, string password)
        //{
        //    var parts = hashBytes.Split('.', 3);
        //    hashBytes.
        //    if (parts.Length != 3)
        //    {
        //        throw new FormatException("Unexpected hash format. " +
        //          "Should be formatted as `{iterations}.{salt}.{hash}`");
        //    }

        //    var iterations = Convert.ToInt32(parts[0]);
        //    var salt = Convert.FromBase64String(parts[1]);
        //    var key = Convert.FromBase64String(parts[2]);

        //    var needsUpgrade = iterations != Options.Iterations;

        //    using (var algorithm = new Rfc2898DeriveBytes(
        //      password,
        //      salt,
        //      iterations,
        //      HashAlgorithmName.SHA512))
        //    {
        //        var keyToCheck = algorithm.GetBytes(KeySize);

        //        var verified = keyToCheck.SequenceEqual(key);

        //        return (verified, needsUpgrade);
        //    }
        //}




        //public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        //{
        //    var parts = hash.Split('.', 3);

        //    if (parts.Length != 3)
        //    {
        //        throw new FormatException("Unexpected hash format. " +
        //          "Should be formatted as `{iterations}.{salt}.{hash}`");
        //    }

        //    var iterations = Convert.ToInt32(parts[0]);
        //    var salt = Convert.FromBase64String(parts[1]);
        //    var key = Convert.FromBase64String(parts[2]);

        //    var needsUpgrade = iterations != Options.Iterations;

        //    using (var algorithm = new Rfc2898DeriveBytes(
        //      password,
        //      salt,
        //      iterations,
        //      HashAlgorithmName.SHA512))
        //    {
        //        var keyToCheck = algorithm.GetBytes(KeySize);

        //        var verified = keyToCheck.SequenceEqual(key);

        //        return (verified, needsUpgrade);
        //    }
        //}
    }

}
