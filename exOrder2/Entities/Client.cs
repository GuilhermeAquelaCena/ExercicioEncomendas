using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exOrderT5.entities
{
    internal class Client
    {
        public string Name { get; private set; }
        private string email;
        private DateTime birthdate;

        public Client(string name, string email, DateTime birthdate)
        {
            this.Name = name;
            this.email = email;
            this.birthdate = birthdate;
        }

        public override string ToString()
        {
            return $"\n\nDados do cliente: {Name},\n\tEmail: {email},\n\tData de nascimento {birthdate.ToLongDateString()}";
        }
    }
}

