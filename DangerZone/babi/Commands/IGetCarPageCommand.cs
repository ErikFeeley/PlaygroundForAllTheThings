namespace babi.Commands
{
    using Boilerplate.AspNetCore;
    using babi.ViewModels;

    public interface IGetCarPageCommand : IAsyncCommand<PageOptions>
    {
    }
}
