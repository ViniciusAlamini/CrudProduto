using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controller
{
    [ApiController]
    public abstract class GenericController<T> : ControllerBase where T : class
    {
        protected readonly GenericRepository<T> _genericRepository;

        public GenericController(GenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository ?? throw new ArgumentNullException(nameof(genericRepository));
        }

        [HttpGet("BuscarPorId{id}")]
        public async Task<ActionResult<T>> BuscarPorId(int id)
        {
            try
            {
                var buscar = await _genericRepository.BuscarPorId(id);
                if (buscar == null)
                {
                    return NotFound($"Item com ID {id} não encontrado.");
                }
                return Ok(buscar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar o item: {ex.Message}");
            }
        }

        [HttpGet("BuscarTodos")]
        public async Task<ActionResult<IEnumerable<T>>> BuscarTodos()
        {
            try
            {
                var buscar = await _genericRepository.SelecionarTodos();
                return Ok(buscar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar todos os itens: {ex.Message}");
            }
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<T>> Salvar([FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest("Entidade não pode ser nula.");
            }

            try
            {
                var savedEntity = await _genericRepository.Salvar(entity);
                return Ok(savedEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar o item: {ex.Message}");
            }
        }

        [HttpPut("editar")]
        public async Task<ActionResult<T>> Atualizar([FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest("Entidade não pode ser nula.");
            }

            try
            {
                var updatedEntity = await _genericRepository.Update(entity);
                return Ok(updatedEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar o item: {ex.Message}");
            }
        }

        [HttpDelete("deletar")]
        public async Task<ActionResult<T>> Delete(int id)
        {
            try
            {
                T entity = await _genericRepository.BuscarPorId(id);
                if (entity == null)
                {
                    return NotFound($"Item com ID {id} não encontrado.");
                }

                _genericRepository.Delete(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar o item: {ex.Message}");
            }
        }

        
    }
}
