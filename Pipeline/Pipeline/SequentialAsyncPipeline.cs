using System.Collections.Generic;
using System.Threading.Tasks;
using Pipeline.Processors;

namespace Pipeline.Pipeline
{
    public class SequentialAsyncPipeline<TData> : IPipeline<TData>
    {
        private readonly List<IProcessor<TData>> _pipelineSteps = new List<IProcessor<TData>>();

        public IPipeline<TData> AddStep(IProcessor<TData> processor)
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
            var result = await _pipelineSteps[0].ProcessAsync(input);
            for (var i = 1; i < _pipelineSteps.Count; i++)
            {
                result = await _pipelineSteps[i].ProcessAsync(result);
            }

            return result;
        }
    }
}