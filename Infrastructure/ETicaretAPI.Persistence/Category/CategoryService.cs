using ETicaretAPI.Application.Abstraction.Category;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.Category;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Category
{
    public class CategoryService : ICategoryService
    {

        ICategoryReadRepository _categoryReadRepository;
        ICategoryWriteRepository _categoryWriteRepository;
        IProductReadRepository _productReadRepository;


        public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IProductReadRepository productReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _productReadRepository = productReadRepository;

        }

        public async Task AddCategoryAsync(string Name)
        {
            await _categoryWriteRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                Name = Name
            });
            await _categoryWriteRepository.SaveAsync();
        }

        public async Task DeleteByIdCategoryAsync(string Id)
        {
            await _categoryWriteRepository.RemoveByIdAsync(Id);
            await _categoryWriteRepository.SaveAsync();
        }

        public async Task<List<Domain.Entities.Category>> GetAllCategoriesAsync()
        {
            return await _categoryReadRepository.GetAll(tracking: false).ToListAsync();

        }

        public async Task UpdateCategoryAsync(string Id, string NewCategoryName)
        {
            Domain.Entities.Category category = await _categoryReadRepository.GetByIdAsync(Id);
            category.Name = NewCategoryName;
            await _categoryWriteRepository.SaveAsync();
        }

        public async Task<Domain.Entities.Category> GetByIdCategoryAsync(string CategoryId)
        {
            return await _categoryReadRepository.GetByIdAsync(CategoryId);
        }


        public async Task<List<GetByIdCategoryInProductsDto>> GetByIdCategoryInProductsAsync(string CategoryId)
        {
            var products = _productReadRepository.Table.Include(a => a.Category).Include(a => a.ProductImageFiles).Where(a => a.Category.Id == Guid.Parse(CategoryId)).ToList();



            return products.SelectMany(i => i.ProductImageFiles, (p, i) => new GetByIdCategoryInProductsDto()
            {
                CategoryId = p.CategoryId.ToString(),
                CategoryName = p.Category.Name,
                ProductId = p.Id.ToString(),
                ProductName = p.Name,
                ProductPrice = p.Price,
                ProductStock = p.Stock,
                Path = i.Path,
                ShowCase = i.ShowCase
            }).ToList();

        }

        public async Task<List<GetByNameCategoryInProductsDto>> GetByNameCategoryInProductsAsync(string CategoryName)
        {
            var products = _productReadRepository.Table.Include(a => a.Category).Include(a => a.ProductImageFiles).Where(a => a.Category.Name == CategoryName).ToList();


            return products.SelectMany(i => i.ProductImageFiles, (p, i) => new GetByNameCategoryInProductsDto()
            {
                CategoryId = p.CategoryId.ToString(),
                CategoryName = p.Category.Name,
                ProductId = p.Id.ToString(),
                ProductName = p.Name,
                ProductPrice = p.Price,
                ProductStock = p.Stock,
                Path = i.Path,
                ShowCase = i.ShowCase
            }).ToList();

        }

        public async Task<List<SortCategoryInProductsDto>> SortCategoryInProductsAsync(string CategoryName, string type, string parameter)
        {

            var products = _productReadRepository.Table.Include(a => a.Category).Include(a => a.ProductImageFiles).Where(a => a.Category.Name == CategoryName).ToList();

            if (parameter == "asc")
            {
                switch (type)
                {
                    case "name":
                        return products.SelectMany(i => i.ProductImageFiles, (p, i) => new SortCategoryInProductsDto()
                        {
                            CategoryId = p.CategoryId.ToString(),
                            CategoryName = p.Category.Name,
                            ProductId = p.Id.ToString(),
                            ProductName = p.Name,
                            ProductPrice = p.Price,
                            ProductStock = p.Stock,
                            Path = i.Path,
                            ShowCase = i.ShowCase
                        }).OrderBy(a => a.ProductName).ToList();


                    case "price":
                        return products.SelectMany(i => i.ProductImageFiles, (p, i) => new SortCategoryInProductsDto()
                        {
                            CategoryId = p.CategoryId.ToString(),
                            CategoryName = p.Category.Name,
                            ProductId = p.Id.ToString(),
                            ProductName = p.Name,
                            ProductPrice = p.Price,
                            ProductStock = p.Stock,
                            Path = i.Path,
                            ShowCase = i.ShowCase
                        }).OrderBy(a => a.ProductPrice).ToList();
                    case "code":
                        return products.SelectMany(i => i.ProductImageFiles, (p, i) => new SortCategoryInProductsDto()
                        {
                            CategoryId = p.CategoryId.ToString(),
                            CategoryName = p.Category.Name,
                            ProductId = p.Id.ToString(),
                            ProductName = p.Name,
                            ProductPrice = p.Price,
                            ProductStock = p.Stock,
                            Path = i.Path,
                            ShowCase = i.ShowCase,

                        }).OrderBy(a => a.ProductId).ToList();

                    default:
                        return products.SelectMany(i => i.ProductImageFiles, (p, i) => new SortCategoryInProductsDto()
                        {
                            CategoryId = p.CategoryId.ToString(),
                            CategoryName = p.Category.Name,
                            ProductId = p.Id.ToString(),
                            ProductName = p.Name,
                            ProductPrice = p.Price,
                            ProductStock = p.Stock,
                            Path = i.Path,
                            ShowCase = i.ShowCase
                        }).ToList();
                }



            }
            else if (parameter == "desc")
            {
                switch (type)
                {
                    case "name":
                        return products.SelectMany(i => i.ProductImageFiles, (p, i) => new SortCategoryInProductsDto()
                        {
                            CategoryId = p.CategoryId.ToString(),
                            CategoryName = p.Category.Name,
                            ProductId = p.Id.ToString(),
                            ProductName = p.Name,
                            ProductPrice = p.Price,
                            ProductStock = p.Stock,
                            Path = i.Path,
                            ShowCase = i.ShowCase
                        }).OrderByDescending(a => a.ProductName).ToList();


                    case "price":
                        return products.SelectMany(i => i.ProductImageFiles, (p, i) => new SortCategoryInProductsDto()
                        {
                            CategoryId = p.CategoryId.ToString(),
                            CategoryName = p.Category.Name,
                            ProductId = p.Id.ToString(),
                            ProductName = p.Name,
                            ProductPrice = p.Price,
                            ProductStock = p.Stock,
                            Path = i.Path,
                            ShowCase = i.ShowCase
                        }).OrderByDescending(a => a.ProductPrice).ToList();
                    case "code":
                        return products.SelectMany(i => i.ProductImageFiles, (p, i) => new SortCategoryInProductsDto()
                        {
                            CategoryId = p.CategoryId.ToString(),
                            CategoryName = p.Category.Name,
                            ProductId = p.Id.ToString(),
                            ProductName = p.Name,
                            ProductPrice = p.Price,
                            ProductStock = p.Stock,
                            Path = i.Path,
                            ShowCase = i.ShowCase,

                        }).OrderByDescending(a => a.ProductId).ToList();

                    default:
                        return products.SelectMany(i => i.ProductImageFiles, (p, i) => new SortCategoryInProductsDto()
                        {
                            CategoryId = p.CategoryId.ToString(),
                            CategoryName = p.Category.Name,
                            ProductId = p.Id.ToString(),
                            ProductName = p.Name,
                            ProductPrice = p.Price,
                            ProductStock = p.Stock,
                            Path = i.Path,
                            ShowCase = i.ShowCase
                        }).ToList();
                }
            }

            else
            {
                return null;
            }



        }
    }
}
