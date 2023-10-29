﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Modelo;

namespace ProyectoComunidades.Controllers.Interfaces
{
	public interface IUserManagement
	{
		public void AddUser(string username, string password, int age, string email, string description);
		public void DeleteUser();
		public void ModifyUser();

	}
}
