using System.Threading.Tasks;

namespace Pipeline.Processors
{
    public interface IProcessor<TData>
    {
        Task<TData> ProcessAsync(TData input);
    }
}
