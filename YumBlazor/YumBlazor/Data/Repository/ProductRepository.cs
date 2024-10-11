using Humanizer;
using Microsoft.EntityFrameworkCore;
using YumBlazor.Data.Repository.IRepository;

namespace YumBlazor.Data.Repository
{
   
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductRepository(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Product> CreateAsync(Product obj)
        {
            _db.Product.Add(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj =_db.Product.FirstOrDefault(c => c.Id == id);
            string imagePath = string.Empty;
            if (obj.ImageUrl != null)
            {
                imagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('/'));
            }

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
            if (obj != null)
            {
                _db.Product.Remove(obj);
                return await _db.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Product> GetAsync(int id)
        {
            var obj = await _db.Product.FirstOrDefaultAsync(c => c.Id == id);
            if(obj == null)
            {
                return new Product();
            }
            return obj;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Product.Include(u=>u.Category).ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product obj)
        {
            var objFromDb= _db.Product.FirstOrDefault(u =>u.Id == obj.Id);
            if (objFromDb !=null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.ImageUrl = obj.ImageUrl;
                objFromDb.CategoryId = obj.CategoryId;
                _db.Product.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }   
            return obj;
        }
    }
}
