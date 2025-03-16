using MediatR;

namespace MediatorDemo.Features.CreatePlayer
{
    public class CreatePlayerCmmandHandler : IRequestHandler<CreatePlayerCommand, Player>
    {
        private readonly ApplicationDbContext _context;

        public CreatePlayerCmmandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player
            {
                Name = request.Name,
                Level = request.Level
            };

            _context.players.Add(player);
            _context.SaveChangesAsync();

            return player;
        }
    }
}
