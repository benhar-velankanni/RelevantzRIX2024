import "../App.css";
import React, { useState, useEffect } from "react";

function HookEffect() {
  const [count, setCount] = useState(0);

  useEffect(() => {
    console.log("Count changed to: ", count);
  });

  return (
    <div className="App">
      <header className="App-header">
        <h3>Not So Simple Counter</h3>
        <p>
          <i>
            Using useEffect to have a console message every-time the count is
            changed.
          </i>
        </p>
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

export default HookEffect;
