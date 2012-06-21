using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoPs.Infrasctructure.Email
{
    public class EmailSettings
    {
        public string MailFromAddress = "popsservice@gmail.com";
        public bool UseSsl = true;
        public string Username = "popsservice@gmail.com";
        public string Password = "ortinssena";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\sports_store_emails";
    }
}
