using System.Collections.Generic;

 namespace Exercise1.Models
{
    public interface ITodoService
    {
        IList<Todo> GetTodos();
        IList<User> GetUsers();
        bool AddTodo(Todo todo);
        void RemoveTodo(int todoId);
        void UpdateTodo(Todo todo);
    }
}