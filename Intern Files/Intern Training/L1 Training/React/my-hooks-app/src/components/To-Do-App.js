import "../App.css";
import React, { useState } from "react";

function ToDoApp() {
  const [tasks, setTasks] = useState([]);
  const [task, setTask] = useState("");

  const addTask = () => {
    setTasks([...tasks, task]);
    setTask("");
  };

  const removeTask = (index) => {
    const updatedTasks = [...tasks];
    updatedTasks.splice(index, 1);
    setTasks(updatedTasks);
  };

  const handleTaskChange = (event) => {
    setTask(event.target.value);
  };

  return (
    <div className="App">
      <header className="App-header">
        <h3>Simple To-Do App</h3>
        <input type="text" value={task} onChange={handleTaskChange} />
        <button onClick={addTask}>Add Task</button>
        <ol>
          {tasks.map((task, index) => (
            <li key={index}>
              {task}
              <button onClick={() => removeTask(index)}>Remove</button>
            </li>
          ))}
        </ol>
      </header>
    </div>
  );
}

export default ToDoApp;
