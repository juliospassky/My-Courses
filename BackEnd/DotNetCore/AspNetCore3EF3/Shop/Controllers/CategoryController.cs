using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("v1/categories")]
    public class CategoryContoller : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.AsNoTracking().ToListAsync();
            return categories;
        }


        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Category>> GetById(int id, [FromServices] DataContext context)
        {
            var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }


        [HttpPost]
        [Route("")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<Category>> Post([FromBody] Category model, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = $"Não foi possível inserir a categoria: \r\n{ex.Message}" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Put(int id, [FromBody]Category model, [FromServices] DataContext context)
        {
            if (id != model.Id)
                return NotFound(new { message = "Categoria não encontrada" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Category>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(new { message = $"Falha ao atualizar categoria tente novamente\r\n {ex.Message}" });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = $"Não foi possível atualizar a categoria \r\n {ex.Message}" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Delete(int id, [FromServices] DataContext context)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return NotFound(new { message = "Categoria não encontrada" });

            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return category;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover a categoria" });

            }
        }
    }
}