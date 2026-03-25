using Orders;

class Program
{
    static async Task Main()
    {
        var channel = new OrderChannel();
        var service = new OrderService(channel); //Write Async  --> producer
        var worker = new OrderWorker(channel); // Read Async   ---> Consumer

        var workerTask = Task.Run(() => worker.StartAsync());

        for(int i=1; i<=10; i++)
        {
            var order = new Order
            {
                OrderId = i,
                Item = ($"Item-{i}")
            };

            await service.PlaceOrder(order);

            channel.WriteComplete();

            await workerTask;
        }
    }
} 