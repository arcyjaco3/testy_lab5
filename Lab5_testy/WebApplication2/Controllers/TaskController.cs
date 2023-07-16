using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Models;
using Task = Tasks.Models.Task;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TaskManager _tasks = new TaskManager();
        
// GET: api/TaskControler
        [HttpGet]
        public List<Task> GetAllTasks()
        {
            return _tasks.GetTasks();
        }

        // GET: api/TaskControler/5
        [HttpGet("{id}", Name = "Get")]
        public Task GetTaskById(int id)
        {
            return _tasks.GetTaskById(id);
        }
        
        // PUT: api/TaskControler/5
        [HttpPost]
        public void UpdateTask(Task task)
        {
            _tasks.AddTask(task);
        }
        
        // Post: api/TaskControler/5
        [HttpPut]
        public void CreateTask(Task task)
        {
            _tasks.AddTask(task);
        }

        // DELETE: api/TaskControler/5
        [HttpDelete("{id}")]
        public void DeleteTask(Task task)
        {
            _tasks.DeleteTask(task.Id);
        }
    }
}
