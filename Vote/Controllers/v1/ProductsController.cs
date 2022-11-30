using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vote.Application.Products.Commands.CreateProduct;
using Vote.Application.Products.Commands.DeleteProduct;
using Vote.Application.Products.Commands.UpdateProduct;
using Vote.Application.Products.Queries.ExportProducts;
using Vote.Application.Products.Queries.GetProducts;
using Vote.Data.Context;
using Vote.Domain.Entities;

namespace Vote.WebApi.Controllers.v1
{
    
    public class ProductsController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult<ProductsVm>> Get()
        {
            return await Mediator.Send(new GetProductsQuery());
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportProductQuery { Id = id });
            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
