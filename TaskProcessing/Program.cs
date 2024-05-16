using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using TaskProcessing.Processors;

namespace TaskProcessing
{
    static class Program
    {
        static async Task Main()
        {
            var operations = new List<IOperationInput<Data>>
            {
                new OperationInput(OperationType.Reverse, new Data("Pelle",1)),
                new OperationInput(OperationType.Reverse,  new Data("Olle",2)),
                new OperationInput(OperationType.UpperCase,  new Data("Pelle",3)),
                new OperationInput(OperationType.UpperCase,  new Data("Olle",4))
            };

            var factory = new DataProcessorFactory();

            var processors = operations.Select(o => factory.GetProcessor(o));
            var tasks = processors.Select(p => p.ProcessAsync());

            var outputs = await Task.WhenAll(tasks);
            foreach (var output in outputs)
            {
                Console.WriteLine(output.ToString());
            }
        }
    }
}
