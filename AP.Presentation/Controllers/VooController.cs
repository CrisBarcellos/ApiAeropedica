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
    public class VooController : ControllerBase
    {
        private IVoo VooPersistence;

        public VooController(IVoo vooPersistence)
        {
            VooPersistence = vooPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<Voo>> Listar()
        {
            try
            {
                return VooPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar os Voos!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Voo>> ListarPorId(decimal nr_voo, string data)
        {
            try
            {
                return VooPersistence.ListarPorId(nr_voo, data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar o Voo!");
            }
        }

        [HttpGet, Route("ListarPorCidade")]
        public ActionResult<List<ListaVoo>> ListarPorCidade(string data, string origem, string destino)
        {
            try
            {
                return VooPersistence.ListarPorCidade(data, origem, destino);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar o Voo!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Voo v)
        {
            try
            {
                await VooPersistence.Cadastrar(v);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar o Voo!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(decimal nr_voo, string data)
        {
            try
            {
                await VooPersistence.Deletar(nr_voo, data);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar o Voo!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Voo v)
        {
            try
            {
                await VooPersistence.Alterar(v);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar o Voo!");
            }
        }
    }
}
