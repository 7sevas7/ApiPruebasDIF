using ApiPruebasDIF.DB;
using ApiPruebasDIF.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ApiPruebasDIF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgresosController : ControllerBase
    {
        private readonly DBContexts __context;
        private readonly IHostEnvironment hostEnvironment;

        public EgresosController(DBContexts context)
        {
            __context = context;
        }

        [HttpPost]
        
        public async Task<IActionResult> Insert()
        {

            List<UnidadesPresupuesto?> insertList = new List<UnidadesPresupuesto?>();
            var serialize = new JsonSerializer();

            //var pathRoot = hostEnvironment.ContentRootPath;
            var folder = Path.Combine( "Assets");
            var file = Path.Combine(folder, "EgresosMes.json");
            try { 

            using (var reader = new StreamReader(file))
            using (var jsonResult = new JsonTextReader(reader))
            {
                while (jsonResult.Read())
                {
                    //Verificamos que que comience como objeto que cumpla el formato de json 
                    if (jsonResult.TokenType == JsonToken.StartObject)
                    {
                        var obj = serialize.Deserialize<UnidadesPresupuesto>(jsonResult);
                        insertList.Add(obj);
                        if (insertList.Count == 300)
                        {
                            await __context.UnidadesPresupuesto.AddRangeAsync(insertList);
                            __context.SaveChanges();
                            insertList.Clear();
                            __context.ChangeTracker.Clear();
                        }
                    }

                }
                await __context.AddRangeAsync(insertList);
                __context.SaveChanges();
                insertList.Clear();
                __context.ChangeTracker.Clear();

            }
                return Ok(new { msg = "Datos Guadados" });
            }
            catch(Exception ex){
                return BadRequest(new { msg = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            List<UnidadesPresupuesto> lista = new List<UnidadesPresupuesto>();
            lista =  __context.UnidadesPresupuesto.ToList();

            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetsId(int id)
        {
            Debug.WriteLine("ID>>"+id.ToString());
            string? Ids = Convert.ToString(id);
            List<UnidadesPresupuesto> lista = new List<UnidadesPresupuesto>();

            lista =   __context.UnidadesPresupuesto.Where(u => u.Cve_Rubro_Ingreso.Substring(2,2).Contains(Ids)).ToList();

            return StatusCode(StatusCodes.Status200OK,lista) ;
        }
    }
}
