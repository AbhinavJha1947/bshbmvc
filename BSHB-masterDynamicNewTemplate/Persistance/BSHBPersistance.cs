using BiharStateHousingBoard.Models;

namespace BiharStateHousingBoard.Persistance
{
    public class BSHBPersistance
    {
        private readonly DemoEntityContext _bshbContext;
        public BSHBPersistance()
        {
            _bshbContext = new DemoEntityContext();
        }
        public IEnumerable<Roles> GetAllRole()
        {
            var data = _bshbContext.Roless.OrderByDescending(e => e.UserRole).ToList();
            return data;
        }
    }
}
