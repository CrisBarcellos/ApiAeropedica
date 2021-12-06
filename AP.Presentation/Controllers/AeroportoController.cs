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
    public class AeroportoController : ControllerBase
    {
        private IAeroporto AeroportoPersistence;

        public AeroportoController(IAeroporto aerPersistence)
        {
            AeroportoPersistence = aerPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<Aeroporto>> Listar()
        {
            try
            {
                return AeroportoPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar os Aeroportos!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Aeroporto>> ListarPorId(string id)
        {
            try
            {
                return AeroportoPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar o Aeroporto!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Aeroporto a)
        {
            try
            {
                await AeroportoPersistence.Cadastrar(a);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar os Aeroportos!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(string id)
        {
            try
            {
                await AeroportoPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar o Aeroporto!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Aeroporto a)
        {
            try
            {
                await AeroportoPersistence.Alterar(a);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar o Aeroporto!");
            }
        }
    }
}
