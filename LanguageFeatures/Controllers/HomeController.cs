using Microsoft.AspNetCore.Mvc;
using Store.Entites;
using Store.DAL.Contracts;
using System.Linq;
using AutoMapper;
using Store.Domain;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseRepo<ProductEntity> _productRepo;
        private readonly IMapper _mapper;
        public HomeController(IBaseRepo<ProductEntity> repo, IMapper mapper)
        {
            _productRepo = repo;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var product = _mapper.Map<ProductModel>(_productRepo.GetAll().FirstOrDefault());            
            ViewBag.Add = "supaDupa";
            return View(product);
        }
    }
}