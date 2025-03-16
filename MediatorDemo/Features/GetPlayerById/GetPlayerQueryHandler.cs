using MediatR;

namespace MediatorDemo.Features.GetPlayerById
{
    public class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, Player?>
    {
        private readonly ApplicationDbContext _context;
        public GetPlayerQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Player?> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            var player = await _context.players.FindAsync(request.id);
           
            return player;
        }
    }
}
