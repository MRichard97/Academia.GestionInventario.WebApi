using Academia.GestionInventario.WebApi._Infrastructure;
using Farsiman.Domain.Core.Standard.Repositories;
using Farsiman.Infraestructure.Core.Entity.Standard;
using Microsoft.EntityFrameworkCore;

namespace Academia.Transporte.WebApi._Infrastructure
{
    public class UnitOfWorkBuilder
    {
        readonly IServiceProvider _serviceProvider;

        public UnitOfWorkBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUnitOfWork BuilderGestionInventarioDbContext()
        {
            DbContext dbContext = _serviceProvider.GetService<GestionInventarioDbContext>() ?? throw new NullReferenceException();
            return new UnitOfWork(dbContext);
        }
    }
}
