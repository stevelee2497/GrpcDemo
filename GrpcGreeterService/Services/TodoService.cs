using Grpc.Core;
using System.Text.Json;

namespace GrpcGreeterService.Services
{
    public class TodoService : Todo.TodoBase 
    {
        private readonly ILogger<TodoService> _logger;

        public TodoService(ILogger<TodoService> logger)
        {
            _logger = logger;
        }

        public override Task<TodoItemsResponse> GetTodoItems(TodoItemsRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Request call {0}", JsonSerializer.Serialize(request));

            // TODO: get user todo list from db
            var items = new List<TodoItem>
            {
                new TodoItem
                {
                    Id = "1",
                    Title = "task - 1",
                    Description = "get task 1 done befor tmr",
                },   
                new TodoItem
                {
                    Id = "2",
                    Title = "task - 2",
                    Description = "get task 2 done befor tmr",
                },
            };
            return Task.FromResult(new TodoItemsResponse
            {
                UserId = request.UserId,
                Items = { items }
            });
        }
    }
}
