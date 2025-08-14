import "./App.css";

function User() {
  // Print a username.
  // const user = {
  //   firstName: "Nisanth",
  //   lastName: "Saravanan",
  // };

  // const greetUser = (user) => {
  //   return <p>Hello {user.firstName}.</p>;
  // };

  // return (
  //   <div className="App">
  //     <header className="App-header">
  //       <h3>Print a username.</h3>
  //       <p>{greetUser(user)}</p>
  //     </header>
  //   </div>
  // );

  // Check to see if the username is available and then print accordingly.
  const user1 = {
    firstName: "Nisanth",
    lastName: "Saravanan",
  };

  const user2 = {
    firstName: "",
    lastName: "",
  };

  const user3 = {
    firstName: "",
    lastName: "Charles",
  };

  const checkName = (user) => {
    if (user.firstName === "" && user.lastName === "") {
      return <p>Hello Stranger.</p>;
    } else if (user.firstName === "" && user.lastName !== "") {
      return <p>Hello {user.lastName}.</p>;
    } else {
      return <p>Hello {user.firstName}.</p>;
    }
  };

  return (
    <div className="App">
      <header className="App-header">
        <h3>Check to see if the username is available and then print accordingly.</h3>
        <p>
          {checkName(user1)}
          {checkName(user2)}
          {checkName(user3)}
        </p>
      </header>
    </div>
  );
}

export default User;
