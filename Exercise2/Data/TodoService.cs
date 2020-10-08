﻿using System;
 using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Exercise1.Models;

namespace Exercise1.Data
{
    public class TodoService : ITodoService
    {
        private string todoFile = "todos.json";
        private string usersFile = "users.json";
        private IList<Todo> todos = new List<Todo>();
        private IList<User> users = new List<User>();

        public TodoService()
        {
            if (!File.Exists(todoFile))
            {
                WriteTodosToFile(todoFile, out var productsAsJson);
            }
            else
            {
                string content = File.ReadAllText(todoFile);
                todos = JsonSerializer.Deserialize<List<Todo>>(content);
            }
        }

        
        public IList<Todo> GetTodos()
        {
            List<Todo> tmp = new List<Todo>(todos);
            return tmp;
        }

        public IList<User> GetUsers()
        {
            if (!File.Exists(todoFile))
            {
                WriteTodosToFile( usersFile, out var productsAsJson);
            }
            else
            {
                string content = File.ReadAllText(usersFile);
                users = JsonSerializer.Deserialize<List<User>>(content);
            }
            return users;
        }

        public bool AddTodo(Todo todo)
        {
            if (todo.AssigneeUserName == null || todo.Title == null)
            {
                return false;
            }
            int max = todos.Count != 0 ? todos.Max(todo => todo.TodoId) : 0;
            todo.TodoId = (++max);
            todos.Add(todo);
            WriteTodosToFile(todoFile, out var productsAsJson);
            return true;
        }

        public void RemoveTodo(int todoId)
        {
            Todo toRemove = todos.First(t => t.TodoId == todoId);
            todos.Remove(toRemove);
            WriteTodosToFile(todoFile, out var productsAsJson);
        }

        public void UpdateTodo(Todo todo)
        {
            Todo toUpdate = todos.First(t => t.TodoId == todo.TodoId);
            toUpdate.IsCompleted = todo.IsCompleted;
            WriteTodosToFile(todoFile,out string productsAsJson);
        }

        private void WriteTodosToFile(string path, out string productsAsJson)
        {
            productsAsJson = JsonSerializer.Serialize(todos);
            File.WriteAllText(todoFile, productsAsJson);
        }
    }
}