using OnlineShopping.Bll.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Bll.Entites;
using System.Net.Mail;
using System.Net;

namespace OnlineShopping.Bll.Concrete
{
    public class EmailOrderProcessor : InterfaceOrderProcessor
    {
        private EmailSettings emailSetting;
        public  EmailOrderProcessor(EmailSettings settings)
        {
            emailSetting = settings;
        }
        public void ProcessOrder(Cart cart, ShippingDetails shipping)
        {
           /* using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSetting.UseSsl;
                smtpClient.Host = emailSetting.ServerName;
                smtpClient.Port = emailSetting.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSetting.Username, emailSetting.Password);

                if (emailSetting.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSetting.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");
                foreach(var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c})", line.Quantity, line.Product.ProductName, subtotal);
                }
                body.AppendFormat("Total Order Value: {0:c}",
                    cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shipping.Name)
                    .AppendLine(shipping.ContactNumber)
                    .AppendLine(shipping.Address)
                    .AppendLine(shipping.District)
                    .AppendLine(shipping.Email)
                    .AppendLine(shipping.Comments)
                    .AppendLine("---")
                    .AppendFormat("Gift Wrap: {0}", shipping.GiftWrap ? "Yes" : "No");
                MailMessage mailMessage = new MailMessage(
                    emailSetting.MailFromAddress,
                    emailSetting.MailToAddress, "New Order Submitted !", body.ToString());

                if (emailSetting.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(mailMessage);

            }*/
        }
    }
}
