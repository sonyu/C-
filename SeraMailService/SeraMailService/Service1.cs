using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace SeraMailService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            public void GetMail(object sender, System.Timers.ElapsedEventArgs args)
        {
            NetworkCredential cred = new NetworkCredential("email@lafarge.com", "Password");
            MailMessage msg = new MailMessage();
            msg.To.Add("email@apsissolutions.com");
            msg.Subject = "Welcome JUBAYER";

            msg.Body = "You Have Successfully Entered to Sera's World!!!";
            msg.From = new MailAddress("email@apsissolutions.com"); // Your Email Id
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            SmtpClient client1 = new SmtpClient("smtp.mail.yahoo.com", 465);
            client.Credentials = cred;
            client.EnableSsl = true;
            client.Send(msg);
        }
        }

        protected override void OnStop()
        {
        }
    }
}
