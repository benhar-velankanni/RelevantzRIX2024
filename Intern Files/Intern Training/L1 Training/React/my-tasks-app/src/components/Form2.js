import "../App.css";
import React, { useState } from "react";

function Form2() {
  const [data, setData] = useState({
    Name: "",
    Email: "",
    Password: "",
    ConfirmPassword: "",
  });

  const handleSubmit = (event) => {
    event.preventDefault();

    const re =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (
      data.Name === "" ||
      data.Email === "" ||
      data.Password === "" ||
      data.ConfirmPassword === ""
    ) {
      alert("Please fill all the fields");
    } else if (data.Password !== data.ConfirmPassword) {
      alert("Passwords do not match");
    } else if (!re.test(data.Email)) {
      alert("Please enter a valid email");
    } else {
      alert(
        `Name: ${data.Name}\n Email: ${data.Email}\n Password: ${data.Password}`
      );
    }
  };

  return (
    <div class={"App"}>
      <header class={"App-header"}>
        <h3>Not So Simple Form</h3>
        <form onSubmit={(event) => handleSubmit(event)}>
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
                  type="email"
                  value={data.Email}
                  onChange={(e) => setData({ ...data, Email: e.target.value })}
                  placeholder="Enter your Email"
                />
              </td>
            </tr>
            <tr>
              <td class={"var"}>
                <label>Password: </label>
              </td>
              <td>
                <input
                  class={"varValue"}
                  type="password"
                  value={data.Password}
                  onChange={(e) =>
                    setData({ ...data, Password: e.target.value })
                  }
                  placeholder="Enter your Password"
                />
              </td>
            </tr>
            <tr>
              <td class={"var"}>
                <label>Confirm Password: </label>
              </td>
              <td>
                <input
                  class={"varValue"}
                  type="password"
                  value={data.ConfirmPassword}
                  onChange={(e) =>
                    setData({ ...data, ConfirmPassword: e.target.value })
                  }
                  placeholder="Confirm your Password"
                />
              </td>
            </tr>
          </table>
          <button>Submit</button>
        </form>
      </header>
    </div>
  );
}

export default Form2;
