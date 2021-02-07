using System.Text;

namespace Invilla.Service.Security
{
    public class CryptoConfig
    {

        public static string EncryptPassword (string password)
        {
            byte[] encrypt = Encoding.ASCII.GetBytes(password);
            encrypt = new System.Security.Cryptography.SHA256Managed().ComputeHash(encrypt);
            var hashCode = Encoding.ASCII.GetString(encrypt);

            return hashCode;
        }
    }
}
