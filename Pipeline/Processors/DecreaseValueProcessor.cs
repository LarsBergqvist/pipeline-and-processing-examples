using System;
using System.Threading.Tasks;
using Common;

namespace Pipeline.Processors
{
    public class DecreaseValueProcessor: IProcessor<Data>
    {
        public Task<Data> ProcessAsync(Data input)
        {
            var result = new Data(input.Text, input.Value - 1);
            Console.WriteLine("Finished decrease");

            return Task.FromResult(result);
        }
    }
}
