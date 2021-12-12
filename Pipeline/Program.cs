using System;
using System.Threading.Tasks;
using Common;
using Pipeline.Batch;
using Pipeline.Pipeline;
using Pipeline.Processors;

namespace Pipeline
{
    class Program
    {
        static async Task Main()
        {
            var factory = new DataProcessorFactory();
            IPipeline<Data> pipeline = new SequentialAsyncPipeline<Data>();

            pipeline
                .AddStep(factory.GetProcessor(ProcessorType.UpperCase))
                .AddStep(factory.GetProcessor(ProcessorType.Reverse))
                .AddStep(factory.GetProcessor(ProcessorType.IncreaseValue))
                .AddStep(factory.GetProcessor(ProcessorType.DecreaseValue))
                ;

            Console.WriteLine($"Starting {nameof(SequentialAsyncPipeline<Data>)}");
            var sequentialResult = await pipeline.Execute(new Data("Pelle", 10));
            Console.WriteLine($"Final result: {sequentialResult}");

            IBatch<Data> batch = new ParallelAsyncPipeline<Data>();
            batch
                .AddWorkItem(factory.GetProcessor(ProcessorType.UpperCase))
                .AddWorkItem(factory.GetProcessor(ProcessorType.Reverse))
                .AddWorkItem(factory.GetProcessor(ProcessorType.IncreaseValue))
                .AddWorkItem(factory.GetProcessor(ProcessorType.IncreaseValue))
                ;

            Console.WriteLine($"Starting {nameof(ParallelAsyncPipeline<Data>)}");
            _ = await batch.Execute(new Data("Pelle", 10));
        }
    }

}
