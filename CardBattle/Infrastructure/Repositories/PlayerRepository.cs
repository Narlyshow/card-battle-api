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

        public Players Get(Players players)
        {
            var user =  _context.Players.FirstOrDefault(p => p.email == players.email && p.senha == players.senha);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public Players GetPlayerInformation(Players players)
        {
            var user = _context.Players.FirstOrDefault(p => p.email == players.email);
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
