using Data;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Models;
using TODO_GRPC;

namespace Services;

public class ToDoService : ToDoIt.ToDoItBase
{
    private readonly AppDbContext _dbContext;

    public ToDoService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<CreateToDoResponse> CreateToDo(CreateToDoRequest request, ServerCallContext context)
    {
        {
            if (string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Description))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Title and Description cannot be empty."));
            }

            var toDoItem = new ToDoItem
            {
                Title = request.Title,
                Description = request.Description
            };

            _dbContext.ToDoItems.Add(toDoItem);
            await _dbContext.SaveChangesAsync();
            return new CreateToDoResponse
            {
                Id = toDoItem.Id
            };
        }
    }

    public override async Task<ReadToDoResponse> ReadToDo(ReadToDoRequest request, ServerCallContext context)
    {
        if (request.Id <= 0)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "ID must be a positive integer."));
        }

        var toDoItem = await _dbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (toDoItem == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"ToDo item with ID {request.Id} not found."));
        }

        return new ReadToDoResponse
        {
            Id = toDoItem.Id,
            Title = toDoItem.Title,
            Description = toDoItem.Description,
            ToDoStatus = toDoItem.ToDoStatus,
        };
    }

    public override async Task<GetAllResponse> ListToDo(GetAllRequest request, ServerCallContext context)
    {
        var toDoItems = await _dbContext.ToDoItems.ToListAsync();
        return new GetAllResponse
        {
            ToDos = { toDoItems.Select(x => new ReadToDoResponse
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ToDoStatus = x.ToDoStatus
            }) }
        };
    }

    public override async Task<UpdateToDoResponse> UpdateToDo(UpdateToDoRequest request, ServerCallContext context)
    {
        if (request.Id <= 0 || string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Description))
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "You must supply a valid object"));
        }
        var toDoItem = await _dbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (toDoItem == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"ToDo item with ID {request.Id} not found."));
        }
        toDoItem.Title = request.Title;
        toDoItem.Description = request.Description;
        toDoItem.ToDoStatus = request.ToDoStatus;
        await _dbContext.SaveChangesAsync();
        return new UpdateToDoResponse
        {
            Id = toDoItem.Id
        };
    }

    public override async Task<DeleteToDoResponse> DeleteToDo(DeleteToDoRequest request, ServerCallContext context)
    {
        if (request.Id <= 0)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "ID must be a positive integer."));
        }
        var toDoItem = await _dbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (toDoItem == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"ToDo item with ID {request.Id} not found."));
        }
        _dbContext.ToDoItems.Remove(toDoItem);
        await _dbContext.SaveChangesAsync();
        return new DeleteToDoResponse
        {
            Id = request.Id
        };
    }
}