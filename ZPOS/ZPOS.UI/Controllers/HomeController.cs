using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ZPOS.UI.Entities;
using ZPOS.UI.Interfaces;
using ZPOS.UI.Models;

namespace ZPOS.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IBrandServices _brandServices;
        private readonly IClientServices _clientServices;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IProductServices productServices, ICategoryServices categoryServices,
            IBrandServices brandServices, IClientServices clientServices, UserManager<User> userManager, IMapper mapper)
        {
            _logger = logger;
            _productServices = productServices ?? throw new ArgumentNullException(nameof(productServices));
            _categoryServices = categoryServices ?? throw new ArgumentNullException(nameof(categoryServices));
            _brandServices = brandServices ?? throw new ArgumentNullException(nameof(brandServices));
            _clientServices = clientServices ?? throw new ArgumentNullException(nameof(brandServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IActionResult Index()
        {
            var lastPorducts = _productServices.GetProducts().OrderByDescending(p => p.CreationDate).Take(5);

            var lastPorductsToReturn = _mapper.Map<IEnumerable<ProductVM>>(lastPorducts);

            var dashBoard = new DashboardVM
            {
                TotalOfPorducts = _productServices.GetProducts().Count(),
                TotalOfCategries = _categoryServices.GetCategories().Count(),
                TotalOfBrands = _brandServices.GetBrands().Count(),
                TotalOfClients = _clientServices.GetClients().Count(),
                LastAddedProducts = lastPorductsToReturn.ToList()
            };

            return View(dashBoard);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
