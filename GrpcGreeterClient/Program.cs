using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client =  new Greeter.GreeterClient(channel);
            while(true)
            {
                AdditionRequest req = new AdditionRequest();
                while(true)
                {
                    try
                    {
                        Console.Write("Please input value 1 : ");
                        req.Value1 = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch{
                        Console.WriteLine("Please input numerical values only!");
                    }
                }
                while(true)
                {
                    try
                    {
                        Console.Write("Please input value 2 : ");
                        req.Value2 = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch{
                        Console.WriteLine("Please input numerical values only!");
                    }
                }
                var reply = await client.SayAdditionAsync(req);
                Console.WriteLine("Result : " + reply.Result.ToString());
                Console.Write("Enter 0 to exit : ");
                if(Console.ReadLine()=="0")
                {
                    break;
                }
            }
        }
    }
}
