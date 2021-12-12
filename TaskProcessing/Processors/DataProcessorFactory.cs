using System;
using Common;

namespace TaskProcessing.Processors
{
    public class DataProcessorFactory
    {
        public IProcessor<Data> GetProcessor(IOperationInput<Data> opInput)
        {
            return opInput.OperationType switch
            {
                OperationType.Reverse => new ReverseProcessor(opInput),
                OperationType.UpperCase => new UpperCaseProcessor(opInput),
                _ => throw new ArgumentException($"Unsupported processor '{opInput.OperationType}'")
            };
        }
    }
}
