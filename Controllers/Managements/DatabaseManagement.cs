using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers;
using ProyectoComunidades.Modelo;
using ProyectoComunidades.Services;

namespace ProyectoComunidades.Controllers.Managements
{
    public class DatabaseManagement
    {
        static string proyectoPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\"));
        static string databasePath = Path.Combine(proyectoPath, "CommunityDB.mdb");
        static string path = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={databasePath}";



		public GenericList<User> GetUsersDB()
        {
            User newUser;
            GenericList<User> userList = new GenericList<User>();

            string query = "SELECT * FROM Users";

            using (OleDbConnection connection = new OleDbConnection(path))
            {
                OleDbCommand command = new OleDbCommand(query, connection);
                try
                {
					connection.Open();
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
					connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
            }
            return userList;
        }
        public void InsertUserDB(User newUser)
        {

			string consulta = $"INSERT INTO Users(id, username, password, age, email, description) VALUES ({66}, '{"pepe"}', '{"pepe"}', {12}, '{"pepelo"}, '{"lololo"}')";

			using (OleDbConnection conexion = new OleDbConnection(path))
			{

				OleDbCommand comando = new OleDbCommand(consulta, conexion);
				try
				{
					conexion.Open();

					OleDbDataReader miTabla = comando.ExecuteReader();
					Console.WriteLine("Insertado correctamente");

					conexion.Close();
				}
				catch (Exception ex)
				{
					Console.WriteLine("ERROR: " + ex.Message);
				}
			}
		}
        public void DeleteUserDB(User user)
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
