﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMuaBanXeMay.Class
{
    public class MY_DB
    {

        //static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q1R3HVB;Initial Catalog=QLXePT;Integrated Security=True;Encrypt=False");

        //static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q1R3HVB;Initial Catalog=QLXePT;Integrated Security=True;Encrypt=False");
        //static SqlConnection con = new SqlConnection(@"Data Source=HONGSON;Initial Catalog=QLXePT;Integrated Security=True");

        //static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q1R3HVB;Initial Catalog=QLXePT;Integrated Security=True;Encrypt=False");
        //static SqlConnection con = new SqlConnection(@"Data Source=HONGSON;Initial Catalog=QLXePT;Integrated Security=True");
        static SqlConnection con = new SqlConnection(@"Data Source=MINHTRI\SQLEXPRESS;Initial Catalog=QLXePT;Integrated Security=True;TrustServerCertificate=True");


        static public SqlConnection getConnection()
        {
             return con;
        }
        static public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        static public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        static public void setConnectionNV()
        {
            //con = new SqlConnection(@"Data Source=DESKTOP-Q1R3HVB;Initial Catalog=QLXePT;User Id=" + DangNhap.username + ";Password=" + DangNhap.password + ";");
            con = new SqlConnection(@"Data Source=MINHTRI\SQLEXPRESS;Initial Catalog=QLXePT;User Id=" + DangNhap.username + ";Password=" + DangNhap.password + ";");
        }
    }
}
