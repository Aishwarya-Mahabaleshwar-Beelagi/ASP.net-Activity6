using DepUpdateDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepUpdateDAL
{
   public  class DepDAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;

        public DepDAL()
        {
            sqlConObj = new SqlConnection();
            sqlCmdObj = new SqlCommand();

        }


        public int UpdateDepartment(DepDTO newObj)
        {
            try
            {
                //SQL COnnection
                sqlConObj.ConnectionString = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;
                //SQL Command
                sqlCmdObj.CommandText = @"usp_UpdateDepartments";
                sqlCmdObj.CommandType = CommandType.StoredProcedure;
                sqlCmdObj.Connection = sqlConObj;
                //Input Parameter defintion
                sqlCmdObj.Parameters.AddWithValue("@Name", newObj.Name);
                sqlCmdObj.Parameters.AddWithValue("@GroupName", newObj.GroupName);
                sqlCmdObj.Parameters.AddWithValue("@ModifiedDate", newObj.ModifiedDate);



                //Return Value
                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                sqlCmdObj.Parameters.Add(prmReturn);

                //OPen COnnection
                sqlConObj.Open();
                //Anything other than SELECT/INSERT/UPDATE/DELETE we use Execute Non Query
                sqlCmdObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
