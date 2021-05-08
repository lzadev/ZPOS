using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPOS.UI.Entities;
using ZPOS.UI.Helpers;
using ZPOS.UI.Interfaces;
using ZPOS.UI.Models;

namespace ZPOS.UI.Controllers
{

    public class AdministrationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IUserServices _userServices;

        public AdministrationController(UserManager<User> userManager,RoleManager<IdentityRole> roleManager,
            IMapper mapper,IUserServices userServices)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userServices = userServices ?? throw new ArgumentNullException(nameof(userServices));
        }

        [Route("{controller}/Usuarios")]
        public IActionResult Users()
        {
            return View();
        }

        [HttpGet]
        //DONE
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var userToReturn = await _userServices.GetUsers();

                return PartialView("_ListOfUsers", userToReturn);

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudieron cargar los Usuarios.");
            }

        }


        [HttpGet]
        //DONE
        public ActionResult PostUser()
        {
            var roles = _roleManager.Roles;

            var rolesToReturn = _mapper.Map<IEnumerable<RoleVM>>(roles);

            return PartialView("_FormCreateUser", new CreateUserVM() {Roles = rolesToReturn.ToList() });
        }

        [HttpPost]
        //DONE
        public async Task<ActionResult> PostUser(CreateUserVM model)
        {
            try
            {
                //TODO: HACER ESTE PROCESO EN EL REPOSITORIO CON SP
                if (ModelState.IsValid)
                {
                    var newUser = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Status = true,
                    };

                    newUser.UserName = await GetGeneratedUserName();

                    var result = await _userManager.CreateAsync(newUser, model.Password);

                    if (!result.Succeeded)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            "Algo salio mal trantando de crear el usuario. Intenta de nuevo o contacta al adminitrador del sistema");
                    }

                    await _userManager.AddToRoleAsync(newUser, model.Role);

                    return Json("El usuario ha sido creado");
                }

                return BadRequest(FormatedModelStateErrors.GetErrorsFormated(ModelState));

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Algo salio mal trantando de crear el usuario. Intenta de nuevo o contacta al adminitrador del sistema");
            }
        }

        [HttpGet]
        //DONE
        public async Task<ActionResult> EditUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user == null) return BadRequest("El usuario que tratas de editar no existe!");

                var userToEdit = _mapper.Map<UpdateUserMV>(user);

                return PartialView("_FormEditUser", userToEdit);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "Algo salio mal, el fomulario no pudo ser cargado. Intenta de nuevo o contacta el Administrador");
            }
        }

        [HttpPut]
        //DONE
        public async Task<ActionResult> EditUser(UpdateUserMV model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var userToEdit = await _userManager.FindByIdAsync(model.Id);


                    if (userToEdit == null) return BadRequest("El usuario que tratas de editar no existe.");

                    userToEdit.FirstName = model.FirstName;
                    userToEdit.LastName = model.LastName;
                    userToEdit.Status = model.Status;

                    var result = await _userManager.UpdateAsync(userToEdit);

                    if (!result.Succeeded)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            "Algo salio mal trantando de actualizar el usuario. Intenta de nuevo o contacta al adminitrador del sistema");
                    }

                    return Json("El usuario ha sido creado");
                }

                return BadRequest(FormatedModelStateErrors.GetErrorsFormated(ModelState));

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Algo salio mal trantando de actualizar el usuario. Intenta de nuevo o contacta al adminitrador del sistema");
            }
        }

        [HttpDelete]
        //DONE
        public async Task<ActionResult> DeleteUser(string id)
        {
            try
            {

                var currentUser = User.Identity.Name;

                var userInDb = await _userManager.FindByIdAsync(id);

                if (currentUser == userInDb.UserName)
                {
                    return BadRequest("El usuario que tratas de borrar es con el que estas en sesíon. No puede ser eliminado");
                }

                var userToDelete = await _userManager.FindByIdAsync(id);

                if (userToDelete == null) return BadRequest("El usuario que tratas de borrar no existe.");

                userToDelete.Deleted = true;

                var result = await _userManager.UpdateAsync(userToDelete);

                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Algo salio mal trantando de borrar el usuario. Intenta de nuevo o contacta al adminitrador del sistema");
                }

                return Json("El usuario ha sido borrado");

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Algo salio mal trantando de borrar el usuario. Intenta de nuevo o contacta al adminitrador del sistema");
            }
        }

        #region Roles

        public ActionResult Roles()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoleVM>> GetRoles()
        {
            var roles = _roleManager.Roles;

            var rolesToReturn = _mapper.Map<IEnumerable<RoleVM>>(roles);

            return PartialView("_ListOfRoles", rolesToReturn);
        }

        [HttpGet]
        public ActionResult PostRole()
        {

            return PartialView("_FormCreateRole", new CreateRoleVM());
        }

        [HttpPost]
        //DONE
        public async Task<ActionResult> PostRole(CreateRoleVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if(await _roleManager.RoleExistsAsync(model.Name)) return BadRequest("Este rol ya ha sido creado anteriomente");

                    var newRole = new IdentityRole { Name = model.Name };

                    var result = await _roleManager.CreateAsync(newRole);

                    if (!result.Succeeded)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            "Algo salio mal trantando de crear el rol. Intenta de nuevo o contacta al adminitrador del sistema");
                    }

                    return Json("El rol ha sido creado");
                }

                return BadRequest(FormatedModelStateErrors.GetErrorsFormated(ModelState));

            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Algo salio mal trantando de crear el rol. Intenta de nuevo o contacta al adminitrador del sistema");
            }
        }

        #endregion


        private string GenerateUserName()
        {
            Random _random = new Random();
            var userName = "0";

            while (userName.Length < 5)
            {
                userName += _random.Next(0, 9).ToString();
            }

            return userName;
        }

        private async Task<string> GetGeneratedUserName()
        {
            var userName = GenerateUserName();

            while (await ExistsUser(userName))
            {
                userName = GenerateUserName();
            }

            return userName;
        }


        private async Task<bool> ExistsUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                return true;
            }

            return false;
        }
    }
}
