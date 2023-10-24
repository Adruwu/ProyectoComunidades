using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers;
using ProyectoComunidades.Controllers.Interfaces;
using ProyectoComunidades.Modelo;

namespace ProyectoComunidades.Services
{
    public class Checks : IChecks
	{
		public bool CheckUsernameLength(string username)
		{
			if (username.Length < 5)
			{
				Console.WriteLine("ERROR: The User must contain at least 5 characters.");
				return false;
			}
			return true;
		}
		public bool CheckUsernamePattern(string username)
		{
			if (!Regex.IsMatch(username, "^(?=.*[A-Z])(?=.*\\d).{5,}"))
			{
				Console.WriteLine("ERROR: The User must contain at least 1 Capital Letter and 1 Number.");
				return false;
			}
			return true;
		}
		public bool CheckPasswordLength(string password)
		{
			if (password.Length < 8)
			{
				Console.WriteLine("ERROR: The password must be at least 8 characters.");
				return false;
			}
			return true;
		}
		public bool CheckPasswordPattern(string password)
		{
			if (!Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)"))
			{
				Console.WriteLine("ERROR: The password must have at least 1 Capital Letter and 1 Number.");
				return false;
			}
			return true;
		}
		public bool CheckPasswordMatch(string password, string repeatedPassword)
		{
			if(password != repeatedPassword)
			{
				Console.WriteLine("ERROR: Passwords don't match");
				return false;
			}
			return true;
		}
		public bool CheckUserRepeated(string username, GenericList<User> userlist)
		{
			if (userlist.GetList().Any(user => user.Username == username))
			{
				Console.WriteLine("The username is already in use.");
				return false;
			}
			return true;
		}
		public bool AgeManagement(string birth)
		{
			string dateFormat = "dd/MM/yyyy";
			if (DateTime.TryParseExact(birth, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime date))
			{
				if (CheckAdultAge(date))
				{
					return true;
				}
			}
			else
			{
				Console.WriteLine("ERROR: Enter the correct format");
			}
			return false;
		}
		public bool CheckAdultAge(DateTime birthDate)
		{
			DateTime currentDate = DateTime.Now;
			int ageInYears = currentDate.Year - birthDate.Year;
			if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
			{
				ageInYears--;
			}
			if (!(ageInYears >= 18))
			{
				Console.WriteLine("You must be of legal age to register");
				return false;
			}
			return true;
		}
		public bool CheckEmailPattern(string email)
		{
			if(!Regex.IsMatch(email, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
			{
				Console.WriteLine("ERROR: The email doesn't meet the proper format");
				return false;
			}
			return true;
		}
		public bool CheckEmailLength(string email)
		{
			if(email.Length > 40)
			{
				Console.WriteLine("ERROR: Emails longer than 40 characters are not accepted");
				return false;
			}
			return true;
		}
		public bool CheckDescriptionLength(string description)
		{
			if(description.Length > 200)
			{
				Console.WriteLine("ERROR: Description cannot exceed 200 letters");
				return false;
			}
			return true;
		}
	}
}
