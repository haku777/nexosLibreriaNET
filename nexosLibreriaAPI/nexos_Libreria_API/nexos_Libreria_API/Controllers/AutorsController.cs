using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexos_Libreria_API.Common.Dto;
using nexos_Libreria_API.Services.Interfaces;
using Nexos_Libreria_API.Common.Dto.Autors;
using Nexos_Libreria_API.Services.Services.Interfaces;

namespace Nexos_Libreria_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorsController : ControllerBase
    {
        private readonly IAutors _autors;
        public AutorsController(IAutors autors) { 
            _autors = autors;
        }

        [HttpGet]
        [Route("GetAutors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AutorsDto>>> GetAutors() {

            return await _autors.Get();
        }

        [HttpGet]
        [Route("GetAutorById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AutorsDto>> GetAutorById(int Id)
        {
            if (Id == 0)
                return BadRequest();

            var result = await _autors.GetById(Id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        [Route("AddAutor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AutorsDto>> AddAutor([FromBody] AutorsCreateDto autor)
        {

            if (autor == null)
                return BadRequest();

            var result = await _autors.AddAutor(autor);

            if (result == null)
                return BadRequest();

            return result;
        }


        [HttpPut]
        [Route("UpdateAutor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAutor(int Id, [FromBody] AutorsUpdateDto autor)
        {

            if (autor == null)
                return NotFound();

            var result = await _autors.GetById(autor.Id);

            if (result == null)
                return BadRequest();

            await _autors.UpdateAutor(autor);

            return NoContent();
        }


        //solo para pruebas
        [HttpDelete]
        [Route("DeleteAutor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAutor(int Id)
        {
            if (Id == 0)
                return BadRequest();

            var autor = await _autors.GetById(Id);
            if (autor == null)
                return NotFound();

            _autors.DeleteAutor(autor);

            return NoContent();
        }
    }
}
