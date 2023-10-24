using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers;
using ProyectoComunidades.Controllers.Interfaces;
using ProyectoComunidades.Modelo;
using ProyectoComunidades.Services;

namespace ProyectoComunidades
{
    public class Menu : IMenu
    {
		private readonly IChecks _checks = new Checks();

		CommunityManagement CMInstance = new CommunityManagement();
        UserManagement UMInstance = new UserManagement();

        static DatabaseManagement DBInstance = new DatabaseManagement();
		GenericList<User> userList = DBInstance.GetUsersBBDD();
		public void MainMenu()
        {
            int option;
            do
            {
                Console.WriteLine("\n~ 1) Register: \n" +
                                    "~ 2) Login: \n" +
                                    "~ 0) Salir: \n");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
						Register();
                        break;
                    case 2:
						Login();
                        break;
                    case 0:
                        break;
                }
            }
            while (option != 0);
        }
		public void Register()
		{
			string username;
			do
			{
				Console.WriteLine("\nUsername: ");
			} while (!_checks.CheckUsernameLength(username = Console.ReadLine()) || !_checks.CheckUsernamePattern(username) || !_checks.CheckUserRepeated(username, userList));

			string password;
			do
			{
				Console.WriteLine("\nPassword: ");
			} while (!_checks.CheckPasswordPattern(password = Console.ReadLine()) || !_checks.CheckPasswordLength(password));

			string repeatedPassword;
			do
			{
				Console.WriteLine("\nRepeat the password: ");
			} while (!_checks.CheckPasswordMatch(password, repeatedPassword = Console.ReadLine()));
			
			string birth;
			do
			{
				Console.WriteLine("\nBirth(dd/mm/yyyy): ");
			} while (!_checks.AgeManagement(birth = Console.ReadLine()));

			string email;
			do
			{
				Console.WriteLine("\nEmail: ");
			} while (!_checks.CheckEmailPattern(email = Console.ReadLine()) || !_checks.CheckEmailLength(email));

			string description;
			do
			{
				Console.WriteLine("\nDescription: ");
			} while (!_checks.CheckDescriptionLength(description = Console.ReadLine()));

			// Call Add User()

		}
		public void Login()
		{

		}
	}
}
