using Tasks.Models;
using Task = Tasks.Models.Task;

namespace TasksTestProject;

public class TaskManagerTest
{
    private TaskManager _taskManager;

    [SetUp]
    public void Setup()
    {
        _taskManager = new TaskManager();
    }

    [Test]
    public void AddTask_ShouldIncreaseTaskCount()
    {
        // Arrange
        var task = new Task("Test task");
        // Act
        _taskManager.AddTask(task);
        // Assert
        Assert.AreEqual(1, _taskManager.GetTasks().Count);
    }
    
    [Test]
    public void GetTasks_ShouldReturnAllTasks()
    {
        // Arrange
        Random rnd = new Random();
        int rndNumber = rnd.Next(100);
        for (int i = 0; i < rndNumber; i++)
        {
            _taskManager.AddTask(new Task($"Task {i}"));
        }
        // Act
        int tasksNumber = _taskManager.GetTasks().Count();
        // Assert
        Assert.AreEqual(rndNumber, tasksNumber);
    }
    
    [Test]
    public void RemoveTask_NonExistingTask_ShouldNotChangeTaskCount()
    {
        // Arrange
        Random rnd = new Random();
        int rndNumber = rnd.Next(100);
        int notExistingRndNumber = rnd.Next(101,200);        
        for (int i = 0; i < rndNumber; i++)
        {
            _taskManager.AddTask(new Task($"Task {i}"));
        }
        // Act
        _taskManager.RemoveTask(notExistingRndNumber);
        // Assert
        Assert.AreEqual(rndNumber, _taskManager.GetTasks().Count());
    }
}