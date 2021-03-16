using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.WebApi.Data;
using ProAgil.WebApi.Model;

namespace ProAgil.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProagilController:Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get([FromServices] DataContext context){
            
            try
            {
                var evento = await  context.Eventos.ToListAsync();
            
                return   Ok(evento);
            }
            catch (System.Exception)
            {
                 return  this.StatusCode(StatusCodes.Status500InternalServerError,"Falha no Banco de Dados");
            }
            

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Getbyid([FromServices] DataContext context , int id){
            try
            {
                var result = await context.Eventos.FirstOrDefaultAsync( x => x.EventoId == id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                  return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha no Banco de Dados");
         
            }
            
        }
        
    }

}