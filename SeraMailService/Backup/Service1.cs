using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace SeraWorld
{
    public partial class SeraMailer : ServiceBase
    {
        System.Timers.Timer createOrderTimer;

        public SeraMailer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            createOrderTimer = new System.Timers.Timer();
            createOrderTimer.Elapsed += new System.Timers.ElapsedEventHandler(GetMail);
            createOrderTimer.Interval = 500;
            createOrderTimer.Enabled = true;
            createOrderTimer.AutoReset = true;
            createOrderTimer.Start();

        }

        protected override void OnStop()
        {
        }


        public void GetMail(object sender, System.Timers.ElapsedEventArgs args)
        {
            NetworkCredential cred = new NetworkCredential("email@apsissolutions.com", "password");
            MailMessage msg = new MailMessage();
            msg.To.Add("email@apsissolutions.com");
            msg.Subject = "Welcome JUBAYER";

            msg.Body = "You Have Successfully Entered To Sera's World!!!";
            msg.From = new MailAddress("email@apsissolutions.com"); // Your Email Id
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            SmtpClient client1 = new SmtpClient("smtp.mail.yahoo.com", 465);
            client.Credentials = cred;
            client.EnableSsl = true;
            client.Send(msg);
        }
    }
}
