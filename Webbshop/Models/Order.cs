using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Webbshop.Models;

namespace MVCExampleProjekt.Models
{
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
            MySqlConnection conn = new MySqlConnection(conStr); // skapa förbindelse 'conn' till databasen
            conn.Open(); // öppna kanal till databasen
            MySqlCommand MyCom = new MySqlCommand("Select * from Orders", conn); // skapa sql-sats för 'conn'
            MySqlDataReader reader = MyCom.ExecuteReader();  // skicka satsen till DB och spara svaret i 'reader'
            while (reader.Read())  // while håller på tills ingen data kvar
                                   // en omgång per rad i databastabellen
            {
                Order ord = new Order(); // Skapa ny objekt av typen Order
                ord.id = reader.GetInt32("id");  // hämta värde från kolumnen 'id'
                ord.orderDate = reader.GetDateTime("orderDate");// hämta värde från kolumnen 'orderDate'
                ord.orderStatus = reader.GetString("orderStatus");  // ...

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
                orders.Add(ord);                // spara objektet i listan 
            }

            MyCom.Dispose();  // släng förbindelse
            conn.Close();  // stäng kanalen till DB


            return orders;
        }
      //  public string Order getSingleOrderById(int id)
        //{ }
    }
}