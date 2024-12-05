
using uol_backend.API.Infraestrutura.BancoDeDados;

namespace uol_backend.API.Servicos.Base
{
    public class BaseService
    {

        private readonly BancoDataContext _dataContext;

        public BaseService(BancoDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        protected void Commit()
        {
            _dataContext.SaveChanges();
        }

        protected async Task CommitAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
