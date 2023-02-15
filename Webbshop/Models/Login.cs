using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Webbshop.Models;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;


public class Login
{

    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

}