using AP.Data.Interface;
using AP.Data.Persistence;
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
    public class EquipamentoController : ControllerBase
    {
        private IEquipamento EquipamentoPersistence;

        public EquipamentoController(IEquipamento eqptPersistence)
        {
            EquipamentoPersistence = eqptPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<Equipamento>> Listar()
        {
            try
            {
                return EquipamentoPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar os Equipamentos!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Equipamento>> ListarPorId(string id)
        {
            try
            {
                return EquipamentoPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar o Equipamento!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Equipamento e)
        {
            try
            {
                await EquipamentoPersistence.Cadastrar(e);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar os Equipamentos!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(string id)
        {
            try
            {
                await EquipamentoPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar o Equipamento!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Equipamento e)
        {
            try
            {
                await EquipamentoPersistence.Alterar(e);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar o Equipamento!");
            }
        }
    }
}
