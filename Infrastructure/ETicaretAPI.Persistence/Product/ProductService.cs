using ETicaretAPI.Application.Abstraction.Product;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.Category;
using ETicaretAPI.Application.Repositories.ProductDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public class ProductService : IProductService
    {
        IProductDetailReadRepository _productDetailReadRepository;
        ICategoryReadRepository _categoryReadRepository;
        IProductReadRepository _productReadRepository;

        public ProductService(IProductDetailReadRepository productDetailReadRepository, ICategoryReadRepository categoryReadRepository, IProductReadRepository productReadRepository)
        {
            _productDetailReadRepository = productDetailReadRepository;
            _categoryReadRepository = categoryReadRepository;
            _productReadRepository = productReadRepository;
        }

        public async Task<List<GetAllFilteredProductsDto>> GetAllFilteredProductsAsync(string? brand = null, string? model = null, string? color = null, string? category = null)
        {


            var productsdto = await _productReadRepository.Table.Include(a => a.ProductImageFiles).Include(a => a.ProductDetail).Include(a => a.Category)
                .Where(a => a.ProductImageFiles.Any(a => a.ShowCase == true)).SelectMany(p => p.ProductImageFiles, (i, p) => new GetAllProductsDto()
                {
                    ProductId = i.Id.ToString(),
                    ProductName = i.Name,
                    ProductPrice = i.Price,
                    ProductStock = i.Stock,
                    Brand = i.ProductDetail.Brand,
                    Model = i.ProductDetail.Model,
                    Description = i.ProductDetail.Description,
                    Color = i.ProductDetail.Color,
                    Path = p.Path,
                    ShowCase = p.ShowCase,
                }).ToListAsync();

            List<GetAllProductsDto> anadto = new List<GetAllProductsDto>();

            if (category != null)
            {

                List<GetAllProductsDto> result = productsdto.Where(a => a.CategoryName == category && a.ShowCase == true).ToList();
                foreach (var item in result)
                {
                    anadto.Add(item);
                }

            }


            if (brand != null)
            {


                List<GetAllProductsDto> result = new List<GetAllProductsDto>();

                if (anadto.Count != 0)
                {
                    result = anadto.Where(a => a.Brand == brand && a.ShowCase == true).ToList();
                    anadto.Clear();
                    if (result.Count != 0)
                    {
                        foreach (var item in result)
                        {
                            anadto.Add(item);
                        }
                    }

                }
                else
                {
                    result = productsdto.Where(a => a.Brand == brand && a.ShowCase == true).ToList();
                    if (result.Count != 0)
                    {
                        foreach (var item in result)
                        {
                            anadto.Add(item);
                        }
                    }
                }

            }

            if (model != null)
            {


                List<GetAllProductsDto> result = new List<GetAllProductsDto>();

                if (anadto.Count != 0)
                {
                    result = anadto.Where(a => a.Model == model && a.ShowCase == true).ToList();
                    anadto.Clear();
                    if (result.Count != 0)
                    {
                        foreach (var item in result)
                        {
                            anadto.Add(item);
                        }
                    }

                }
                else
                {
                    result = productsdto.Where(a => a.Model == model && a.ShowCase == true).ToList();
                    if (result.Count != 0)
                    {
                        foreach (var item in result)
                        {
                            anadto.Add(item);
                        }
                    }
                }

            }


            if (color != null)
            {


                List<GetAllProductsDto> result = new List<GetAllProductsDto>();

                if (anadto.Count != 0)
                {
                    result = anadto.Where(a => a.Color == color && a.ShowCase == true).ToList();
                    anadto.Clear();
                    if (result.Count != 0)
                    {
                        foreach (var item in result)
                        {
                            anadto.Add(item);
                        }
                    }

                }
                else
                {
                    result = productsdto.Where(a => a.Color == color && a.ShowCase == true).ToList();
                    if (result.Count != 0)
                    {
                        foreach (var item in result)
                        {
                            anadto.Add(item);
                        }
                    }
                }

            }

            return anadto.Select(a => new GetAllFilteredProductsDto()
            {
                CategoryName = a.CategoryName,
                ProductId = a.ProductId,
                ProductName = a.ProductName,
                ProductPrice = a.ProductPrice,
                ProductStock = a.ProductStock,
                Brand = a.Brand,
                Model = a.Model,
                Description = a.Description,
                Color = a.Color,
                Path = a.Path,
                ShowCase = a.ShowCase
            }).ToList();
        }







        public async Task<GetAllFiltersDto> GetAllFiltersAsync()
        {
            List<string> Brands = await _productDetailReadRepository.GetAll().Select(a => a.Brand).Distinct().ToListAsync();
            List<string> Models = await _productDetailReadRepository.GetAll().Select(a => a.Model).Distinct().ToListAsync();
            List<string> Colors = await _productDetailReadRepository.GetAll().Select(a => a.Color).Distinct().ToListAsync();
            List<string> Categories = await _categoryReadRepository.GetAll().Select(a => a.Name).Distinct().ToListAsync();

            return new GetAllFiltersDto()
            {
                Brands = Brands,
                Models = Models,
                Colors = Colors,
                Categories = Categories
            };
        }

        public async Task<GetCategoryFiltersDto> GetCategoryFiltersAsync(string categoryName)
        {
            List<string> Brands = await _productDetailReadRepository.GetAll().Where(a => a.Product.Category.Name == categoryName).Select(a => a.Brand).Distinct().ToListAsync();
            List<string> Models = await _productDetailReadRepository.GetAll().Where(a => a.Product.Category.Name == categoryName).Select(a => a.Model).Distinct().ToListAsync();
            List<string> Colors = await _productDetailReadRepository.GetAll().Where(a => a.Product.Category.Name == categoryName).Select(a => a.Color).Distinct().ToListAsync();

            return new GetCategoryFiltersDto()
            {
                Brands = Brands,
                Models = Models,
                Colors = Colors,
            };

        }
    }
}
