using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPOS.UI.Interfaces;
using ZPOS.UI.Models;

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

        [HttpGet]
        //DONE
        public ActionResult GetCategories()
        {
            try
            {
                var categories = _categoryServices.GetCategories();

                var categoriesToReturn = _mapper.Map<IEnumerable<CategoryVM>>(categories);

                return PartialView("_ListOfCategories",categoriesToReturn);

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Las categorías no pudieron ser cargadas.");
            }
        }

        [HttpDelete]
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                var category = _categoryServices.GetCategoryById(id);

                if (category != null)
                {
                    if (category.Products.Count > 0) return BadRequest($"Para eliminar esta Categoría no deben de haber Productos en ella y esta categoría tiene {category.Products.Count} Productos.");

                    var result = _categoryServices.DeleteCategory(category);

                    if (result)
                    {
                        return Json("Categoría eliminado con exito!");
                    }

                    return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
                }

                return BadRequest("La Categoría que tratas de eliminar no existe");

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
            }
        }
    }
}
