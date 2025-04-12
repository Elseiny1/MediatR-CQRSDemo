using MediatR;

namespace MediatorDemo.Features.GetAllPlayers
{
    public record class GetAllPlayersQuery(string s) : IRequest<List<Player>>;
}
