using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BOL;

namespace DAL
{
    public class UserDB
    {
        static string cs = "Data Source=DESKTOP-FH7F4IA\\SQLEXPRESS;Initial Catalog=WorkShop;Integrated Security=True";
        SqlConnection con = new SqlConnection(cs);

        public List<UserBO> GetTrainers()
        {
            List<UserBO> ls = new List<UserBO>();

            try
            {

                string sp = "spGetTrainers";
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    UserBO userBO = new UserBO();

                    userBO.UserID = int.Parse(rdr["UserID"].ToString());
                    userBO.FirstName = rdr["Trainer"].ToString();
                    userBO.LastName = rdr["LastName"].ToString();
                    

                    ls.Add(userBO);
                }

                return ls;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

    }
}
