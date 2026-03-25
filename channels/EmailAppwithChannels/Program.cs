
using EmailAppwithChannels;
using EmailAppwithChannels.Services;
using System.Threading.Channels;
public class Program
{
    //public static void Main()
    //{
    //    var service = new EmailService();

    //    Console.WriteLine("User registered");

    //    service.SendEmail("user1@gmail.com", "Hello");
    //await service.SendEmailAsync("user1@gmail.com", "Hello");

    //    Console.WriteLine("Process Completed");
    //}

    public async static Task Main()
    {
        await Boundedchannel.BoundedMethod();

        //    await UnboundedChannels.UnboundedMain();
    }


}
