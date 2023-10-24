using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers;
using ProyectoComunidades.Modelo;

namespace ProyectoComunidades.Services
{
    public class DatabaseManagement
    {
        private string path = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\admata\source\repos\ProyectoComunidades\Models\BBDD\CommunityBBDD.mdb";

		public GenericList<User> GetUsersBBDD()
        {
			User newUser;
			GenericList<User> userList = new GenericList<User>();

			string query = "SELECT * FROM Users";

			using (OleDbConnection conexion = new OleDbConnection(path))
			{
				OleDbCommand command = new OleDbCommand(query, conexion);
				try
				{
					conexion.Open();
					using (OleDbDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							int id = Convert.ToInt32(reader["id"].ToString());
							string username = reader["username"].ToString();
							string password = reader["password"].ToString();
							int age = Convert.ToInt32(reader["age"].ToString());
							string email = reader["email"].ToString();
							string description = reader["description"].ToString();

							newUser = new User(id, username, password, age, email, description);
							userList.AddToList(newUser);
						}
					}
					conexion.Close();
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERROR: " + ex.Message);
				}
			}
			return userList;
        }
        public void InsertUserBBDD(User user)
        {

        }
        public void DeleteUserBBDD(User user)
        {
            string consulta = $"DELETE FROM Users WHERE id={user.Id}";
   
            using (OleDbConnection conexion = new OleDbConnection(path))
            {  

                OleDbCommand comando = new OleDbCommand(consulta, conexion);
                try
                {
                    conexion.Open(); 
                    OleDbDataReader table = comando.ExecuteReader();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }

            }
        }

    }
}
