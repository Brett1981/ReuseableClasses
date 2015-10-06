using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Threading;

namespace Re_useable_Classes.Emailing
{
    public class EmailHelper
    {
        public static void OpenDefaultEmailClient
            (
            string attachmentPath,
            string mailSubject,
            string messageTest,
            List<string> toAddresses = null)
        {
            //
            var mailMessage = new MailMessage();
            string strTempEmailFile = Path.Combine
                (
                    SystemHelper.CreateGetProgramDataPath(),
                    ("TempEMLEmail" + Guid.NewGuid() + ".eml"));

            //Mail message object
            mailMessage.From = new MailAddress("test@test.com");
            mailMessage.Subject = mailSubject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<font face=\"arial\" size=\"2\">" + messageTest + "<\\font>";

            //Add to users if available
            if (toAddresses != null && toAddresses.Count > 0)
            {
                foreach (string strToAddressLoopVariable in toAddresses)
                {
                    string strToAddress = strToAddressLoopVariable;
                    mailMessage.To.Add(strToAddress);
                }
            }

            //Add attachments
            mailMessage.Attachments.Add(new Attachment(attachmentPath));

            //Save the MailMessage to the filesystem as an eml file
            //mailMessage.Save(strTempEmailFile);

            //Remove from sender to stop issues with security
            // File.WriteAllText(strTempEmailFile, File.ReadAllText(strTempEmailFile).Replace("From: test@test.com" + Environment.NewLine, ""), false, Encoding.Default);

            //Open the file with the default associated application registered on the local machine
            Process.Start(strTempEmailFile);

            //Delay for load of email
            Thread.Sleep(3000);

            //Delete templ file
            if (File.Exists(strTempEmailFile))
            {
                File.Delete(strTempEmailFile);
            }
        }
    }
}
