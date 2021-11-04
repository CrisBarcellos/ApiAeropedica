using AP.Data;
using AP.Data.Interface;
using AP.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageiroController : ControllerBase
    {
        private IPassageiro PassageiroPersistence;

        public PassageiroController(IPassageiro passPersistence)
        {
            PassageiroPersistence = passPersistence;
        }      

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Passageiro p)
        {
            try
            {
                await PassageiroPersistence.Cadastrar(p);
                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
