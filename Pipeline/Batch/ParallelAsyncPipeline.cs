using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pipeline.Processors;

namespace Pipeline.Batch
{
    public class ParallelAsyncPipeline<TData> : IBatch<TData>
    {
        private readonly List<IProcessor<TData>> _pipelineSteps = new List<IProcessor<TData>>();

        public IBatch<TData> AddWorkItem(IProcessor<TData> processor)
        {
            _pipelineSteps.Add(processor);
            return this;
        }
     
        public async Task<TData> Execute(TData input)
        {
            if (_pipelineSteps.Count < 1)
            {
                return input;
            }
            var tasks = _pipelineSteps.Select(p => p.ProcessAsync(input));
            var results = await Task.WhenAll(tasks);
            for (var i = 0; i < results.Length; i++)
            {
                Console.WriteLine($"Result {i+1}: {results[i]}");
            }

            return input;
        }
    }
}