namespace babi.Commands
{
    using Boilerplate.AspNetCore;
    using Microsoft.AspNetCore.JsonPatch;
    using babi.ViewModels;

    public interface IPatchCarCommand : IAsyncCommand<int, JsonPatchDocument<SaveCar>>
    {
    }
}
