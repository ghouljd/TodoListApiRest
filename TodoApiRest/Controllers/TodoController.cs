using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApiRest.Models;
using TodoApiRest.Services;

namespace TodoApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _service;

        public TodoController(TodoService service)
        {
            _service = service;
        }

        // GET: api/Todo
        [HttpGet]
        public IActionResult GetTodoItems()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public IActionResult GetTodoItem(string id)
        {
            try
            {
                TodoItem todoItem = _service.Get(id);

                if (todoItem == null)
                    return NotFound();

                return Ok(todoItem);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Todo
        [HttpPost]
        public IActionResult PostTodoItem(TodoItem item)
        {
            try
            {
                if (item.Name == null)
                    return BadRequest("The parameter name is required.");

                _service.Create(item);
                return Ok("Item has been created successfully.");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public IActionResult PutTodoItem(string id, TodoItem item)
        {
            try
            {
                if (item.Name == null)
                    return BadRequest("The parameter name is required.");

                TodoItem originalItem = _service.Get(id);
                if (originalItem == null)
                    return NotFound();

                _service.Update(id, item);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(string id)
        {
            try
            {
                TodoItem todoItem = _service.Get(id);

                if (todoItem == null)
                    return NotFound();

                _service.Remove(todoItem.Id);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
