using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

    public class ClientsController : Controller
    {
        private readonly IClientServices _clientServices;
        private readonly IMapper _mapper;

        public ClientsController(IClientServices clientServices, IMapper mapper)
        {
            _clientServices = clientServices ?? throw new ArgumentNullException(nameof(clientServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //DONE
        public ActionResult GetClients()
        {
            try
            {
                var clients = _clientServices.GetClients();

                var clintsToReturn = _mapper.Map<IEnumerable<ClientVM>>(clients);

                return PartialView("_ListOfClients", clintsToReturn);

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Algo salio mal tratando de cargar los clientes, Intente de nuevo o contacte el administrador.");
            }

        }

        [HttpDelete]
        //DONE
        public ActionResult DeleteClient(int id)
        {
            try
            {
                var client = _clientServices.GetClientById(id);

                if (client != null)
                {
                    client.Deleted = true;

                    var result = _clientServices.UpdateClient(client);

                    if (result)
                    {
                        return Json("Cliente eliminado con exito!");
                    }

                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Algo salio mal trando de eliminar este cliente, Intente de nuevo o contacta el Administrador del sistema");
                }

                return BadRequest("El Cliente que tratas de eliminar no existe");

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                            "Algo salio mal trando de eliminar este cliente, Intente de nuevo o contacta el Administrador del sistema");
            }
        }

        [HttpGet]
        //DONE
        public ActionResult PostClient()
        {
            try
            {
                return PartialView("_FormCreateClient", new CreateClientVM());
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al cargar el formulario");
            }

        }

        [HttpPost]
        //DONE
        public ActionResult PostClient(CreateClientVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_clientServices.Exists(model.Document))
                    {
                        return BadRequest($"Existe un cliente con el documento {model.Document} registrado.");
                    }

                    var clientToCreate = _mapper.Map<Client>(model);

                    clientToCreate.CreationDate = DateTime.Now;

                    var result = _clientServices.AddClient(clientToCreate);

                    if (!result)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal tratando de agregar el cliente, Intente de nuevo o contacta el Administrador.");
                    }

                    return Json("El cliente ha sido agregado.");
                }

                return BadRequest(FormatedModelStateErrors.GetErrorsFormated(ModelState));
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal tratando de agregar el cliente, Intente de nuevo o contacta el Administrador.");
            }
        }

        [HttpGet]
        //DONE
        public ActionResult EditClient(int id)
        {
            try
            {
                var client = _clientServices.GetClientById(id);

                if (client == null) return BadRequest("El cliente que tratas de editar no existe!");

                var clientToEdit = _mapper.Map<UpdateClienteVM>(client);


                return PartialView("_FormEditClient", clientToEdit);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, el fomulario no pudo ser cargado. Intenta de nuevo o contacta el Administrador");
            }
        }

        [HttpPut]
        //DONE
        public ActionResult EditClient(UpdateClienteVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var clientToEdit = _clientServices.GetClientById(model.ID);

                    if(model.Document != clientToEdit.Document)
                    {
                        if (_clientServices.Exists(model.Document))
                        {
                            return BadRequest($"Existe un cliente con el documento {model.Document} registrado.");
                        }
                    }

                    clientToEdit.FirstName = model.FirstName;
                    clientToEdit.LastName = model.LastName;
                    clientToEdit.Document = model.Document;
                    clientToEdit.Email = model.Email;
                    clientToEdit.Phone = model.Phone;
                    clientToEdit.Address = model.Address;

                    var result = _clientServices.UpdateClient(clientToEdit);

                    if (!result)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal tratando de actualizar el cliente, Intente de nuevo o contacta el Administrador.");
                    }

                    return Json("El cliente ha sido actualizado.");
                }

                return BadRequest(FormatedModelStateErrors.GetErrorsFormated(ModelState));
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal tratando de actualizar el cliente, Intente de nuevo o contacta el Administrador.");
            }
        }
    }
}
