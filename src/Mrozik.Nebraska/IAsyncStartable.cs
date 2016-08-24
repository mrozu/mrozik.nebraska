using System.Threading.Tasks;

namespace Mrozik.Nebraska
{
    public interface IAsyncStartable
    {
        Task StartAsync();
    }
}