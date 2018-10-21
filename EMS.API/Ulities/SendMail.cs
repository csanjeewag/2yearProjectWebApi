using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace EMS.API.Ulities
{
    

    public class SendMail
    {
        public static int RandNumber()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            
                int numIterations = rand.Next(10000, 99999);

            return numIterations;

        }

        public static Boolean SendEmail(string sender, string subject, string body)
        {
            var rand = RandNumber();
            try {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("csanjeewag@gmail.com", "sanjeewa96");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("csanjeewag@gmail.com");
                mailMessage.To.Add(sender);
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = subject;
                client.Send(mailMessage);

                return true;
            } catch {
                return false;
            }
            
        }

        public static Boolean SendloginCode(string code,string email)
        {
            string subject = "Event manement System in Creative Software!";
            string body = "<html><h2>You are going to login, Event management system," +
                " you should use this code </h2><h1>" + code + "</h1> <h2>for finish registration.</h2></html>"+
                " <h2><a href="+"http://localhost:4200/profile/login"+"> login</a></h2>" +
                " <img  style ="+"width:400px"+" src="+"https://images.pexels.com/photos/7097/people-coffee-tea-meeting.jpg"+">";
                



          return  SendEmail(email, subject, body);
            
        }
        
    }
}
