using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    public class OrderWorker
    {
        private readonly OrderChannel _channel;

        public OrderWorker(OrderChannel channel)
        {
            _channel = channel;
        }

        public async Task StartAsync()
        {
            await foreach(var order in _channel.ReadAsync())
            {
                Console.WriteLine($" Processing Order: {order.OrderId}");

                await Task.Delay(2000);

                Console.WriteLine($" Processing Order: {order.OrderId}");
            }
        }

    }
}
