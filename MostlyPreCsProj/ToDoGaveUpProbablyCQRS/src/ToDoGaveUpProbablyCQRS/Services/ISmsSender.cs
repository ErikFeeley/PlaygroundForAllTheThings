using System.Threading.Tasks;

namespace ToDoGaveUpProbablyCQRS.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
