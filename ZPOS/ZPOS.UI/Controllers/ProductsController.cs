using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ZPOS.UI.Entities;
using ZPOS.UI.Helper;
using ZPOS.UI.Helpers;
using ZPOS.UI.Interfaces;
using ZPOS.UI.Models;

namespace ZPOS.UI.Controllers
{

    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;
        private readonly IBrandServices _brandServices;
        private readonly ICategoryServices _categoryServices;

        public ProductsController(IProductServices productServices, IMapper mapper,
            IBrandServices brandServices, ICategoryServices categoryServices)
        {
            _productServices = productServices ?? throw new ArgumentNullException(nameof(productServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _brandServices = brandServices ?? throw new ArgumentNullException(nameof(brandServices));
            _categoryServices = categoryServices ?? throw new ArgumentNullException(nameof(categoryServices));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //DONE
        public ActionResult<IEnumerable<ProductVM>> GetProducts()
        {
            try
            {
                var productsFromServices = _productServices.GetProducts();

                var productsToReturn = _mapper.Map<IEnumerable<ProductVM>>(productsFromServices);

                return PartialView("_ListOfProducts", productsToReturn);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Los productos lo pudieron ser cargados");
            }
        }

        [HttpGet]
        //DONE
        public ActionResult PostProduct()
        {
            try
            {
                var model = new CreateProductVM();

                model.Categories = GetCategories();
                model.Brands = GetBrands();
                model.Code = GetGenerateCodeForProduct();

                return PartialView("_FormCreateProduct", model);
            }
            catch (Exception e)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
            }

        }

        [HttpPost]
        //DONE
        public ActionResult PostProduct(CreateProductVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(!_productServices.Exists(model.Description)) return BadRequest("Este producto ha sido creado anteriormente");

                    if (model.BuyPrice > model.SellPrice) return BadRequest("El precio de venta de ser mayor al de compra");

                    model.CreationDate = DateTime.Now;

                    var productToCreate = _mapper.Map<Product>(model);

                    productToCreate.Status = true;

                    _productServices.AddProduct(productToCreate);

                    var result = _productServices.Save();

                    if (!result) return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");

                    return Json("El producto ha sido agregado");
                }

                return BadRequest(FormatedModelStateErrors.GetErrorsFormated(ModelState));
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
            }
        }

        [HttpDelete]
        //DONE
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _productServices.GetPrductById(id);

                if (product != null)
                {
                    var result = _productServices.DeleteProduct(product);

                    if (result)
                    {
                        return Json("Producto eliminado con exito!");
                    }

                    return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
                }

                return BadRequest("El producto que tratas de eliminar no existe");

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
            }
        }

        [HttpGet]
        //DONE
        public ActionResult EditProduct(int id)
        {
            try
            {
                var product = _productServices.GetPrductById(id);
                if (product == null) return BadRequest("El producto que tratas de editar no existe!");

                var model = new UpdateProductVM
                {
                    ID = product.ID,
                    Code = product.Code,
                    Description = product.Description,
                    CategoryID = product.CategoryID,
                    BrandID = product.BrandID,
                    BuyPrice = product.BuyPrice,
                    SellPrice = product.SellPrice,
                    Status = product.Status
                };
                model.Categories = GetCategories();
                model.Brands = GetBrands();

                return PartialView("_FormEditProduct", model);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
            }
        }

        [HttpPut]
        //DONE
        public ActionResult EditProduct(UpdateProductVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productToEdit = _productServices.GetPrductById(model.ID);

                    if (productToEdit == null) return BadRequest("El producto que trata de actualizar no existe!");
                    if (model.BuyPrice > model.SellPrice) return BadRequest("El precio de venta tiene que ser mayor al de compra");

                    productToEdit.Updated = true;

                    //Actualizo el producto actual en la base de datos.

                    _productServices.UpdateProduct(productToEdit);

                    //Creo el nuevo producto
                    var product = new Product()
                    {
                        Code = productToEdit.Code,
                        Description = model.Description,
                        CategoryID = model.CategoryID,
                        BrandID = model.BrandID,
                        BuyPrice = model.BuyPrice,
                        SellPrice = model.SellPrice,
                        CreationDate = productToEdit.CreationDate,
                        ModificationDate = DateTime.Now,
                        Status = model.Status,
                        Updated = false,
                        Deleted = false
                    };

                    _productServices.AddProduct(product);

                    var result = _productServices.Save();

                    if (!result) return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, contacta el Administrador");
                    return Json("Producto actualizado con exito.!");
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
        public IActionResult AuditProduct(string ProductCode)
        {
            var productHistorial = _productServices.GetProductHistorial(ProductCode);

            var productToAudit = new List<AuditProductVM>();

            foreach (var product in productHistorial)
            {
                productToAudit.Add(new AuditProductVM
                {
                    Code = product.Code,
                    Description = product.Description,
                    Category = product.Categories.Name,
                    Brand = product.Brands.Name,
                    BuyPrice = product.BuyPrice,
                    SellPrice = product.SellPrice,
                    CreationDate = product.CreationDate,
                    ModificationDate = product.ModificationDate,
                    Status = product.Status,
                    Updated = product.Updated
                });
            }

            return View(productToAudit);
        }


        #region Methods

        private List<CategoryVM> GetCategories()
        {
            var categories = _mapper.Map<IEnumerable<CategoryVM>>(_categoryServices.GetCategories());

            return categories.ToList();
        }

        private List<BrandVM> GetBrands()
        {
            var brands = _mapper.Map<IEnumerable<BrandVM>>(_brandServices.GetBrands());
            return brands.ToList();
        }

        private string GetGenerateCodeForProduct()
        {
            var codeGeneratedFoProduct = GenerateCodeForProduct.Generate();

            while (_productServices.ExistsCode(codeGeneratedFoProduct))
            {
                codeGeneratedFoProduct = GenerateCodeForProduct.Generate();
            }

            return codeGeneratedFoProduct;
        }

        //Validando que el produto no exista
        [AcceptVerbs("GET", "POST")]
        public IActionResult Exists(string description)
        {
            if (!_productServices.Exists(description))
            {
                return Json($"Este producto ya existe");
            }

            return Json(true);
        }

        #endregion
    }
}
