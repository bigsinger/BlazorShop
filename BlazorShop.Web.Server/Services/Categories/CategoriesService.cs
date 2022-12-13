namespace BlazorShop.Services.Categories {
    using AutoMapper;
    using BlazorShop.Common;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Categories;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoriesService : BaseService<Category>, ICategoriesService {
        public CategoriesService(BlazorShopDbContext db, IMapper mapper) : base(db, mapper) {
        }

        public async Task<long> CreateAsync(CategoriesRequestModel model) {
            var category = new Category {
                Name = model.Name
            };

            await this.Data.AddAsync(category);
            await this.Data.SaveChangesAsync();

            return category.Id;
        }

        public async Task<Result> UpdateAsync(
            long id, CategoriesRequestModel model) {
            var category = await this.FindByIdAsync(id);

            if(category == null) {
                return false;
            }

            category.Name = model.Name;

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(long id) {
            var category = await this.FindByIdAsync(id);

            if(category == null) {
                return false;
            }

            this.Data.Remove(category);

            await this.Data.SaveChangesAsync();

            return true;
        }

        // 如果要格式化好的多级分类 可以参考：https://blog.csdn.net/KingCruel/article/details/122104023
        public async Task<IEnumerable<CategoriesListingResponseModel>> AllAsync()
            => await this.Mapper.ProjectTo<CategoriesListingResponseModel>(this.AllAsNoTracking().Where(c => c.ParentId == 0))
                .ToListAsync();

        private async Task<Category> FindByIdAsync(long id)
            => await this
                .All()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
    }
}
