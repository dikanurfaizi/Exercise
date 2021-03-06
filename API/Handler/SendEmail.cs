using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace API.Handler
{
    public class SendEmail
    {
        public void SendForgotPassword(string resetCode, string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("1997HelloWorld1997@gmail.com", "Leave Request Reset Password");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Reset Password " + time24;
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi " + "\nThis is new password for your account. " + resetCode + "\nThank You";
            smtp.Send(mailMessage);
        }
        public void SendRegister(string email)
        {
            var newPass = Guid.NewGuid().ToString();
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("dikarandika.rn@gmail.com", "@Qwerty12345678");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("dikarandika.rn@gmail.com", "@Qwerty12345678");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("dikarandika.rn@gmail.com", "Register Leave Request");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Reset Password " + time24;
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi, " + "\nyour account has been active. " + "\n\nPassword : " + newPass + "\nThank You";
            smtp.Send(mailMessage);
        }
        public void SendRequestEmployee(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("1997HelloWorld1997@gmail.com", "Leave Request");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Leave Request " + time24;
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi, " + "\nThank You For You Request. Your Request Is Being Processed. " + "\nThank You";
            smtp.Send(mailMessage);
        }

        public void SendRequestHRD(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("1997HelloWorld1997@gmail.com", "Approval Leave Request");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Approval Leave Request From HRD " + time24;
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi " + "\n, Employee Has Been Request. Please Approve Or Reject Employee Request " + "\nThank You";
            smtp.Send(mailMessage);
        }
        public void SendApproveHRD(string email, int IdRequest)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("1997HelloWorld1997@gmail.com", "Approval HRD");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Approval From HRD " + time24;
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi! " + "\n HRD Has Been Approve with Id Request " + IdRequest + "\n. Please Approve Or Reject Employee Request " + "\nThank You";
            smtp.Send(mailMessage);
        }

        public void SendApproveManager(string email, int IdRequest)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("1997HelloWorld1997@gmail.com", "Approval Request");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Approval Request " + time24;
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi! " + "\n Your Request Has Been Approve with Id Request " + IdRequest + "\nThank You";
            smtp.Send(mailMessage);
        }

        public void SendReject(string email, int IdRequest)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("1997HelloWorld1997@gmail.com", "wwwsawwwsdwwwszwwwsx");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("1997HelloWorld1997@gmail.com", "Approval Request");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Approval Request " + time24;
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi! " + "\n Sorry Your Request Has Been Reject with Id Request " + IdRequest + "\nThank You";
            smtp.Send(mailMessage);
        }
    }
}
