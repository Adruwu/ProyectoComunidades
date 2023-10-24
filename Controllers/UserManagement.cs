using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers;
using ProyectoComunidades.Controllers.Interfaces;
using ProyectoComunidades.Modelo;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoComunidades.Services
{
    public class UserManagement : IUserManagement
    {
		DatabaseManagement DBInstance = new DatabaseManagement();
		public void AddUser()
		{
			// AddUser
		}
		public void DeleteUser()
		{

		}
		public void ModifyUser()
		{

		}

	}
}
