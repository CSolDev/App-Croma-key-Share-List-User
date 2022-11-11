using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;


namespace ESN
{
    public class EMailSender
    {

        private SmtpClient mSmtpServer;

        public EMailSender(string username, string password, string smtpServerAddress, int port = 25, bool enableSSL = false, bool useDefaultCredentials = false)
        {

            mSmtpServer = new SmtpClient(smtpServerAddress);
            mSmtpServer.EnableSsl = enableSSL;
            mSmtpServer.UseDefaultCredentials = useDefaultCredentials;
            mSmtpServer.Port = port;
            mSmtpServer.Credentials = new System.Net.NetworkCredential(username, password) as ICredentialsByHost;
            if (enableSSL)
            {
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    { return true; };
            }
        }


        public void SendMailParticipante(string from, string fromName, string to, string subject, string messaget, SendCompletedEventHandler onComplete = null, string attachmentName = "", string attachmentKind = "image/jpg")
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(from, fromName);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = messaget;

            if (attachmentName != "")
            {
                mail.Attachments.Add(new Attachment(attachmentName, attachmentKind));
            }

            if (onComplete != null)
            {
                mSmtpServer.SendCompleted += onComplete;
            }

            try
            {
                mSmtpServer.SendAsync(mail, null);
                Debug.Log("Ok ");

            }
            catch (Exception ex)
            {
                Debug.Log("Excepcion mientras se enviaba el email -smtpServer.Send(mail)-: " + ex);
            }
        }




        public void SendMailEmpresa(string from, string fromName, string to, string subject, string body1, string body2, string body3, string body4, SendCompletedEventHandler onComplete = null, string attachmentName = "", string attachmentKind = "image/jpg")
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(from, fromName);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = "Nombre: " + body1 + "\n" + "Fecha de Nacimiento: " + body2 + "\n" + "Numero de Telefono: " + body3 + "\n" + "Email: " + body4;

            if (attachmentName != "")
            {
                mail.Attachments.Add(new Attachment(attachmentName, attachmentKind));
            }

            if (onComplete != null)
            {
                mSmtpServer.SendCompleted += onComplete;
            }

            try
            {
                mSmtpServer.SendAsync(mail, null);
                Debug.Log("Ok ");

            }
            catch (Exception ex)
            {
                Debug.Log("Excepcion mientras se enviaba el email -smtpServer.Send(mail)-: " + ex);
            }
        }

    }
}
