using IdempotentAPI.Filters;
using Microsoft.AspNetCore.Mvc;
using WebApiIdempotencia.DTOs;

namespace WebApiIdempotencia.Controllers;

[ApiController]
[Route("api/[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
[Idempotent(Enabled = true, UseIdempotencyOption = true)]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] UserRequest request)
    {
        //declarando que o meu RNG é um numero randomico, para a geração de um Id;
        var rng = new Random();

        //Criando um objeto para resposta ao POSTMAN/SWAGGER;
        var userResponse = new UserResponse
        {
            Id = rng.Next(1, 1000),
            DataCriacao = DateTime.Now
        };

        return Ok(userResponse);
    }
}