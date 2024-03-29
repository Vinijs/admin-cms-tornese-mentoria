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
using System.IO;
using admin_cms.Models.Dominio.Services;
using System.Reflection;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Newtonsoft.Json.Linq;

namespace admin_cms.Controllers.API
{
    public class ApiAdministradoresController : ControllerBase
    {
        private readonly ContextoCms _context;

        public ApiAdministradoresController(ContextoCms context)
        {
            _context = context;
        }

        // GET: Administradores
        [HttpGet]
        [Route("/api/administradores.json")]
        public async Task<IActionResult> Index(int page = 1)
        {
            //   var itens =  _context.Administradores.ToListAsync().ToPagedList(1,2);
               
              var adms = from adm in await _context.Administradores.ToPagedListAsync(page,AdministradorService.ITENS_POR_PAGINA)
                  select new {
                    Id = adm.Id,
                    Nome = adm.Nome,
                    Telefone = adm.Telefone,
                    Email = adm.Email
                  };

              return StatusCode(200, adms);
        }

        [HttpPost]
        [Route("/api/administradores.json")]
        public async Task<IActionResult> Criar([FromBody] Administrador administrador)
        {   
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();
            return StatusCode(201, administrador);
        }

        [HttpPut]
        [Route("/api/administradores/{id}.json")]
        public async Task<IActionResult> Change([FromBody] Administrador administrador)
        {
            // string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "../../../";
            // string path = $"C:/Users/Vinicius/Documents/projeto-cms-comunidade/admin-cms/wwwroot/imgs/img-{administrador.Id}.jpg";

            var file = $"img-{administrador.Id}.jpg";
            string path = $"/tmp/{file}";
            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(administrador.Imagem.Replace("data:image/jpeg;base64,", "")));
            administrador.Imagem = uploadToS3(path, file);

            _context.Administradores.Update(administrador);
            await _context.SaveChangesAsync();
            return StatusCode(201, administrador);
        }

        //Colocar nas variáveis de ambiente
        //bucket = aulatornese
        //access key = AKIA3DVZFLJH30JVZNKB
        //Secret key = cEoCNgl/wMicS1ekhTpHbE4xqiVCypYSfw7vPETE

        private string uploadToS3(string filePath, string file)
        {
            try
            {
                 JToken jAppSettings = JToken.Parse(System.IO.File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
                 

                IAmazonS3 s3Client = new AmazonS3Client(jAppSettings["AwsId"].ToString(), jAppSettings["AwsKey"].ToString(), Amazon.RegionEndpoint.SAEast1);
                TransferUtility fileTransferUtility = new TransferUtility(s3Client);
                string bucketName = "aulatornese";
                fileTransferUtility.Upload(filePath, bucketName);

                GetPreSignedUrlRequest request1 = new GetPreSignedUrlRequest
                {
                    BucketName = bucketName,
                    Key = file,
                    Expires = DateTime.UtcNow.AddYears(1)
                };
               
                return s3Client.GetPreSignedURL(request1);
            }
            catch (AmazonS3Exception s3Exception)
            {
                Console.WriteLine(s3Exception.Message,
                                  s3Exception.InnerException);
                return "";
            }
        }

        [HttpDelete]
        [Route("/api/administradores/{id}.json")]
        public async Task<IActionResult> Destroy(int id)
        {   
            Administrador adm = await _context.Administradores.FindAsync(id);
            _context.Administradores.Remove(adm);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

    }
}
