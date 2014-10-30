using NeuChat.Models;
using System.Threading.Tasks;

namespace NeuChat.Services {
    public interface IChatHub {

        Task ConnectAsync();

        Task SendMessageAsync(ChatEntry message);
    }
}