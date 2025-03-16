using MediatR;

namespace MediatorDemo.Features.CreatePlayer
{
    public record class CreatePlayerCommand(string Name, string Level) : IRequest<Player>;
}
