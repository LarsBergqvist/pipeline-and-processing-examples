using System;
using System.Threading.Tasks;
using Common;

namespace Pipeline.Processors
{
    public class IncreaseValueProcessor: IProcessor<Data>
    {
        public Task<Data> ProcessAsync(Data input)
        {
            var result = new Data(input.Text, input.Value + 1);
            Console.WriteLine("Finished increase");

            return Task.FromResult(result);
        }
    }
}
