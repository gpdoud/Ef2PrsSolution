using Ef2PrsConsole;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ef2PrsLib {
    
    public class UsersController {

        private readonly prs0Context _context;

        public UsersController(prs0Context context) {
            this._context = context;
        }

        /// <summary>
        /// Returns a user if the username and password are found
        /// in the users table of the database
        /// </summary>
        /// <param name="username">The username as a string</param>
        /// <param name="password">The password as a string</param>
        /// <returns>
        /// A user instance if the the username and password combination
        /// is found. Else returns null.
        /// </returns>
        public Users Login(string username, string password) {
            return _context.Users
                        .SingleOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
