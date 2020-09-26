using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WepApi1.Models
{
    public class ApuestasRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }
        internal List<Apuesta> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Apuestas";
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                Apuesta a = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (res.Read())
                {
                    Debug.WriteLine("recuperamos: " + res.GetInt32(0) + " " + res.GetString(1)
                                    + " " + res.GetInt32(2) + " " + res.GetString(3) + " " + 
                                    res.GetFloat(4) + " " + res.GetInt32(5) + " " + res.GetDateTime(6));
                    a = new Apuesta(res.GetInt32(0), res.GetString(1), res.GetInt32(2), res.GetString(3), res.GetFloat(4), res.GetInt32(5), res.GetDateTime(6));
                    apuestas.Add(a);
                }
                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexión");
                return null;


            }

        }
    }
}