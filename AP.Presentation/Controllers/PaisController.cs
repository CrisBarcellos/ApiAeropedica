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
    public class PaisController : ControllerBase
    {
        private IPais PaisPersistence;

        public PaisController(IPais paisPersistence)
        {
            PaisPersistence = paisPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<Pais>> Listar()
        {
            try
            {
                return PaisPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar os Paises!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Pais>> ListarPorId(string id)
        {
            try
            {
                return PaisPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar o Pais!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Pais p)
        {
            try
            {
                await PaisPersistence.Cadastrar(p);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar o Pais!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(string id)
        {
            try
            {
                await PaisPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar o Pais!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Pais p)
        {
            try
            {
                await PaisPersistence.Alterar(p);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar o Pais!");
            }
        }
    }
}
