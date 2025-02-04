using EliteCore.Models;
using System.Net.Mail;
using System.Net;

namespace EliteCore.Services
{
    public class GelenMailService
    {
        private readonly EliteDbContext eliteDbContext;
        public GelenMailService(EliteDbContext eliteDbContext)
        {
            this.eliteDbContext = eliteDbContext;
        }


        public async Task<bool> EkleAsync(GelenMail gelenMail)
        {
            try
            {
                await eliteDbContext.GelenMailler.AddAsync(gelenMail);
                await eliteDbContext.SaveChangesAsync();

                // Mail gönderme işlemi başarılı olursa
                bool mailGonderildi = await MailGonderAsync(gelenMail);
                return mailGonderildi; // Mail gönderildi mi? Evet ise true döner, hayır ise false döner
            }
            catch (Exception ex)
            {
                // Hata durumunda false döner
                Console.WriteLine($"Hata: {ex.Message}");
                return false;
            }
        }


        private async Task<bool> MailGonderAsync(GelenMail gelenMail)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(gelenMail.KullaniciMail) || !gelenMail.KullaniciMail.Contains("@"))
                {
                    throw new FormatException("Geçersiz e-posta adresi: " + gelenMail.KullaniciMail);
                }
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("berfinbayram1377@gmail.com"),
                    Subject = "Yeni Gelen Mesaj",
                    Body = $"📩 Websiteden yeni bir mesaj alındı! Müşteri form bilgileri aşağıdadır; \n\n" +
                           $"👤 Gönderen: {gelenMail.Ad} {gelenMail.Soyad}\n" +
                           $"✉ E-Posta: {gelenMail.KullaniciMail}\n" +
                           $"💬 Mesaj: {gelenMail.GelenMesaj}\n" +
                           $"📱 Telefon: {gelenMail.Telefon}",
                    IsBodyHtml = false
                };

                //mail.To.Add("bilgi@ankaraeliteshuttle.com");
                mail.To.Add("berfinbayram1377@gmail.com");

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("berfinbayram1377@gmail.com", "zpmf umpb sjgl glbq"); 
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;

                    await smtp.SendMailAsync(mail);
                }

                // Eğer mail gönderimi başarılı olduysa true döner
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mail gönderme hatası: {ex.Message}");
                // Mail gönderimi başarısız olursa false döner
                return false;
            }
        }
    }
}
