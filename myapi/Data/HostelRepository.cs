using System.Collections.Generic;
using System.Data;
using System.IO.Pipelines;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Data.SqlClient;
using myapi.Models;

namespace myapi.Data
{
    public class HostelRepository
    {
        private Globals _global;
        public HostelRepository(Globals global)
        {
            _global = global;
        }

        public IEnumerable<HostelModel> GetAllHostels()
        {
            SqlCommand cmd = _global.Connection();
            cmd.CommandText = "PR_Hostel_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
           
            List<HostelModel> list = new List<HostelModel>();

            while (reader.Read())
            {
                HostelModel model = new HostelModel();
                model.HostelID = reader.GetInt32("HostelID");
                model.HostelName = reader.GetString("HostelName");
                model.HostelAddress = reader.GetString("HostelAddress");
                model.HostelContactNumber = reader.GetString("HostelContactNumber");
                model.HostelEmail = reader.GetString("HostelEmail");
                model.HostelAdminPassword = reader.GetString("HostelAdminPassword");
                model.HostelPincode = reader.GetString("HostelPincode");
                model.HostelCity = reader.GetString("HostelCity");
                model.HostelCountry = reader.GetString("HostelCountry");
                model.HostelState = reader.GetString("HostelState");
                model.HostelCapacity = reader.GetInt32("HostelCapacity");
                model.Amenities = reader.GetString("Amenities");
                model.HostelType = reader.GetString("HostelType");
                model.HostelPolicies = reader.GetString("HostelPolicies");
                model.CreatedAt = reader.GetDateTime("CreatedAt");
                model.UpdatedAt = reader.GetDateTime("UpdatedAt");
                list.Add(model);
            }

            return list;
        }

        public bool HostelLogin(HostelLoginModel hm)
        {
            try
            {                
                SqlCommand cmd = _global.Connection();
                cmd.CommandText = "PR_Hostel_Login";
                cmd.Parameters.AddWithValue("UserName", hm.UserName);
                cmd.Parameters.AddWithValue("Password", hm.Password);
                
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) return true;
                else return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateHostelPassword(HostelUpdatePasswordModel hm)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PR_Hostel_ChangePassword";
                cmd.Parameters.AddWithValue("HostelId", hm.HostelID);
                cmd.Parameters.AddWithValue("CurrentPassword", hm.CurrentPassword);
                cmd.Parameters.AddWithValue("NewPassword", hm.NewPassword);
                cmd.Parameters.AddWithValue("ConfirmPassword", hm.ConfirmPassword);


                int rowsAffected = cmd.ExecuteNonQuery(); 

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
