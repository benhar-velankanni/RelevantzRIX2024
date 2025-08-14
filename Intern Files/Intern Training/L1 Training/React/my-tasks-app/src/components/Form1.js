import "../App.css";
import React, { useState } from "react";

function Form1() {
  const [data, setData] = useState({
    Name: "",
    Email: "",
    Age: 0,
  });

  const handleSubmit = (event) => {
    event.preventDefault();
    if (data.Name === "" || data.Email === "" || data.Age === 0) {
      alert("Please fill all the fields");
    } else {
      alert(`Name: ${data.Name}\n Email: ${data.Email}\n Age: ${data.Age}`);
    }
  };

  return (
    <div class={"App"}>
      <header class={"App-header"}>
        <h3>Simple Form</h3>
        <form>
          <table>
            <tr>
              <td class={"var"}>
                <label>Name: </label>
              </td>
              <td>
                <input
                  class={"varValue"}
                  type="text"
                  value={data.Name}
                  onChange={(e) => setData({ ...data, Name: e.target.value })}
                  placeholder="Enter your Name"
                />
              </td>
            </tr>
            <tr>
              <td class={"var"}>
                <label>Email: </label>
              </td>
              <td>
                <input
                  class={"varValue"}
                  type="Email"
                  value={data.Email}
                  onChange={(e) => setData({ ...data, Email: e.target.value })}
                  placeholder="Enter your Email"
                />
              </td>
            </tr>
            <tr>
              <td class={"var"}>
                <label>Age: </label>
              </td>
              <td>
                <input
                  class={"varValue"}
                  type="number"
                  step="1"
                  value={data.Age}
                  onChange={(e) => setData({ ...data, Age: e.target.value })}
                  placeholder="Enter your Age"
                />
              </td>
            </tr>
            <tr>
              <td></td>
              <td>
                <button type="submit" onClick={(event) => handleSubmit(event)}>
                  Submit
                </button>
              </td>
            </tr>
          </table>
        </form>
      </header>
    </div>
  );
}

export default Form1;
