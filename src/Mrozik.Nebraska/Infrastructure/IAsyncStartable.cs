using System.Threading.Tasks;

namespace Mrozik.Nebraska.Infrastructure
{
    public interface IAsyncStartable
    {
        Task StartAsync();
    }
}