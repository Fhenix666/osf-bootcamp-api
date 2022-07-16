using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

using BootCamp.Adm.Commons;
using BootCamp.Adm.Filters;
using BootCamp.Adm.Helpers;
using BootCamp.Adm.Security;
using BootCamp.Adm.ViewModels;
using BootCamp.Adm.ViewModels.Input;
using BootCamp.Adm.Manager.Interfaces;

namespace BootCamp.Adm.Controllers
{
    /// <summary>
    /// UserController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    //[AuthorizationFilter]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserManager _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public UserController(IUserManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("list")]
        public IActionResult List()
        {
            return View();
        }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery] QueryParameter pagingParameter, [FromQuery] UserFilter entityFilter)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                response.Success = 1;
                response.Failure = 0;
                response.oData = new { Result = _manager.GetUsers(pagingParameter, entityFilter) };
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                response.Success = 1;
                response.Failure = 0;
                response.oData = new { User = await _manager.GetById(id) };
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }


        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            JsonResponse response = new JsonResponse();

            try
            {
                response.Success = 1;
                response.Failure = 0;
                response.oData = new { User = await _manager.GetAll() };
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("by-mail/{mail}")]
        public async Task<IActionResult> GetByMail(string mail)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                response.Success = 1;
                response.Failure = 0;
                response.oData = new { User = await _manager.GetBymail(mail) };
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }

        /// <summary>
        /// Adds this instance.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Posts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InputUserViewModel user)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                response.Success = 1;
                response.Failure = 0;
                response.oData = new { User = await _manager.Post(user) };
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }
        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("update")]
        public async Task<IActionResult> Update(int id)
        {
            var update = await _manager.GetById(id);

            return View(update);
        }
        /// <summary>
        /// Patches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userVM">The user vm.</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, InputUserViewModel user)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                await _manager.Patch(id, user);
                response.Success = 1;
                response.Failure = 0;
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }
        /// <summary>
        /// Patches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userVM">The user vm.</param>
        /// <returns></returns>
        [HttpPatch("{id}/password/{password}")]
        public async Task<IActionResult> PatchPassword(int id, string password)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                await _manager.PatchPassword(id, password);
                response.Success = 1;
                response.Failure = 0;
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }
        /// <summary>
        /// Patches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                await _manager.Delete(id);
                response.Success = 1;
                response.Failure = 0;
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }
    }
}
