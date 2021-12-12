using System.Threading.Tasks;
using Pipeline.Processors;

namespace Pipeline.Batch
{
    public interface IBatch<TData>
    {
        Task<TData> Execute(TData input);
        IBatch<TData> AddWorkItem(IProcessor<TData> processor);
    }
}
