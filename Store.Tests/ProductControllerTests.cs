using Microsoft.AspNetCore.Mvc;
using Moq;
using Store.Controllers;
using Store.DAL.Contracts;
using Store.DAL.Implementation.Repositories;
using Store.Domain;
using Store.Entites;
using Store.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Store.Tests
{
	public class ProductControllerTests
	{
		[Fact]
		public void Pagination()
		{
			var mock = new Mock<IBaseRepo<ProductEntity>>();
			mock.Setup(m => m.GetAll()).Returns(new List<ProductEntity>()
			{ new ProductEntity() {Name = "P1" },
			new ProductEntity() {Name = "P2" },
			new ProductEntity() {Name = "P3" },
			new ProductEntity() {Name = "P4" },
			}.AsQueryable<ProductEntity>);
			var prodController = new ProductController(mock.Object, Mapper.Config.CreateMapper());
			
			var result = (prodController.List() as ViewResult)?.ViewData.Model as ProductsListViewModel;
			
			Assert.True(result.Products.ToArray().Length == 4);
			Assert.Equal("P1", result.Products.ToArray()[0].Name);
		}

		[Fact]
		public void Can_Seed_Pagination_VM()
		{
			int currentPage = 1;
			var repoMock = new Mock<IBaseRepo<ProductEntity>>();
			repoMock.Setup(x=>x.GetAll()).Returns(new List<ProductEntity>()
			{ new ProductEntity() {Name = "P1" },
			new ProductEntity() {Name = "P2" },
			new ProductEntity() {Name = "P3" },
			new ProductEntity() {Name = "P4" },
			}.AsQueryable<ProductEntity>);

			var prodController = new ProductController(repoMock.Object, Mapper.Config.CreateMapper());
			var result = (prodController.List(currentPage) as ViewResult)?.ViewData.Model as ProductsListViewModel;
			Assert.Equal(result.Products.ToArray().Length, result.pagingInfo.ItemsPerPage);
			Assert.Equal(currentPage, result.pagingInfo.CurrentPage);
			Assert.Equal(repoMock.Object.GetAll().Count(), result.pagingInfo.TotalItems);

		}
	}
}