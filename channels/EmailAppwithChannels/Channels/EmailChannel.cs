using EmailAppwithChannels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace EmailAppwithChannels.Channels
{
    public class EmailChannel
    {
        private readonly Channel<EmailModel> _channel;


        public EmailChannel()
        {
            _channel = Channel.CreateBounded<EmailModel>(5);
        }

        //public async Task WriteAsync(EmailModel request)
        //{
        //    await _channel.Writer.WriteAsync(request);
        //}

       
    }

}
