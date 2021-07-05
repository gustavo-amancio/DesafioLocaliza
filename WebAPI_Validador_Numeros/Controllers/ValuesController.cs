using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Classes_Projeto;
using TemplateApplication.Interface;

namespace WebAPI_Validador_Numeros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserValidadorService userService;

        public ValuesController(IUserValidadorService _userService)
        {
            userService = _userService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Olá! Seja muito bem vindo a API de validação de Divisores e Números primos da Localiza!", "" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Resposta> Get(int id)
        {
            return userService.Calcula_Dados_Numero(id);
        }
    }
}
