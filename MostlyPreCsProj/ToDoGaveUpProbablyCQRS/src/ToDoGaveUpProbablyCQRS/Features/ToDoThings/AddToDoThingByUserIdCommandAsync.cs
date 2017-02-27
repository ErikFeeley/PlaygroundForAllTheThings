﻿using MediatR;
using ToDoGaveUpProbablyCQRS.ViewModels;

namespace ToDoGaveUpProbablyCQRS.Features.ToDoThings
{
    public class AddToDoThingByUserIdCommandAsync : IRequest<int>
    {
        public AddToDoThingByUserIdCommandAsync(string userId, ToDoThingViewModel toDoThingViewModel)
        {
            UserId = userId;
            ToDoThingViewModel = toDoThingViewModel;
        }

        public string UserId { get; set; }

        public ToDoThingViewModel ToDoThingViewModel { get; set; }
    }
}
