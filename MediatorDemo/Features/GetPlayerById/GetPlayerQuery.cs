using MediatR;

namespace MediatorDemo.Features.GetPlayerById
{
    public record class GetPlayerQuery(int id) : IRequest<Player?>;
}
