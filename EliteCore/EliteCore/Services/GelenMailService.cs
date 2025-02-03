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


        public async Task<GelenMail> EkleAsync(GelenMail gelenMail)
        {
            try
            {
                await eliteDbContext.GelenMailler.AddAsync(gelenMail);
                await eliteDbContext.SaveChangesAsync();

                // Mail atılacak
                await MailGonderAsync(gelenMail);

                return gelenMail;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            

        
        }

        private async Task MailGonderAsync(GelenMail gelenMail)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("gonderen@gmail.com", "uygulama_sifresi");
                    smtp.EnableSsl = true;

                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress("gonderen@gmail.com"),
                        Subject = "Yeni Gelen Mesaj",
                        Body = $"📩 Yeni bir mesaj alındı!\n\n" +
                               $"👤 Gönderen: {gelenMail.Ad} {gelenMail.Soyad}\n" +
                               $"✉ E-Posta: {gelenMail.KullaniciMail}\n" +
                               $"💬 Mesaj: {gelenMail.GelenMesaj}",
                        IsBodyHtml = false
                    };

                    // Mesajın yönlendirileceği adres (bilgi@ankaraeliteshuttle.com)
                    mail.To.Add("bilgi@ankaraeliteshuttle.com");

                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mail gönderme hatası: {ex.Message}");
            }
        }


    }
}
