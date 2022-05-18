using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Worker1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                string path = @"C\ServiceTest\";

                Directory.CreateDirectory(path);

                path += "ouput.txt";

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"services worker: {DateTime.Now}");
                }

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
