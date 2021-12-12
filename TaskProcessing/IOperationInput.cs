namespace TaskProcessing
{
    public interface IOperationInput<out TData>
    {
        OperationType OperationType { get; }
        TData Data { get; }
    }
}
