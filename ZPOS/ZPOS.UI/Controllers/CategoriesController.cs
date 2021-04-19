using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ZPOS.UI.Entities;
using ZPOS.UI.Helpers;
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

                return PartialView("_ListOfCategories", categoriesToReturn);

            }
            catch (Exception ex)
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
                    if (category.Products.Count > 0) return BadRequest($"Para eliminar esta Categoría no deben de haber Productos en ella y esta categoría tiene {category.Products.Count} Producto(s).");

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

        [HttpGet]
        //DONE
        public ActionResult PostCategory()
        {
            try
            {
                return PartialView("_FormCreateCategory", new CreateCategoryVM());
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al cargar el formulario");
            }
        }

        [HttpPost]
        //DONE
        public ActionResult PostCategory(CreateCategoryVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoryToCreate = _mapper.Map<Category>(model);

                    var result = _categoryServices.AddCategory(categoryToCreate);

                    if (!result)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
                    }

                    return Json("La categoría ha sido agregada.");
                }

                return BadRequest(FormatedModelStateErrors.GetErrorsFormated(ModelState));
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
            }
        }

        [HttpGet]
        //DONE
        public ActionResult EditCategory(int id)
        {
            try
            {
                var category = _categoryServices.GetCategoryById(id);
                if (category == null) return BadRequest("La categoría que tratas de editar no existe!");

                var categoryToEdit = _mapper.Map<CategoryVM>(category);


                return PartialView("_FormEditCategory", categoryToEdit);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
            }
        }

        [HttpPut]
        //DONE
        public ActionResult EditCategory(CategoryVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var categoryToEdit = _categoryServices.GetCategoryById(model.ID);

                    if (categoryToEdit == null) return BadRequest("La categoría que tratas de actualizar no existe!");

                    categoryToEdit.Name = model.Name;

                    var result = _categoryServices.UpdateCategory(categoryToEdit);

                    if (!result)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal trantando de actualizar la categoría, contacta el Administrador");
                    }

                    return Json("Categoría actualizada con exito.!");
                }

                return BadRequest(FormatedModelStateErrors.GetErrorsFormated(ModelState));
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
            }
        }
    }
}
