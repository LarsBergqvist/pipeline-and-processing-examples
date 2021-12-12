using System;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace Pipeline.Processors
{
    public class ReverseTextProcessor: IProcessor<Data>
    {
        public async Task<Data> ProcessAsync(Data input)
        {
            var result = new Data(input.Text.ReversedCopy(), input.Value);
            await Task.Run(() => Thread.Sleep(1000));
            Console.WriteLine("Finished reverse");
            return result;
        }
    }
}
