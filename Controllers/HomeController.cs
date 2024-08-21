﻿using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace NewsletterAppMVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress)
        {

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (NewsletterEntities1 db = new NewsletterEntities1()) {
                    var signup = new SignUp();
                    signup.FirstName = firstName;
                    signup.LastName = lastName; 
                    signup.EmailAddress = emailAddress;

                    db.SignUps.Add(signup);
                    db.SaveChanges();
                }
                //string queryString = @"INSERT INTO SignUps (FirstName, LastName, EmailAddress) VALUES (@FirstName, @LastName, @EmailAddress)";

                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    SqlCommand command = new SqlCommand(queryString, connection);
                //    command.Parameters.Add("@Firstname", SqlDbType.VarChar);
                //    command.Parameters.Add("@Lastname", SqlDbType.VarChar);
                //    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);

                //    command.Parameters["@FirstName"].Value = firstName;
                //    command.Parameters["@LastName"].Value = lastName;
                //    command.Parameters["@EmailAddress"].Value = emailAddress;

                //    connection.Open();
                //    command.ExecuteNonQuery();
                //    connection.Close();
                //}

                return View("Success");
            }
        }
    }
}