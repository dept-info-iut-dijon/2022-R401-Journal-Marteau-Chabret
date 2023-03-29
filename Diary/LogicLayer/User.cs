using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Utilisateur
    /// </summary>
    public class User
    {
        private string login;
        private string name;
        private UserRoles role;
        private string password;
        private int id;

        /// <summary>
        /// Login de l'utilisateur
        /// </summary>
        public string Login { get => login; set => login = value; }

        /// <summary>
        /// Nom de l'utilisateur
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Rôle de l'utilisateur
        /// </summary>
        public UserRoles Role { get => role; set => role = value; }

        /// <summary>
        /// Mot de passe de l'utilisateur
        /// </summary>
        public string Password { get => password; set => password = value; }

        /// <summary>
        /// ID de l'utilisateur
        /// </summary>
        public int Id { get => id; set => id = value; }
    }
}
