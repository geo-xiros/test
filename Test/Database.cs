﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Database
    {
        private Dictionary<string, User> _users;
        public Database()
        {
            _users = new Dictionary<string, User>();

            _users.Add("admin", new AdminUser());
            _users.Add("george", new SimpleUser(1, "george", "1234", new ViewRole()));
            _users.Add("nick", new SimpleUser(2, "nick", "1234", new ViewEditRole()));
            _users.Add("john", new SimpleUser(3, "john", "1234", new ViewEditDeleteRole()));

            foreach (var user in _users.Values)
            {
                Console.WriteLine(user.Username);
                Console.WriteLine(Responsibilities.ViewData + " " + user.HasAccessTo(Responsibilities.ViewData));
                Console.WriteLine(Responsibilities.EditData + " " + user.HasAccessTo(Responsibilities.EditData));
                Console.WriteLine(Responsibilities.DeleteData + " " + user.HasAccessTo(Responsibilities.DeleteData));
            }

        }

        public User GetUser(string username)
        {
            return _users[username];
        }

        public bool Login(string username, string password)
        {
            return (_users.ContainsKey(username) &&
                    _users[username].IsPasswordCorrect(password));
        }

    }
}
