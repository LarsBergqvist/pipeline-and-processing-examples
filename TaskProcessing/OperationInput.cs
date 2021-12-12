using Common;

namespace TaskProcessing
{
    public class OperationInput : IOperationInput<Data>
    {
        public OperationInput(OperationType opType, Data data)
        {
            OperationType = opType;
            Data = data;
        }

        public OperationType OperationType { get; }
        public Data Data { get; }
    }
}
