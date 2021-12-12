using System;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace Pipeline.Processors
{
    public class UpperCaseTextProcessor: IProcessor<Data>
    {
        public async Task<Data> ProcessAsync(Data input)
        {
            var result = new Data(input.Text.ToUpper(), input.Value);
            await Task.Run(() => Thread.Sleep(500));
            Console.WriteLine("Finished UpperCase");

            return result;
        }
    }
}
