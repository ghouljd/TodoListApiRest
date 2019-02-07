using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApiRest.Models;

namespace TodoApiRest.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<TodoItem> _todoItems;

        public TodoService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("TodoListDB"));
            var database = client.GetDatabase("TodoListDB");
            _todoItems = database.GetCollection<TodoItem>("Todos");
        }

        public List<TodoItem> Get()
        {
            return _todoItems.Find(todo => true).ToList();
        }

        public TodoItem Get(string id)
        {
            return _todoItems.Find(todo => todo.Id == id).FirstOrDefault();
        }

        public TodoItem Create(TodoItem todo)
        {
            todo.Id = Guid.NewGuid().ToString();
            _todoItems.InsertOne(todo);
            return todo;
        }

        public void Update(string id, TodoItem todoIn)
        {
            todoIn.Id = id;
            _todoItems.ReplaceOne(todo => todo.Id == id, todoIn);
        }

        public void Remove(TodoItem todoIn)
        {
            _todoItems.DeleteOne(todo => todo.Id == todoIn.Id);
        }

        public void Remove(string id)
        {
            _todoItems.DeleteOne(todo => todo.Id == id);
        }
    }
}
