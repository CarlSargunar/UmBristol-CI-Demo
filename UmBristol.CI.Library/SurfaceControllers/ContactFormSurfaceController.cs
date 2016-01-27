using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmBristol.CI.Library.Constants;
using UmBristol.CI.Library.ViewModels;

namespace UmBristol.CI.Library.SurfaceControllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        /// <summary>
        /// escape that won't throw exception with null string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected static string SafeEscape(string input)
        {
            return string.IsNullOrEmpty(input) ? string.Empty : Uri.EscapeDataString(input);
        }

        

        [System.Web.Http.HttpPost]
        public ActionResult ContactForm(ContactFormViewModel model)
        {
            //model not valid, do not save, but return current umbraco page
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("website@company.com");
                mail.To.Add("hello@company.com");
                mail.Subject = "Website Contact Request";
                mail.Body = string.Format("Contact form Received : /r/n Name : {0} {1}/r/n Email : {2}/r/nComments : {3}/r/nMarketing Opt In :{4}",
                    model.FirstName, model.LastName, model.Email, model.Comments, model.MarketingOptIn);
                mail.IsBodyHtml = false;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
            }
            
            TempData[TempDataKeys.FormSubmitted] = true;
            TempData[TempDataKeys.ThankYouMessage] = "Thank you for your enquiry. A Hitachi Capital Vehicle Solutions representative will respond to you within 4 working hours (applies 9.00AM – 5.30PM, Monday to Friday).";
            return RedirectToCurrentUmbracoPage();
        }
        
    }
}
