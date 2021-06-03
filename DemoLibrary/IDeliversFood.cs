using System.Threading.Tasks;

namespace DemoLibrary
{
    public interface IDeliversFood
    {
        public Task Deliver(int orderId);
    }
}
