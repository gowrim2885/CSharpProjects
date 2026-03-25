using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Orders
{
    public class OrderService
    {
        private readonly OrderChannel _channel;

        public OrderService(OrderChannel channel)
        {
            _channel = channel;
        }

        public async Task PlaceOrder(Order order)
        {
            Console.WriteLine($"Received Order: {order.OrderId}");

            await _channel.WriteAsync(order);

            Console.WriteLine($"Queued Order:{order.OrderId}");
        }
    }
}
