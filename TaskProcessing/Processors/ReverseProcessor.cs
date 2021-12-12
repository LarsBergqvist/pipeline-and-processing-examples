using System.Threading.Tasks;
using Common;

namespace TaskProcessing.Processors
{
    public class ReverseProcessor : IProcessor<Data>
    {
        private readonly IOperationInput<Data> _opInput;
        public ReverseProcessor(IOperationInput<Data> opInput)
        {
            _opInput = opInput;
        }


        public Task<IOperationOutput<Data>> ProcessAsync()
        {
           IOperationOutput<Data> output = new OperationOutput(new Data(_opInput.Data.Text.ReversedCopy(), _opInput.Data.Value), "Success");
           return Task.FromResult(output);
        }
    }
}
