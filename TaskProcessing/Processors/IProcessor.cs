using System.Threading.Tasks;

namespace TaskProcessing.Processors
{
    public interface IProcessor<TData>
    {
        Task<IOperationOutput<TData>> ProcessAsync();
    }
}
