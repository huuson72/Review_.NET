using MVC_Demo.Data;
using MVC_Demo.Models;

namespace MVC_Demo.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            Save();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            Save();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
