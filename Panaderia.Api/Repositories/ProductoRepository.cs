using Panaderia.Api.Data;
using Panaderia.Api.Models;

namespace Panaderia.Api.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly PanaderiaDbContext _context;

        public ProductoRepository(PanaderiaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto> GetAll()
        {
            return _context.Productos.ToList();
        }

        public Producto GetById(int id)
        {
            return _context.Productos.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Producto producto)
        {
            _context.Productos.Add(producto);
        }

        public void Update(Producto producto)
        {
            _context.Productos.Update(producto);
        }

        public void Delete(int id)
        {
            var producto = GetById(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
