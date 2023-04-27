using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Classe qui permet de hash un string
    /// </summary>
    public class Hash
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public Hash() { }

        /// <summary>
        /// hash un texte en sha256
        /// </summary>
        /// <param name="text"> text à hash </param>
        /// <returns> le nouveau texte à hashé </returns>
        public string HashStringToSHA256(string text)
        {
            // Transforme le string en byte
            byte[] tab = Encoding.UTF8.GetBytes(text);

            // Hash le tableaud de byte
            byte[] hashTab = SHA256.HashData(tab);

            // Converti en chaine héxadécimale
            return BitConverter.ToString(tab).Replace("-", "");
        }
    }
}
