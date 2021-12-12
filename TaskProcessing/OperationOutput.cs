using Common;

namespace TaskProcessing
{
    public class OperationOutput : IOperationOutput<Data>
    {
        public OperationOutput(Data data, string result)
        {
            Data = data;
            Result = result;
        }

        public Data Data { get; }
        public string Result { get; }

        public override string ToString()
        {
            return $"{Result}, {Data}";
        }
    }
}
