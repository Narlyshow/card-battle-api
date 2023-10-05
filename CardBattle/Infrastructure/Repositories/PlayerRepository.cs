using CardBattle.Domain.Models;

namespace CardBattle.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayersRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Players players)
        {
            _context.Players.Add(players);
            _context.SaveChanges();
        }
    }
}
