using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using Webbshop.Models;

namespace Webbshop.Models
{
    public class Employee
    {
        public int id { get; set; } = 0;
        public string name { get; set; } = "";
        public string mailadress { get; set; } = "";
        public string password { get; set; } = "";
        public string role { get; set; } = "";

        public static Employee GetEmployeeByMail(string mail)
        {
            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";
            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Employee where mailadress = @MAIL", conn);
            MyCom.Parameters.AddWithValue("@MAIL", mail);
            conn.Open();
            MySqlDataReader reader = MyCom.ExecuteReader();
            Employee singleE = new Employee();
            if (reader.Read())
            {
                singleE.id = reader.GetInt32("id");
                singleE.name = reader.GetString("name");
                singleE.mailadress = reader.GetString("mailadress");
                singleE.password = reader.GetString("password");
                singleE.role = reader.GetString("role");
            }
            reader.Close();
            MyCom.Dispose();
            conn.Close();
            return singleE;
        }
    }
}


