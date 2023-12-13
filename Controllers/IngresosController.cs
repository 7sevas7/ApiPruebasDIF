using ApiPruebasDIF.DB;
using ApiPruebasDIF.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiPruebasDIF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : Controller
    {
        private readonly DBContexts __context;
        public IngresosController(DBContexts context)
        {
            __context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Inser() {
            List<UnidadesIngresos?> insertList = new List<UnidadesIngresos?>();
            var serialize = new JsonSerializer();

            //var pathRoot = hostEnvironment.ContentRootPath;
            var folder = Path.Combine("Assets");
            var file = Path.Combine(folder, "EgresosMes.json");
            try
            {

                using (var reader = new StreamReader(file))
                using (var jsonResult = new JsonTextReader(reader))
                {
                    while (jsonResult.Read())
                    {
                        //Verificamos que que comience como objeto que cumpla el formato de json 
                        if (jsonResult.TokenType == JsonToken.StartObject)
                        {
                            var obj = serialize.Deserialize<UnidadesIngresos>(jsonResult);
                            insertList.Add(obj);
                            if (insertList.Count == 300)
                            {
                                await __context.UnidadesIngreso.AddRangeAsync(insertList);
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
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
        }

    }
}
