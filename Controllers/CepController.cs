using consultaCep_backend.Application.Delete;
using consultaCep_backend.Application.GetAll;
using consultaCep_backend.Application.Register;
using consultaCep_backend.Application.Update;
using consultaCep_backend.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace consultaCep_backend.Controllers
{
    [ApiController]
    [Produces("application/json")]

    public class CepController : Controller
    {
        private readonly IRegisterCep _register;
        private readonly IGetAllEnderecosService _getAllEnderecosService;
        private readonly IUpdateEnderecosService _updateEnderecosService;
        private readonly IDeleteEnderecoService _deleteEnderecoService;

        public CepController(IRegisterCep register, 
            IGetAllEnderecosService getAllService,
            IDeleteEnderecoService deleteEnderecoService,
            IUpdateEnderecosService updateEnderecosService
            )
        {
            _register = register;
            _getAllEnderecosService = getAllService;
            _deleteEnderecoService = deleteEnderecoService;
            _updateEnderecosService = updateEnderecosService;

        }

        [HttpPost("api/[controller]/register")]
        public async Task<IActionResult> Register([FromBody] string cep)
        {
            try
            {

                var result = await _register.Register(cep);

                return Ok(result);


            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("api/[controller]/getAll")]
        public async Task<IActionResult> GetAll( string search)
        {
            try
            {
                var result = await _getAllEnderecosService.GetAll(search);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("api/[controller]/update")]
        public async Task<IActionResult> GetAll(UpdateRequest request)
        {
            try
            {
                var result = await _updateEnderecosService.Update(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("api/[controller]/delete")]
        public async Task<IActionResult> GetAll([FromBody]int id)
        {
            try
            {
                var result = await _deleteEnderecoService.Delete(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}