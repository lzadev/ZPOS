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
    public class BrandsController : Controller
    {
        private readonly IBrandServices _brandServices;
        private readonly IMapper _mapper;

        public BrandsController(IBrandServices brandServices, IMapper mapper)
        {
            _brandServices = brandServices ?? throw new ArgumentNullException(nameof(brandServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //DONE
        public ActionResult GetBrands()
        {
            try
            {
                var brands = _brandServices.GetBrands();

                var brandsToReturn = _mapper.Map<IEnumerable<BrandVM>>(brands);

                return PartialView("_ListOfBrands", brandsToReturn);

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Algo salio mal tratando de cargar las marcas, Intente de nuevo o contacte el administrador.");
            }

        }

        [HttpDelete]
        //DONE
        public ActionResult DeleteBrand(int id)
        {
            try
            {
                var brand = _brandServices.GetBrandById(id);

                if (brand != null)
                {
                    if (brand.Products.Count > 0) return BadRequest(
                        $"Para eliminar esta Marca no deben de haber Productos en ella y esta Marca tiene {brand.Products.Count} Producto(s).");

                    var result = _brandServices.DeleteBrand(brand);

                    if (result)
                    {
                        return Json("Marca eliminada con exito!");
                    }

                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Algo salio mal trando de eliminar esta marca, Intente de nuevo o contacta el Administrador del sistema");
                }

                return BadRequest("La Marca que tratas de eliminar no existe");

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                            "Algo salio mal trando de eliminar esta marca, Intente de nuevo o contacta el Administrador del sistema");
            }
        }

        [HttpGet]
        //DONE
        public ActionResult PostBrand()
        {
            try
            {
                return PartialView("_FormCreateBrand", new CreateBrandVM());
            }
            catch(Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al cargar el formulario");
            }
            
        }

        [HttpPost]
        //DONE
        public ActionResult PostBrand(CreateBrandVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var bandToCreate = _mapper.Map<Brand>(model);

                    var result = _brandServices.AddBrand(bandToCreate);

                    if (!result)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal tratando de crear la marca, Intente de nuevo o contacta el Administrador");
                    }

                    return Json("La marca ha sido agregada.");
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
        public ActionResult EditBrand(int id)
        {
            try
            {
                var brand = _brandServices.GetBrandById(id);

                if (brand == null) return BadRequest("La marca que tratas de editar no existe!");

                var brandToEdit = _mapper.Map<BrandVM>(brand);


                return PartialView("_FormEditBrand", brandToEdit);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, el fomulario no pudo ser cargado. Intenta de nuevo o contacta el Administrador");
            }
        }

        [HttpPut]
        //DONE
        public ActionResult EditBrand(CategoryVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var brandToEdit = _brandServices.GetBrandById(model.ID);

                    if (brandToEdit == null) return BadRequest("La marca que tratas de actualizar no existe!");

                    brandToEdit.Name = model.Name;

                    var result = _brandServices.UpdateBrand(brandToEdit);

                    if (!result)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal trantando de actualizar la marca, contacta el Administrador");
                    }

                    return Json("Marca actualizada con exito.!");
                }

                return BadRequest(FormatedModelStateErrors.GetErrorsFormated(ModelState));
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Algo salio mal trantando de actualizar la marca, contacta el Administrador");
            }
        }
    }
}
