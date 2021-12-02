using System.Collections.Generic;
using Valtech_Task2_Ankh_Morpork_game_.Data.Models;

namespace Valtech_Task2_Ankh_Morpork_game_.Data.IRepository
{
    public interface IGeneralRepository
    {
        public IEnumerable<Assassins> GetAssassinsEnumerable  { get; }
        public IEnumerable<Beggars> GetBeggarsEnumerable  { get; }
        public IEnumerable<Fools> GetFoolsEnumerable  { get; }
        public IEnumerable<Thieves> GetThievesEnumerable  { get; }
    }
}
