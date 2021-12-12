using System.Threading.Tasks;
using Pipeline.Processors;

namespace Pipeline.Pipeline
{
    public interface IPipeline<TData>
    {
        Task<TData> Execute(TData input);
        IPipeline<TData> AddStep(IProcessor<TData> processor);
    }
}