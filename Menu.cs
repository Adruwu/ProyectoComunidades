using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers;
using ProyectoComunidades.Controllers._Factory_StrategyFactory;
using ProyectoComunidades.Controllers.Checks;
using ProyectoComunidades.Controllers.Interfaces;
using ProyectoComunidades.Controllers.Managements;
using ProyectoComunidades.Modelo;

namespace ProyectoComunidades
{
	public class Menu : IMenu
	{
		static DatabaseManagement DBInstance = new DatabaseManagement();
		GenericList<User> userList = DBInstance.GetUsersDB();
		CommunityManagement CMInstance = new CommunityManagement();
		UserManagement UMInstance = new UserManagement();
		Checks _checks = new Checks();
		static StrategyFactory factory = new StrategyFactory();
		ICheckStrategy descriptionLengthChecker = factory.CreateCheckStrategy("DescriptionLength");
		ICheckStrategy emailLengthChecker = factory.CreateCheckStrategy("EmailLength");
		ICheckStrategy passwordLengthChecker = factory.CreateCheckStrategy("PasswordLength");
		ICheckStrategy passwordMatchChecker = factory.CreateCheckStrategy("PasswordMatch");
		ICheckStrategy passwordPatternChecker = factory.CreateCheckStrategy("PasswordPattern");
		ICheckStrategy userAgeChecker = factory.CreateCheckStrategy("UserAge");
		ICheckStrategy userEmailChecker = factory.CreateCheckStrategy("UserEmail");
		ICheckStrategy usernameLengthChecker = factory.CreateCheckStrategy("UsernameLength");
		ICheckStrategy usernamePatternChecker = factory.CreateCheckStrategy("UsernamePattern");



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
			} while (!usernameLengthChecker.Check(username = Console.ReadLine()) || !usernamePatternChecker.Check(username) || !_checks.CheckUserRepeated(username, userList));

			string password;
			do
			{
				Console.WriteLine("\nPassword: ");
			} while (!passwordPatternChecker.Check(password = Console.ReadLine()) || !passwordLengthChecker.Check(password));

			string repeatedPassword;
			do
			{
				Console.WriteLine("\nRepeat the password: ");
			} while (!passwordMatchChecker.Check(password, repeatedPassword = Console.ReadLine()));

			string birth;
			do
			{
				Console.WriteLine("\nBirth (dd/mm/yyyy): ");
			} while (!userAgeChecker.Check(birth = Console.ReadLine()));
			int ageYear = _checks.GetAdultAge(birth);
;
			string email;
			do
			{
				Console.WriteLine("\nEmail: ");
			} while (!userEmailChecker.Check(email = Console.ReadLine()) || !emailLengthChecker.Check(email));

			string description;
			do
			{
				Console.WriteLine("\nDescription: ");
			} while (!descriptionLengthChecker.Check(description = Console.ReadLine()));


			UMInstance.AddUser(username, password, ageYear, email, description);

		}
		public void Login()
		{
			User asdasd = new User("Manuel", "Perez", 12, "asda", "aSdasd");
			DBInstance.InsertUserDB(asdasd);

			userList.ShowList();


		}
	}
}
