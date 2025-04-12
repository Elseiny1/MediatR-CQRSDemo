using MediatR;

namespace MediatorDemo.Features.GetAllPlayers
{
    public class GetAllPlayersHandller : IRequestHandler<GetAllPlayersQuery, List<Player>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllPlayersHandller(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            var players = await _context.players.ToListAsync();
            if(request.s is null) 
                return players;

            return players;
        }
    }
}
