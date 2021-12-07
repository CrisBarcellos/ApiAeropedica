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
    public class UFController : ControllerBase
    {
        private IUF UFPersistence;

        public UFController(IUF ufPersistence)
        {
            UFPersistence = ufPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<UF>> Listar()
        {
            try
            {
                return UFPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar as UFs!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<UF>> ListarPorId(string id)
        {
            try
            {
                return UFPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar a UF!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(UF uf)
        {
            try
            {
                await UFPersistence.Cadastrar(uf);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar a UF!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(string id)
        {
            try
            {
                await UFPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar a UF!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(UF uf)
        {
            try
            {
                await UFPersistence.Alterar(uf);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar a UF!");
            }
        }
    }
}
