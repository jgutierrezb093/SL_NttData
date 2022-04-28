using Application.Features.MovimientoFeatures.Commands;
using Application.Features.MovimientoFeatures.Commands.CreateMovimiento;
using Application.Features.MovimientoFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    public class MovimientosController : BaseApiController
    {
        /// <summary>
        /// Creates a New Movimiento.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateMovimientoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get all Movimientos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetMovimientosListQuery()));
        }

        /// <summary>
        /// Get Movimiento by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetMovimientoQuery { Id = id }));
        }
    }
}
