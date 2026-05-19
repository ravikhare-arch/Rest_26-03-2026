using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public class NCManageMaster
{
    string returnValue = string.Empty;
    SqlConnection conn;
    connection connobj = new connection(); // Aapka custom connection class

    public string AreaID { get; set; }
    public string AreaName { get; set; }
    public string OrderType { get; set; }

    public string User_Operation(NCManageMaster masterObj, string type)
    {
        SqlCommand cmd = addParameter(masterObj, type, "");
        try
        {
            returnValue = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            returnValue = ex.Message;
        }
        finally
        {
            cmd.Dispose();
            connobj.closeConnection();
        }
        return returnValue;
    }

    public SqlCommand addParameter(NCManageMaster masterObj, string type, string cond)
    {
        string uid = HttpContext.Current.Session["uid"] == null ? "0" : HttpContext.Current.Session["uid"].ToString();
        conn = connobj.makeConnection();

        // 🔥 Naye Stored Procedure ka naam yahan bind kiya hai
        SqlCommand cmd = new SqlCommand("USP_NCMaster", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@NC_ID", string.IsNullOrEmpty(masterObj.AreaID) ? 0 : Convert.ToInt32(masterObj.AreaID));
        cmd.Parameters.AddWithValue("@NC_Name", masterObj.AreaName);
        cmd.Parameters.AddWithValue("@OrderType", string.IsNullOrEmpty(masterObj.OrderType) ? 0 : Convert.ToInt32(masterObj.OrderType));
        cmd.Parameters.AddWithValue("@nCreatedID", Convert.ToInt32(uid));
        cmd.Parameters.AddWithValue("@nModifiedID", Convert.ToInt32(uid));
        cmd.Parameters.AddWithValue("@Type", type);
        cmd.Parameters.AddWithValue("@Cond", cond);

        return cmd;
    }

    public DataTable Tabledata(NCManageMaster masterObj, string type, string cond)
    {
        SqlCommand cmd = addParameter(masterObj, type, cond);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            da.Fill(dt);
        }
        catch
        {
            // Handle error logic here
        }
        finally
        {
            cmd.Dispose();
            connobj.closeConnection();
        }
        return dt;
    }
    public string GetNCNameByOrderType(int orderTypeID)
    {
        string ncName = string.Empty;
        SqlConnection conn;
        connection connobj = new connection(); // Aapka custom connection object

        try
        {
            conn = connobj.makeConnection();
            using (SqlCommand cmd = new SqlCommand("USP_GetNCNameFromOrderType", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OrderType", orderTypeID);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    ncName = result.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            // Yahan aap error log kar sakte hain
            ncName = "Error: " + ex.Message;
        }
        finally
        {
            connobj.closeConnection();
        }
        return ncName;
    }
}