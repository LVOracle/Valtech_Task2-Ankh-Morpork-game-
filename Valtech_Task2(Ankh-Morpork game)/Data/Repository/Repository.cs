using System.Collections.Generic;
using Valtech_Task2_Ankh_Morpork_game_.Data.IRepository;
using Valtech_Task2_Ankh_Morpork_game_.Data.Models;

namespace Valtech_Task2_Ankh_Morpork_game_.Data.Repository
{
    public class Repository : IGeneralRepository
    {
        private readonly AnkhMorporkGameContext _context;
        public Repository(AnkhMorporkGameContext _context) => this._context = _context;
        public IEnumerable<Assassins> GetAssassinsEnumerable => _context.Assassins;
        public IEnumerable<Beggars> GetBeggarsEnumerable => _context.Beggars;
        public IEnumerable<Fools> GetFoolsEnumerable => _context.Fools;
        public IEnumerable<Thieves> GetThievesEnumerable => _context.Thieves;
    }
}
