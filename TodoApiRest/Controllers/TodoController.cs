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

        /// <summary>
        /// Returns a list of existing Todo items...
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Todo/
        ///
        /// </remarks>
        /// <returns>Returns a specific Todo item</returns>
        /// <response code="200">Returns a list of existing Todo items</response>
        /// <response code="500">Internal error</response>
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

        /// <summary>
        /// Returns a specific Todo item...
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/Todo/1
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Returns a specific Todo item</returns>
        /// <response code="200">Returns the specific todo item</response>
        /// <response code="404">If the item don't exist</response>
        /// <response code="500">Internal error</response>
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

        /// <summary>
        /// Create a Todo item...
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Todo/
        ///
        /// </remarks>
        /// <returns>Create a Todo item</returns>
        /// <response code="200">Item has been created successfully.</response>
        /// <response code="400">The parameter name is required.</response>
        /// <response code="500">Internal error</response>
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

        /// <summary>
        /// Edit a Todo item...
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/Todo/1
        ///
        /// </remarks>
        /// <returns>Edit a Todo item</returns>
        /// <response code="200">Item has been edited successfully.</response>
        /// <response code="400">The parameter name is required.</response>
        /// <response code="404">If the item don't exist</response>
        /// <response code="500">Internal error</response>
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

                return Ok("Item has been edited successfully.");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Delete a Todo item...
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/Todo/1
        ///
        /// </remarks>
        /// <returns>Edit a Todo item</returns>
        /// <response code="200">Item has been Deleted successfully.</response>
        /// <response code="404">If the item don't exist</response>
        /// <response code="500">Internal error</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(string id)
        {
            try
            {
                TodoItem todoItem = _service.Get(id);

                if (todoItem == null)
                    return NotFound();

                _service.Remove(todoItem.Id);

                return Ok("Item has been Deleted successfully.");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
