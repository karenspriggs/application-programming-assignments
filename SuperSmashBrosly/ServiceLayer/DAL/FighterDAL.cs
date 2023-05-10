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
    public class FighterDAL
    {
        private string _sqlConnString = String.Empty;

        public FighterDAL()
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

        public List<FighterModel> APIGetAll()
        {
            List<FighterModel> list = new List<FighterModel>();

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[FightersApiGetAll]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    var result = sqlCommand.ExecuteReader();

                    while (result.Read())
                    {
                        FighterModel model = new FighterModel();
                        model.Name = (string)result["Name"];
                        model.DebutGame = (string)result["First_Appearance"];
                        model.FinalSmashName = (string)result["Final_Smash_Name"];
                        model.Origin = (string)result["Origin"];
                        model.Weight = (string)result["Weight"];
                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public List<FighterModel> APIGetbyName(string name)
        {
            List<FighterModel> list = new List<FighterModel>();

            using (SqlConnection conn = new SqlConnection(_sqlConnString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("[dbo].[FightersApiGetByName]", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@fighterName", name).Direction = ParameterDirection.Input;
                    conn.Open();
                    var result = sqlCommand.ExecuteReader();


                    while (result.Read())
                    {
                        FighterModel model = new FighterModel();
                        model.Name = (string)result["Name"];
                        model.DebutGame = (string)result["First_Appearance"];
                        model.FinalSmashName = (string)result["Final_Smash_Name"];
                        model.Origin = (string)result["Origin"];
                        model.Weight = (string)result["Weight"];
                        list.Add(model);

                    }
                }
            }

            return list;
        }
    }
}
