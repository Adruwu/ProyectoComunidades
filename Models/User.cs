using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoComunidades.Modelo
{
    public class User : IListable
	{
		public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
		public User(string username, string password, int age, string email, string description)
		{
			Username = username;
			Password = password;
			Age = age;
			Email = email;
			Description = description;
		}

		public User(int id, string username, string password, int age, string email, string description)
		{
			Id = id;
			Username = username;
			Password = password;
			Age = age;
			Email = email;
			Description = description;
		}

		public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

		public override string ToString()
		{
			return $"ID: {Id}, Username: {Username}, Password: {Password}, Age: {Age}, Email: {Email}, Description: {Description}";
		}

	}
}
