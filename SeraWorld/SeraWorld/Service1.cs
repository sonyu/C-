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
            createOrderTimer.Interval = 120;
            createOrderTimer.Enabled = true;
            createOrderTimer.AutoReset = true;
            createOrderTimer.Start();

        }

        protected override void OnStop()
        {
        }


        public void GetMail(object sender, System.Timers.ElapsedEventArgs args)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential cred = new NetworkCredential("modungchu@gmail.com", "29031985");
            MailMessage msg = new MailMessage();
            msg.To.Add("khanhzic@gmail.com");
            msg.Subject = "thanh cong roi";

            msg.Body = "You Have Successfully Entered To Sera's World!!!";
            msg.From = new MailAddress("modungchu@gmail.com"); // Your Email Id
           
            SmtpClient client1 = new SmtpClient("smtp.mail.yahoo.com", 465);
            client.Credentials = cred;
            client.EnableSsl = true;
            client.Send(msg);

        }
    }
}
