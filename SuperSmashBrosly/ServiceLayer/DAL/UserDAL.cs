using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;
using System.Data.SqlClient;
using System.Data;

namespace ServiceLayer.DAL
{
    public class UserDAL
    {
        private string _sqlConnString = String.Empty;

        public UserDAL()
        {
            PrepareConnection();
        }

        private void PrepareConnection()
        {
            SqlConnectionStringBuilder connBldr = new SqlConnectionStringBuilder();
            connBldr.DataSource = $"(localdb)\\MSSQLLocalDB";
            connBldr.IntegratedSecurity = true;
            connBldr.InitialCatalog = $"PROG455FA23";
            _sqlConnString = connBldr.ConnectionString;
        }

        public List<UserModel> APIGetAll()
        {
            List<UserModel> list = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UserApiGetAll]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    var result = sqlCommand.ExecuteReader();

                    while (result.Read())
                    {
                        UserModel model = new UserModel();
                        model.ID = (int)result["ID"];
                        model.Username = (string)result["Username"];
                        model.Password = (string)result["Password"];
                        model.Attempts = (int)result["Attempts"];
                        model.CorrectGuesses = (int)result["Correct_Guesses"];
                        model.LastFighterGuessed = (string)result["Last_Fighter_Guessed"];
                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public List<UserModel> APIGetbyName(string name)
        {
            List<UserModel> list = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UserApiGetByName]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@playerName", name).Direction = ParameterDirection.Input;
                    conn.Open();
                    var result = sqlCommand.ExecuteReader();


                    while (result.Read())
                    {
                        UserModel model = new UserModel();
                        model.ID = (int)result["ID"];
                        model.Username = (string)result["Username"];
                        model.Password = (string)result["Password"];
                        model.Attempts = (int)result["Attempts"];
                        model.CorrectGuesses = (int)result["Correct_Guesses"];
                        model.LastFighterGuessed = (string)result["Last_Fighter_Guessed"];
                        list.Add(model);

                    }
                }
            }

            return list;
        }

        public int APIUpdateRecord(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UserApiUpdateRecordByID]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ID", user.ID).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Username", user.Username).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Attempts", user.Attempts).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@CorrectGuesses", user.CorrectGuesses).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@LastFighter", user.LastFighterGuessed).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;


                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    // Will return 1 if the update was successful, 0 if there was no record with the matching ID
                    var result = (int)sqlCommand.Parameters["@ReturnValue"].Value;
                    conn.Close();
                    return result;

                }
            }
        }

        // Need insertion functionality to add new players to the database 
        public int APIInsertRecord(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[UserApiInsertRecord]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ID", user.ID).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Username", user.Username).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Attempts", user.Attempts).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@CorrectGuesses", user.CorrectGuesses).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@LastFighter", user.LastFighterGuessed).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;


                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    // Will return 1 if the insert was successful, 0 if there already was a record with the matching ID
                    var result = (int)sqlCommand.Parameters["@ReturnValue"].Value;
                    conn.Close();
                    return result;
                }
            }
        }
    }
}
