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
    public class RotaController : ControllerBase
    {
        private IRota RotaPersistence;

        public RotaController(IRota rotaPersistence)
        {
            RotaPersistence = rotaPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<Rota>> Listar()
        {
            try
            {
                return RotaPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar as Rotas!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Rota>> ListarPorId(int id)
        {
            try
            {
                return RotaPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar a Rota!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Rota r)
        {
            try
            {
                await RotaPersistence.Cadastrar(r);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar as Rotas!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(decimal id)
        {
            try
            {
                await RotaPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar a Rota!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Rota r)
        {
            try
            {
                await RotaPersistence.Alterar(r);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar a Rota!");
            }
        }
    }
}
