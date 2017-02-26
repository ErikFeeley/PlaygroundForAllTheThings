namespace babi.Commands
{
    using Boilerplate.AspNetCore;
    using babi.ViewModels;

    public interface IPutCarCommand : IAsyncCommand<int, SaveCar>
    {
    }
}
