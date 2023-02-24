using Webbshop.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Webbshop.Models
{
    public class Kund
    {
        public int id { get; set; } = 0;
        public string realname { get; set; } = "";
        public string username { get; set; } = "";
        public string password { get; set; } = "";
        public string mail { get; set; } = "";
        public int phoneNr { get; set; } = 0;
        public string adress { get; set; } = "";
        public int age { get; set; } = 0;
        public double balance { get; set; } = 0;

        public static List<Kund> getAllKund()
        {
            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";

            List<Kund> list = new List<Kund>();
            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Kund", conn);

            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            while (reader.Read())
            {
                Kund k = new Kund();
                k.id = reader.GetInt32("id");
                k.username = reader.GetString("username");
                k.password = reader.GetString("password");
                k.mail = reader.GetString("mail");
                k.phoneNr = reader.GetInt32("phoneNr");
                k.adress = reader.GetString("adress");
                k.age = reader.GetInt32("age");
                k.balance = reader.GetDouble("balance");
                k.realname = reader.GetString("realname");
                list.Add(k);
            }

            MyCom.Dispose();
            conn.Close();

            return list;
        }

        public static Kund getSingleKundById(int id)
        {

            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Kund where id = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", id);
            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            Kund singleK = new Kund();
            if (reader.Read())
            {
                singleK.id = reader.GetInt32("id");
                singleK.username = reader.GetString("username");
                singleK.password = reader.GetString("password");
                singleK.mail = reader.GetString("mail");
                singleK.phoneNr = reader.GetInt32("phoneNr");
                singleK.adress = reader.GetString("adress");
                singleK.age = reader.GetInt32("age");
                singleK.balance = reader.GetDouble("balance");
                singleK.realname = reader.GetString("realname");

            }

            MyCom.Dispose();
            conn.Close();

            return singleK;
        }

        public static bool sparaKund(Kund K)
        {

            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("UPDATE Kund set realname = @NAME, username = @USER, password = @PASS, mail = @MAIL, phoneNr = @PHONE, adress = @ADRESS, age = @AGE, balance = @MONEY where id = @ID ", conn);
            MyCom.Parameters.AddWithValue("@NAME", K.realname);
            MyCom.Parameters.AddWithValue("@USER", K.username);
            MyCom.Parameters.AddWithValue("PASS", K.password);
            MyCom.Parameters.AddWithValue("@MAIL", K.mail);
            MyCom.Parameters.AddWithValue("@PHONE", K.phoneNr);
            MyCom.Parameters.AddWithValue("@ADRESS", K.adress);
            MyCom.Parameters.AddWithValue("@AGE", K.age);
            MyCom.Parameters.AddWithValue("@MONEY", K.balance);
            MyCom.Parameters.AddWithValue("@ID", K.id);
            conn.Open();

            int rader = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true;


        }
        public static bool sparanyKund(Kund K)
        {

            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("INSERT INTO Kund(realname, username, password, mail, phoneNr, adress, age, balance) VALUES (@NAME, @USER, @PASS, @MAIL, @PHONE, @ADRESS, @AGE, @MONEY)", conn);
            MyCom.Parameters.AddWithValue("@NAME", K.realname);
            MyCom.Parameters.AddWithValue("@USER", K.username);
            MyCom.Parameters.AddWithValue("@PASS", K.password);
            MyCom.Parameters.AddWithValue("@MAIL", K.mail);
            MyCom.Parameters.AddWithValue("@PHONE", K.phoneNr);
            MyCom.Parameters.AddWithValue("@ADRESS", K.adress);
            MyCom.Parameters.AddWithValue("@AGE", K.age);
            MyCom.Parameters.AddWithValue("@MONEY", K.balance);
            conn.Open();

            int rader = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true;


        }
        public static bool deleteKund(Kund K)
        {

            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("DELETE FROM Kund WHERE id = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", K.id);
            conn.Open();

            int rader = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true;


        }

    }

}
