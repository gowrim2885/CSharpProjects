using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Orders
{
    public class OrderChannel
    {
        private readonly Channel<Order> _channel;

        public OrderChannel()
        {
            var option = new BoundedChannelOptions(3)
            {
                FullMode = BoundedChannelFullMode.Wait
            };

            _channel = Channel.CreateBounded<Order>(option);
        }

        public async Task WriteAsync(Order order)
        {
            await _channel.Writer.WriteAsync(order);
        }

        public IAsyncEnumerable<Order> ReadAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }

        public void WriteComplete()
        {
            _channel.Writer.Complete();
        }
    }
}
