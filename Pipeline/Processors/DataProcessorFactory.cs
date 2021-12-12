using System;
using Common;

namespace Pipeline.Processors
{
    public class DataProcessorFactory
    {
        public IProcessor<Data> GetProcessor(ProcessorType type)
        {
            return type switch
            {
                ProcessorType.Reverse => new ReverseTextProcessor(),
                ProcessorType.UpperCase => new UpperCaseTextProcessor(),
                ProcessorType.IncreaseValue => new IncreaseValueProcessor(),
                ProcessorType.DecreaseValue => new DecreaseValueProcessor(),
                _ => throw new ArgumentException($"Unsupported processor '{type}'")
            };
        }
    }
}
