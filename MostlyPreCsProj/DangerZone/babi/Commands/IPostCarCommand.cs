namespace babi.Commands
{
    using Boilerplate.AspNetCore;
    using babi.ViewModels;

    public interface IPostCarCommand : IAsyncCommand<SaveCar>
    {
    }
}
