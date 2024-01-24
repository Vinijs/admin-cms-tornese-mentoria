using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using admin_cms.Models.Dominio.Entidades;
using admin_cms.Models.Infraestrutura.Database;
using admin_cms.Models.Infraestrutura.Autenticacao;
using X.PagedList;
using admin_cms.Models.Dominio.Services;
using Microsoft.AspNetCore.Authorization;

namespace admin_cms.Controllers.API
{
    public class ApiLoginController : ControllerBase
    {
        private readonly ContextoCms _context;

        public ApiLoginController(ContextoCms context)
        {
            _context = context;
        }

        // GET: Administradores
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/login.json")]
        public async Task<IActionResult> Login([FromBody] Administrador adm)
        {               
              try
              {
                    var administrador = (await _context.Administradores.Where(a => a.Email == adm.Email && a.Senha == adm.Senha).FirstAsync());
                    return StatusCode(200, new {
                    Id = administrador.Id,
                    Nome = administrador.Nome,
                    Email = administrador.Email,
                    Acesso = administrador.Acesso,
                    Telefone = administrador.Telefone,
                    Token = Token.GerarToken(administrador)
                });
              }
              catch
              {
                return StatusCode(401, new {
                Mensagem = "Usuário ou senha inválidos"
                });
              }              
        }
    }
}
