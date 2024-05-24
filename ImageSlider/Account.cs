using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSlider
{
    internal class Account
    {
        private string _name;
        private string _password;

        public Account(string name, string password)
        {
            _name = name;
            _password = password;
        }

        public string Name { get => _name; set => _name = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
