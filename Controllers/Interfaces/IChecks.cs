using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Modelo;

namespace ProyectoComunidades.Controllers.Interfaces
{
	public interface IChecks
	{
		public bool CheckUsernameLength(string username);
		public bool CheckUsernamePattern(string username);
		public bool CheckPasswordLength(string password);
		public bool CheckPasswordPattern(string password);
		public bool CheckPasswordMatch(string password, string passwordRepeated);
		public bool CheckUserRepeated(string username, GenericList<User> userlist);
		public bool AgeManagement(string date);
		public bool CheckAdultAge(DateTime date);
		public bool CheckEmailPattern(string email);
		public bool CheckEmailLength(string email);
		public bool CheckDescriptionLength(string description);

	}
}
