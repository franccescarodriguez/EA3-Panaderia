using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Panaderia.Api.DTOs;
using Panaderia.Api.Models;
using Panaderia.Api.Repositories;

namespace Panaderia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _repository;
        private readonly IMapper _mapper;

        public ProductosController(IProductoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/productos
        [HttpGet]
        public ActionResult<IEnumerable<ProductoDto>> GetProductos()
        {
            var productos = _repository.GetAll();
            return Ok(_mapper.Map<IEnumerable<ProductoDto>>(productos));
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public ActionResult<ProductoDto> GetProducto(int id)
        {
            var producto = _repository.GetById(id);

            if (producto == null)
                return NotFound();

            return Ok(_mapper.Map<ProductoDto>(producto));
        }

        // POST: api/productos
        [HttpPost]
        public ActionResult<ProductoDto> CreateProducto(ProductoCreateDto productoCreateDto)
        {
            var producto = _mapper.Map<Producto>(productoCreateDto);

            _repository.Add(producto);
            _repository.Save();

            var productoDto = _mapper.Map<ProductoDto>(producto);

            return CreatedAtAction(nameof(GetProducto), new { id = productoDto.Id }, productoDto);
        }

        // PUT: api/productos/5
        [HttpPut("{id}")]
        public IActionResult UpdateProducto(int id, ProductoCreateDto productoUpdateDto)
        {
            var producto = _repository.GetById(id);

            if (producto == null)
                return NotFound();

            _mapper.Map(productoUpdateDto, producto);

            _repository.Update(producto);
            _repository.Save();

            return NoContent();
        }

        // DELETE: api/productos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProducto(int id)
        {
            var producto = _repository.GetById(id);

            if (producto == null)
                return NotFound();

            _repository.Delete(id);
            _repository.Save();

            return NoContent();
        }
    }
}
