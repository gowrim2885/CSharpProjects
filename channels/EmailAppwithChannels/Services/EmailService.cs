using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailAppwithChannels.Services
{
    internal class EmailService
    {
        //public void SendEmail(string to , string message)
        //{
        //    Counting();
        //    Console.WriteLine($"Email sent to {to}");
        //}

        public async Task SendEmailAsync(string to, string message)
        {
            await Task.Delay(3000);
            Console.WriteLine( $"Email sent to {to} ");
        }
        
    }
}
