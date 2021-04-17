using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPOS.UI.Interfaces;

namespace ZPOS.UI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryServices categoryServices, IMapper mapper)
        {
            _categoryServices = categoryServices ?? throw new ArgumentNullException(nameof(categoryServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public IActionResult Index()
        {
            return View();
        }



    }
}
