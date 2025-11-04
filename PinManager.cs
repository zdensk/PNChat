using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PNChat
{
    public class PinManager
    {
        private const string PinFile = "pin.hash";
        private string savedPinHash;

        public PinManager()
        {
            if (File.Exists(PinFile))
            {
                savedPinHash = File.ReadAllText(PinFile);
            }
            else
            {
                savedPinHash = Hash("1234"); // Default PIN
                File.WriteAllText(PinFile, savedPinHash);
            }
        }

        public bool ValidatePin(string pin)
        {
            return Hash(pin) == savedPinHash;
        }

        public void SetPin(string pin)
        {
            savedPinHash = Hash(pin);
            File.WriteAllText(PinFile, savedPinHash);
        }

        private string Hash(string input)
        {
            using (var sha = SHA256.Create())
            {
                return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
            }
        }
    }
}
