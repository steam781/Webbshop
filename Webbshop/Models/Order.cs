using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Webbshop.Models;
using System.Security.Cryptography;


    public class Order
    {
        public int id { get; set; }
        public DateTime orderDate { get; set; }

        public Kund customer { get; set; }

        public string? orderStatus { get; set; }

        public List<Produkt> purchasinglist { get; set; }

        public static List<Order> getAllOrder()
        {
            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";
            List<Order> orders = new List<Order>();
            MySqlConnection conn = new MySqlConnection(conStr);
            conn.Open();
            MySqlCommand MyCom = new MySqlCommand("Select * from Orders", conn);
            MySqlDataReader reader = MyCom.ExecuteReader(); 
            while (reader.Read())
                                   
            {
                Order ord = new Order(); 
                ord.id = reader.GetInt32("id");  
                ord.orderDate = reader.GetDateTime("orderDate");
                ord.orderStatus = reader.GetString("orderStatus");

                int KundID = reader.GetInt32("id");
                Kund k = Kund.getSingleKundById(KundID);
                ord.customer = k;
                string[] prId = reader.GetString("purchasinglist").Split(",");

                List<Produkt> prList = new List<Produkt>();
                foreach (string pr in prId)
                {
                    prList.Add(Produkt.getSingleProduktById(int.Parse(pr)));
                }
                ord.purchasinglist = prList;
                orders.Add(ord);                
            }

            MyCom.Dispose();  
            conn.Close();  


            return orders;
        }
        public static Order getSingleOrderById(int id)
        {
            string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";
            List<Order> orders = new List<Order>();
            MySqlConnection conn = new MySqlConnection(conStr);
            conn.Open();
            MySqlCommand MyCom = new MySqlCommand("Select * from Orders WHERE id = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", id);
            MySqlDataReader reader = MyCom.ExecuteReader();

            Order singleO = new Order();
            singleO.purchasinglist = new List<Produkt>(); 
            if (reader.Read())
            {
                singleO.id = reader.GetInt32("id");
                int customerId = reader.GetInt32("customer");
                singleO.customer = Kund.getSingleKundById(customerId);
                singleO.orderDate = reader.GetDateTime("orderDate");
                singleO.orderStatus = reader.GetString("orderStatus");
                string[] prId = reader.GetString("purchasinglist").Split(",");
                foreach(string s in prId)
                {
                    Produkt p = Produkt.getSingleProduktById(int.Parse(s));
                    singleO.purchasinglist.Add(p);
                }

            }
            

            MyCom.Dispose();
            conn.Close();

            return singleO;
        }
    public static void deleteProductInOrder(int orderID, int produktID)
    {
        string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";
        List<Order> orders = new List<Order>();
        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        MySqlCommand MyCom = new MySqlCommand("Select purchasinglist from Orders WHERE id = @ID", conn);
        MyCom.Parameters.AddWithValue("@ID", orderID);
        MySqlDataReader reader = MyCom.ExecuteReader();

        reader.Read();
        string l = reader.GetString("purchasinglist");
        l = l.Replace(produktID + ",","");
        l = l.Replace(produktID.ToString() , "");
        MyCom.Dispose();
        conn.Close();


        conn = new MySqlConnection(conStr);
        conn.Open();
        MySqlCommand MyCom2 = new MySqlCommand("UPDATE Orders SET purchasinglist = @LIST WHERE id = @ID", conn);
        MyCom2.Parameters.AddWithValue("@ID", orderID);
        MyCom2.Parameters.AddWithValue("@LIST", l);
        MyCom2.ExecuteNonQuery();

        
        MyCom2.Dispose();
        conn.Close();
    }
    public static void addProductInOrder(int orderID, int produktID)
    {
        string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";
        List<Order> orders = new List<Order>();
        MySqlConnection conn = new MySqlConnection(conStr);
        conn.Open();
        MySqlCommand MyCom = new MySqlCommand("Select purchasinglist from Orders WHERE id = @ID", conn);
        MyCom.Parameters.AddWithValue("@ID", orderID);
        MySqlDataReader reader = MyCom.ExecuteReader();

        reader.Read();
        string l = reader.GetString("purchasinglist");
        l = produktID.ToString() + ",";
        MyCom.Dispose();
        conn.Close();


        conn = new MySqlConnection(conStr);
        conn.Open();
        MySqlCommand MyCom2 = new MySqlCommand("UPDATE Orders SET purchasinglist = @LIST WHERE id = @ID", conn);
        MyCom2.Parameters.AddWithValue("@ID", orderID);
        MyCom2.Parameters.AddWithValue("@LIST", l);
        MyCom2.ExecuteNonQuery();


        MyCom2.Dispose();
        conn.Close();
    }
    public static bool sparaOrder(Order O)
    {

        string conStr = "server=46.246.45.183;user=OliverEc;port=3306;database=OliverEc_DB;password=YROSBKEE";

        MySqlConnection conn = new MySqlConnection(conStr);
        MySqlCommand MyCom = new MySqlCommand("UPDATE Orders set orderStatus = @STATUS, orderDate = @DATE, purchasinglist = @LIST where id = @ID ", conn);
        MyCom.Parameters.AddWithValue("@ID", O.id);
        MyCom.Parameters.AddWithValue("@STATUS", O.orderStatus);
        MyCom.Parameters.AddWithValue("@DATE", O.orderDate);
        MyCom.Parameters.AddWithValue("@LIST", O.purchasinglist);
        conn.Open();

        int rader = MyCom.ExecuteNonQuery();

        MyCom.Dispose();
        conn.Close();

        if (rader == 0) return false; else return true;


    }
}
