using Grpc.Core;
using GrpcServiceDemo;
using NETGrpcServiceDemo.Protos;
using System.Linq;

namespace NETGrpcServiceDemo.Services
{
    public class DemoService : Demo.DemoBase
    {
        private readonly ILogger<DemoService> _logger;
        public DemoService(ILogger<DemoService> logger)
        {
            _logger = logger;
        }

        public override Task<DemoResponse> DemoRPC(DemoRequest request, ServerCallContext context)
        {
            List<string> values = new List<string>() { "one", "two", "three", "four", "five" };
            return Task.FromResult(new DemoResponse
            {
                DemoList = string.Join(", ", values.Take(int.Parse(request.DesiredResults.ToString())).ToList())
            }); 
        }
    }
}
