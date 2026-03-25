using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EmailAppwithChannels
{
    public class UnboundedChannels
    {
        public static async Task UnboundedMain()
        {
            var channel = Channel.CreateUnbounded<int>();


            var producer = Task.Run(async () =>
            {
                for (int i = 1; i < 5; i++)
                {
                    await channel.Writer.WriteAsync(i);
                    Console.WriteLine($"Produced: {i}");
                    await Task.Delay(3000);
                }
                channel.Writer.Complete();
            });

            var consumer = Task.Run(async () =>
            {
                await foreach (var item in channel.Reader.ReadAllAsync())
                {
                    Console.WriteLine($"Consumed: {item}");

                }
            });

            await Task.WhenAll(producer, consumer);

        }
    }
}
