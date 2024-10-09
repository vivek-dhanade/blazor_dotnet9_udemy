using Humanizer;
using Microsoft.EntityFrameworkCore;
using YumBlazor.Data.Repository.IRepository;

namespace YumBlazor.Data.Repository
{
   
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Category> CreateAsync(Category obj)
        {
            _db.Category.Add(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj =_db.Category.FirstOrDefault(c => c.Id == id);
            if (obj != null)
            {
                _db.Category.Remove(obj);
                return await _db.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Category> GetAsync(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(c => c.Id == id);
            if(obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Category.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            var objFromDb= _db.Category.FirstOrDefault(u =>u.Id == obj.Id);
            if (objFromDb !=null)
            {
                objFromDb.Name = obj.Name;
                _db.Category.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }   
            return obj;
        }
    }
}
