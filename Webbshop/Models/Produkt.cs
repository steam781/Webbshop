using Webbshop.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace Webbshop.Models
{
    public class Produkt
    {
        public string produktnamn { get; set; } = "";
        public string produktinfo { get; set; } = "";
        public string tillverkare { get; set; } = "";
        public int stock { get; set; } = 0;
        public double pris { get; set; } = 0;
        public int id { get; set; } = 0;

        public static List<Produkt> getAllProdukt()
        {
            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";

            List<Produkt> list = new List<Produkt>();
            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Produkt", conn);

            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            while (reader.Read())
            {
                Produkt p = new Produkt();
                p.id = reader.GetInt32("id");
                p.produktnamn = reader.GetString("produktnamn");
                p.tillverkare = reader.GetString("tillverkare");
                p.produktinfo = reader.GetString("produktinfo");
                p.stock = reader.GetInt32("stock");
                p.pris = reader.GetDouble("pris");
                list.Add(p);
            }

            MyCom.Dispose();
            conn.Close();

            return list;
        }

        public static Produkt getSingleProduktById(int id)
        {

            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from Produkt where id = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", id);
            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            Produkt singleP = new Produkt();
            if (reader.Read())
            {
                singleP.id = reader.GetInt32("id");
                singleP.produktnamn = reader.GetString("produktnamn");
                singleP.tillverkare = reader.GetString("tillverkare");
                singleP.produktinfo = reader.GetString("produktinfo");
                singleP.stock = reader.GetInt32("stock");
                singleP.pris = reader.GetDouble("pris");

            }

            MyCom.Dispose();
            conn.Close();

            return singleP;
        }

        public static bool sparaProdukt(Produkt p)
        {

            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("UPDATE Produkt set produktnamn = @PRNAMN, tillverkare = @TILL, produktinfo = @INFO, stock = @STOCK, pris = @PRIS where id = @ID ", conn);
            MyCom.Parameters.AddWithValue("@PRNAMN", p.produktnamn);
            MyCom.Parameters.AddWithValue("@TILL", p.tillverkare);
            MyCom.Parameters.AddWithValue("@INFO", p.produktinfo);
            MyCom.Parameters.AddWithValue("@STOCK", p.stock);
            MyCom.Parameters.AddWithValue("@PRIS", p.pris);
            MyCom.Parameters.AddWithValue("@ID", p.id);
            conn.Open();

            int rader = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true;


        }
        public static bool sparanyProdukt(Produkt p)
        {

            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("INSERT INTO Produkt(produktnamn, produktinfo, stock, tillverkare, pris) VALUES (@PRNAMN, @TILL, @INFO, @STOCK, @PRIS)", conn);
            MyCom.Parameters.AddWithValue("@PRNAMN", p.produktnamn);
            MyCom.Parameters.AddWithValue("@TILL", p.tillverkare);
            MyCom.Parameters.AddWithValue("@INFO", p.produktinfo);
            MyCom.Parameters.AddWithValue("@STOCK", p.stock);
            MyCom.Parameters.AddWithValue("@PRIS", p.pris);
            conn.Open();

            int rader = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true;


        }
        public static bool deleteProdukt(Produkt p)
        {

            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("DELETE FROM Produkt WHERE id = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", p.id);
            conn.Open();

            int rader = MyCom.ExecuteNonQuery();

            MyCom.Dispose();
            conn.Close();

            if (rader == 0) return false; else return true;


        }

    }

}
