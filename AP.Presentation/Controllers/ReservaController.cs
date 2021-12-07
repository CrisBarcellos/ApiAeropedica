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
    public class ReservaController : ControllerBase
    {
        private IReserva ReservaPersistence;

        public ReservaController(IReserva resPersistence)
        {
            ReservaPersistence = resPersistence;
        }

        [HttpGet, Route("Listar")]
        public ActionResult<List<Reserva>> Listar()
        {
            try
            {
                return ReservaPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar as Reservas!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Reserva>> ListarPorId(decimal cd_psgr, decimal nr_voo, string data)
        {
            try
            {
                return ReservaPersistence.ListarPorId(cd_psgr, nr_voo, data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar a Reserva!");
            }
        }

        [HttpPost, Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Reserva r)
        {
            try
            {
                await ReservaPersistence.Cadastrar(r);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar as Reservas!");
            }
        }

        [HttpDelete, Route("Deletar")]
        public async Task<IActionResult> Deletar(decimal cd_psgr, decimal nr_voo, string data)
        {
            try
            {
                await ReservaPersistence.Deletar(cd_psgr, nr_voo, data);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar a Reserva!");
            }
        }

        [HttpPut, Route("Alterar")]
        public async Task<IActionResult> Alterar(Reserva r)
        {
            try
            {
                await ReservaPersistence.Alterar(r);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar a Reserva!");
            }
        }
    }
}
