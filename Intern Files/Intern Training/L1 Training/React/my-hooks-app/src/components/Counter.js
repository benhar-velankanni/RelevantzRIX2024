import "../App.css";
import React, { useState } from "react";

function Counter() {
  const [count, setCount] = useState(0);

  return (
    <div className="App">
      <header className="App-header">
        <h3>Simple Counter</h3>
        <p>The count is {count}.</p>
        <div>
          <button onClick={() => setCount(count - 10)}>-10</button>
          <button onClick={() => setCount(count - 1)}>-1</button>
          <button onClick={() => setCount(0)}>Reset</button>
          <button onClick={() => setCount(count + 1)}>+1</button>
          <button onClick={() => setCount(count + 10)}>+10</button>
        </div>
      </header>
    </div>
  );
}

export default Counter;
