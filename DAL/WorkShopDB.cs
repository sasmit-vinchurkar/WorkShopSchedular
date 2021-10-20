using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BOL;


namespace DAL
{
    public class WorkShopDB
    {
        static string cs = "Data Source=DESKTOP-FH7F4IA\\SQLEXPRESS;Initial Catalog=WorkShop;Integrated Security=True";
        SqlConnection con = new SqlConnection(cs);

        public bool InsertWorkShop(WorkShopBO workShopBO)
        {
            try
            {
                string sp = "spInsertAdminWorkShopData";
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkShopTitle", workShopBO.WorkShopTitle);
                cmd.Parameters.AddWithValue("@WorkShopDate", workShopBO.WorkShopDate);
                cmd.Parameters.AddWithValue("@WorkShopDuration", workShopBO.WorkShopDuration);
                cmd.Parameters.AddWithValue("@WorkShopTopics", workShopBO.WorkShopTopics);
                cmd.Parameters.AddWithValue("@CreatedBy", (object)workShopBO.CreatedBy ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CreatedDate", (object)workShopBO.CreatedDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UpdatedBy", (object)workShopBO.UpdatedBy ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UpdatedDate", (object)workShopBO.UpdatedDate ?? DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
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

        public List<WorkShopBO> GetAllWorkShops()
        {
            List<WorkShopBO> ls = new List<WorkShopBO>();
            WorkShopBO workShopBO = new WorkShopBO();
            try
            {
                string sp = "spGetWorkShopInfo";
                SqlCommand cmd = new SqlCommand(sp, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null)
                {
                    ls = ds.Tables[0].AsEnumerable().Select(
                        DataRow => new WorkShopBO
                        {
                            WorkShopTitle = DataRow.Field<string>("WorkShopTitle"),
                            WorkShopDate = DataRow.Field<DateTime>("WorkShopDate"),
                            WorkShopDuration = DataRow.Field<string>("WorkShopDuration"),
                            WorkShopId = DataRow.Field<int>("WorkShopId"),
                            WorkShopTopics = DataRow.Field<string>("WorkShopTopics"),
                            CreatedBy  = DataRow.Field<int?>("CreatedBy"),
                            CreatedDate = DataRow.Field<DateTime?>("CreatedDate"),
                            UpdatedBy = DataRow.Field<int?>("UpdatedBy"),
                            UpdatedDate = DataRow.Field<DateTime?>("UpdatedDate")
                        }
                        ).ToList();
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
            ////try
            ////{
            ////    string sp = "spGetWorkShopInfo";
            ////    SqlCommand cmd = new SqlCommand(sp, con);
            ////    cmd.CommandType = CommandType.StoredProcedure;

            ////    con.Open();
            ////    SqlDataReader rdr = cmd.ExecuteReader();

            ////    while (rdr.Read())
            ////    {
            ////        WorkShopBO workShopBO = new WorkShopBO();

            ////        workShopBO.WorkShopId = int.Parse(rdr["WorkShopId"].ToString());
            ////        workShopBO.WorkShopTitle = rdr["WorkShopTitle"].ToString();
            ////        workShopBO.WorkShopDate = DateTime.Parse(rdr["WorkShopDate"].ToString());
            ////        workShopBO.WorkShopDuration = rdr["WorkShopDuration"].ToString();
            ////        workShopBO.WorkShopTopics = rdr["WorkShopTopics"].ToString();
            ////        workShopBO.UpdatedBy = rdr["UpdatedBy"] as int? ?? default(int);
            ////        workShopBO.UpdatedDate = rdr["UpdatedDate"] as DateTime? ?? default(DateTime);
            ////        workShopBO.CreatedBy = rdr["CreatedBy"] as int? ?? default(int);
            ////        workShopBO.CreatedDate = rdr["CreatedDate"] as DateTime? ?? default(DateTime);

            ////        ls.Add(workShopBO);
            ////    }
            ////    rdr.Close();
            ////    return ls;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    con.Close();
            //}

        }

        public WorkShopBO GetWorkShopById(int WorkShopId)
        {
            try
            {
                WorkShopBO workShopBO = null;

                string sp = "spGetWorkShopDetailsById";
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    workShopBO = new WorkShopBO();

                    workShopBO.WorkShopId = int.Parse(rdr["WorkShopId"].ToString());
                    workShopBO.WorkShopTitle = rdr["WorkShopTitle"].ToString();
                    workShopBO.WorkShopDate = DateTime.Parse(rdr["WorkShopDate"].ToString());
                    workShopBO.WorkShopDuration = rdr["WorkShopDuration"].ToString();
                    workShopBO.WorkShopTopics = rdr["WorkShopTopics"].ToString();
                }
                rdr.Close();

                return workShopBO;

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

        public bool UpdateWorkShopById(WorkShopBO workShopBO, int WorkShopId)
        {
            try
            {
                string sp = "spUpdateWorkshopById";
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                cmd.Parameters.AddWithValue("@WorkShopTitle", workShopBO.WorkShopTitle);
                cmd.Parameters.AddWithValue("@WorkShopDate", workShopBO.WorkShopDate);
                cmd.Parameters.AddWithValue("@WorkShopDuration", workShopBO.WorkShopDuration);
                cmd.Parameters.AddWithValue("@WorkShopTopics", workShopBO.WorkShopTopics);
                cmd.Parameters.AddWithValue("@UpdatedBy", (object)workShopBO.UpdatedBy ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UpdatedDate", (object)workShopBO.UpdatedDate ?? DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();

              

                return true;
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

        public bool DeleteWorkShopById(int WorkShopId)
        {
            try
            {
                string sp = "spDeleteWorkShopById";
                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                con.Open();
                cmd.ExecuteNonQuery();


                return true;
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

        public bool AssignTrainersToWorkShop(List<TrainerWorkShopMappingBO> ls)
        {

            try
            {
                foreach (var item in ls)
                {
                    string cmdstr = "Insert into tblTrainerWorkShopMapping VALUES(@TrainerId,@WorkShopId,null, null, null, null)";
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(cmdstr, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@TrainerId", item.TrainerId);
                    cmd.Parameters.AddWithValue("@WorkShopId", item.WorkShopId);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
                
            }
        }


    }
}
