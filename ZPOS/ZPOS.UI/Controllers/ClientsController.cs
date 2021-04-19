using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    }
}
