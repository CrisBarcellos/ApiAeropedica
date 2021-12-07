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

        [HttpGet, Route("Listar")]
        public ActionResult<List<Passageiro>> Listar()
        {
            try
            {
                return PassageiroPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar os Passageiros!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Passageiro>> ListarPorId(int id)
        {
            try
            {
                return PassageiroPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar o Passageiro!");
            }
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
                return StatusCode(500, "Não foi Possível Cadastrar o Passageiro!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(decimal id)
        {
            try
            {
                await PassageiroPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar o Passageiro!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Passageiro p)
        {
            try
            {
                await PassageiroPersistence.Alterar(p);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar o Passageiro!");
            }
        }
    }
}
