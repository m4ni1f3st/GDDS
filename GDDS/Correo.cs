using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Configuration;

namespace GDDS
{
    class Correo
    {
        private MailMessage objEmail;

        private List<string> obtener_mail()
        {
            int h = 1;
            List <string> list = new List<string>();


            var applicationSettings = ConfigurationManager.GetSection("appSettings")
               as NameValueCollection;

            if (applicationSettings.Count == 0)
            {
                Console.WriteLine("Application Settings are not defined");
            }
            else
            {
                foreach (var key in applicationSettings.AllKeys)
                {
                    string v = "Correo" + h;
                    if (v == key)
                    {
                        //Console.WriteLine(key + " = " + applicationSettings[key]);
                        list.Add(applicationSettings[key]);
                    }
                    h++;
                }
            }
            return list;
        }
        public void EnviarCorreo2()
        {

            List<string> ho = new List<string>();
            ho = obtener_mail();
            //foreach (string ho2 in ho)
            //{
            //    Console.WriteLine(" {0}", ho2);
            //}
            objEmail = new MailMessage();
            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            objEmail.From = new MailAddress(smtpSection.From, "Envio GDDS");
            foreach (string ho2 in ho)
            {
                objEmail.To.Add(ho2);
            }
            objEmail.IsBodyHtml = true;
            objEmail.Subject = "Envio exitoso GDDS: " + DateTime.Now;
            objEmail.Body = "Se genero correctamente el archivo GDDS " + DateTime.Now;
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                //Enviamos el mensaje      
                smtpClient.Send(this.objEmail);
                smtpClient.Dispose();
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }
    }
}
