﻿using ETicaretAPI.Application.CQRS.Product.Query.GetAll;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repositories.ProductImageFile;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CQRS.Product.Query.GetAllImage
{
    public class GetAllImageProductQueryHandler : IRequestHandler<GetAllImageProductQueryRequest, List<GetAllImageProductQueryResponse>>
    {


        IProductReadRepository _productReadRepository;

        public GetAllImageProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<List<GetAllImageProductQueryResponse>> Handle(GetAllImageProductQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = await _productReadRepository.Table.Include(pif => pif.ProductImageFiles).Include(a=>a.ProductDetail).SelectMany(pif => pif.ProductImageFiles, (p, pif) => new
            {
                p,
                pif,
                p.ProductDetail

            }).ToListAsync();

            return datas.Select(a => new GetAllImageProductQueryResponse
            {

                ProductId = a.p.Id.ToString(),
                ProductName = a.p.Name,
                ProductStock = a.p.Stock,
                ProductPrice = a.p.Price,
                FileName = a.pif.FileName,
                ProductPath = a.pif.Path,
                ProductBrand = a.p.ProductDetail.Brand,
                ProductModel = a.p.ProductDetail.Model,
                ProductDescription =a.p.ProductDetail.Description,
                ProductColor = a.p.ProductDetail.Color
            }).ToList();

        }



    }
}
