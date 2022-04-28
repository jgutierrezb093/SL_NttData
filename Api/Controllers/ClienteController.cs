using Application.Features.ClienteFeatures.Commands;
using Application.Features.ClienteFeatures.Commands.CreateCliente;
using Application.Features.ClienteFeatures.Commands.UpdateCliente;
using Application.Features.ClienteFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class ClienteController : BaseApiController
    {

        /// <summary>
        /// Get Clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetClientesListQuery()));
        }

        /// <summary>
        /// Get Cliente by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await Mediator.Send(new GetClienteQuery { Id = id }));
        }

        /// <summary>
        /// Creates a New Cliente.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateClienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Updates the Cliente Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Edit(UpdateClienteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
