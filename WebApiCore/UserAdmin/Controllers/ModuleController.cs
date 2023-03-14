using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAdmin.Repositories;

namespace UserAdmin.Controllers
{
    [Authorize]
    [Route("Mdoule")]
    public class ModuleController : Controller
    {
        private readonly IModuleRepository moduleRepository;
        public ModuleController(IModuleRepository moduleRepository)
        {
            this.moduleRepository = moduleRepository;
        }
        
        [HttpGet]
        [Route("GetListAsync")]
        public async Task<IActionResult> GetListAsync()
        {
            try
            {
                var Modules = await this.moduleRepository.GetListAsync();
                return Ok(Modules);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetRecordAsync")]
        public async Task<IActionResult> GetRecordAsync(int id)
        {
            try
            {
                
                var module = await moduleRepository.GetRecordAsync(id);
                return Ok(module);
            }
            catch (Exception Ex) {
                return BadRequest(Ex.Message.ToString());
            }
        }
    }
}
