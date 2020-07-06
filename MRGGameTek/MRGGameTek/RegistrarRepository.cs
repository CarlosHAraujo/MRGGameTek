using MRGGameTek.Models.Register;

namespace MRGGameTek
{
    public class RegistrarRepository : IRegisterRepository<MrGreen>, IRegisterRepository<RedBet>
    {
        public void Register(MrGreen registrar)
        {
            //Implement EF Core
        }

        public void Register(RedBet registrar)
        {
            //Implement EF Core
        }
    }
}
