using System;

namespace ProSoft.Crypto.FileEncryption
{
    public class Service
    {
        public static bool EncryptFile(string sourceFile, string destinationFile, string password)
        {
            SharpAESCrypt.SharpAESCrypt.Encrypt(password, sourceFile, destinationFile);
            return System.IO.File.Exists(destinationFile);
        }

        public static bool DecryptFile(string sourceFile, string destinationFile, string password, out string passwordStatus)
        {
            try
            {
                SharpAESCrypt.SharpAESCrypt.Decrypt(password, sourceFile, destinationFile);
                passwordStatus = "OK";
                return System.IO.File.Exists(destinationFile);
            }
            catch (Exception e)
            {
                passwordStatus = "INCORRECT_PASSWORD";
            }

            return false;
        }
    }
}