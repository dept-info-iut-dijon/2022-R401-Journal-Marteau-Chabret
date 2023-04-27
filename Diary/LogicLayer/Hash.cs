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
            // Transforme le string en tableau de byte
            byte[] tab = Encoding.UTF8.GetBytes(text);

            // Hash le tableau de byte
            byte[] hashTab;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashTab = sha256.ComputeHash(tab);
            }

            // Converti en chaîne héxadécimale
            return BitConverter.ToString(hashTab).Replace("-", "");
        }
    }
}
