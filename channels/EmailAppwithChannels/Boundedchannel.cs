using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace EmailAppwithChannels
{
    public class Boundedchannel
    {
        public static async Task BoundedMethod()
        {
            var channel = Channel.CreateBounded<int>(5);

            var producer = Task.Run(async () =>
            {
                for (int i = 0; i <= 50; i++)
                {
                    await channel.Writer.WriteAsync(i);
                    Console.WriteLine($"Process{i}");
                    
                }

                channel.Writer.Complete();
            });

            var consumer = Task.Run(async () =>
            {
                await foreach (int item in channel.Reader.ReadAllAsync())
                {
                    Console.WriteLine($"Consuming {item}");
                    await Task.Delay(2000);
                }
            
            });

            await Task.WhenAll(producer, consumer);
        }


    }
}
