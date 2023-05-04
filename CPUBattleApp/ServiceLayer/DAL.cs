using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;
using System.Data.SqlClient;
using System.Data;

namespace ServiceLayer
{
    public class DAL
    {
        private string _sqlConnString = String.Empty;

        public DAL()
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
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[ApiGetAll]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    var result = sqlCommand.ExecuteReader();

                    while (result.Read())
                    {
                        UserModel model = new UserModel();
                        model.PlayerID = (int)result["id"];
                        model.PlayerName = (string)result["userName"];
                        model.PlayerAttempts = (int)result["attempts"];
                        model.UniformColor = (string)result["uniformColor"];
                        model.GemstoneName = (string)result["gemstoneName"];
                        model.TowerHeight = (int)result["towerHeight"];
                        model.ItemOneID = (int)result["itemOneID"];
                        model.ItemTwoID = (int)result["itemTwoID"];
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
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[ApiGetByName]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@playerName", name).Direction = ParameterDirection.Input;
                    conn.Open();
                    var result = sqlCommand.ExecuteReader();


                    while (result.Read())
                    {
                        UserModel model = new UserModel();
                        model.PlayerID = (int)result["id"];
                        model.PlayerName = (string)result["userName"];
                        model.PlayerAttempts = (int)result["attempts"];
                        model.UniformColor = (string)result["uniformColor"];
                        model.GemstoneName = (string)result["gemstoneName"];
                        model.TowerHeight = (int)result["towerHeight"];
                        model.ItemOneID = (int)result["itemOneID"];
                        model.ItemTwoID = (int)result["itemTwoID"];
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
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[ApiUpdateRecordByID]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@PlayerID", user.PlayerID).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Playername", user.PlayerName).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Attempts", user.PlayerAttempts).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@UniformColor", user.UniformColor).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@GemstoneName", user.GemstoneName).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@TowerHeight", user.TowerHeight).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@ItemOneID", user.ItemOneID).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@ItemTwoID", user.ItemTwoID).Direction = ParameterDirection.Input;
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

        public string APIDeleteById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[ApiDeleteById]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", id).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();
                    // Will return 1 if the deletion was successful, 0 if there was no record with the matching ID
                    string result = sqlCommand.ExecuteNonQuery() == 0 ? "Fail" : "Success";
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
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[ApiInsertRecord]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@PlayerID", user.PlayerID).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Playername", user.PlayerName).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@Attempts", user.PlayerAttempts).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@UniformColor", user.UniformColor).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@GemstoneName", user.GemstoneName).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@TowerHeight", user.TowerHeight).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@ItemOneID", user.ItemOneID).Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.AddWithValue("@ItemTwoID", user.ItemTwoID).Direction = ParameterDirection.Input;
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
