using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using NegosudApp.Migrations;
using Microsoft.AspNetCore.Mvc;
using NegosudApp.Controllers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

//$"{iterations}.{salt}.{hash}"
//c# handle password

namespace NegosudApp.PasswordHash
{

    // IPwdHasher interface implementation, but no class can inherit from PwdHasher
    public sealed class PwdHasher : IPwdHasher
    {
        // Salt size definition, in order to match with 128 bits variable
        private const int SaltSize = 16;
        // Password size definition, in order to match with 512 bits variable
        private const int PassSize = 64;

        // Declare _context as a NegosudDbContext type
        // (private read-only member variable of type NegosudDbContext)
        private readonly NegosudDbContext _context;

        // Declare Option as a HashOption type      
        private HashOption Options { get; }

        // Call HashOption and NegosudDbContext as PwdHasher ctor parameters
        // and initialize them in ctor
        public PwdHasher(
            IOptions<HashOption> options,
            NegosudDbContext context)
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

        //    using (var algorithm = new Rfc2898DeriveBytes(
        //      password,
        //      salt,
        //      iterations,
        //      HashAlgorithmName.SHA512))
        //    {
        //        var keyToCheck = algorithm.GetBytes(KeySize);

            bool result = false;

            if (_context.Users.Where(b => b.Username == username).FirstOrDefault() is null)
            {
                Debug.Write("Erreur : utilisateur inconnu");
            }
            else
            {
                var user = _context.Users.Where(b => b.Username == username).FirstOrDefault();
                byte[] stockedKey = user.HashPassword;
                byte[] stockedSalt = new byte[SaltSize];
                Array.Copy(stockedKey, 0, stockedSalt, 0, SaltSize);

                Rfc2898DeriveBytes algorithm = new(
                  password,
                  stockedSalt,
                  Options.Iterations,
                  HashAlgorithmName.SHA512);

                byte[] hashedPass = algorithm.GetBytes(PassSize);

                byte[] keyToCheck = new byte[SaltSize + PassSize];
                Array.Copy(stockedSalt, 0, keyToCheck, 0, SaltSize);
                Array.Copy(hashedPass, 0, keyToCheck, SaltSize, PassSize);
                if (stockedKey.SequenceEqual(keyToCheck))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            if (result == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}