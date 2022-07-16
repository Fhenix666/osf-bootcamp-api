using BootCamp.Adm.Commons;
using BootCamp.Adm.Filters;
using BootCamp.Adm.Helpers;
using BootCamp.Adm.Manager.Interfaces;
using BootCamp.Adm.Security;
using BootCamp.Adm.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Adm.Controllers
{
    /// <summary>
    /// UserStatusController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/userstatus")]
    [ApiController]
    public class UserStatusController : ControllerBase
    {

        private readonly IUserStatusManager _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStatusController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public UserStatusController(IUserStatusManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery] QueryParameter pagingParameter, [FromQuery] UserStatusFilter entityFilter)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                response.Success = 1;
                response.Failure = 0;
                response.oData = new { Result = _manager.Get(pagingParameter, entityFilter) };
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
        public async Task<ViewModels.Output.UserStatusViewModel> Get(int id)
        {
            return await _manager.GetById(id);
        }
    }
}
