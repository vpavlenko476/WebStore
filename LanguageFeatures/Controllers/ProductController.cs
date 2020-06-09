using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.DAL.Contracts;
using Store.Domain;
using Store.Entites;
using Store.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Store.Controllers
{
	public class ProductController : Controller
	{
		private readonly IBaseRepo<ProductEntity> _productRepo;
		private readonly IMapper _mapper;
		private readonly int _pageSize;
		public ProductController(IBaseRepo<ProductEntity> repo, IMapper mapper)
		{
			_productRepo = repo;
			_mapper = mapper;
			_pageSize = 4;
		}

		/// <summary>
		/// Разбиаение на страницы
		/// </summary>
		/// <param name="productPage"></param>
		/// <returns></returns>
		public IActionResult List(int productPage = 1) =>
			View(new ProductsListViewModel
			{
				Products = _mapper.Map<List<ProductModel>>(_productRepo.GetAll())
				.OrderBy(x => x.Name)
				.Skip((productPage - 1) * _pageSize)
				.Take(_pageSize),
				pagingInfo = new PagingInfo
				{
					CurrentPage = productPage,
					ItemsPerPage = _pageSize,
					TotalItems = _productRepo.GetAll().Count()
				}
			});

	}
}