import "./App.css";

function UserRole() {
  // Display Name based on Role.
  const users = [
    {
      firstName: "Karthic",
      lastName: "Vethachalam",
      role: "Technical architecture",
    },
    { firstName: "John", lastName: "Doe", role: "admin" },
    { firstName: "Jane", lastName: "Smith", role: "guest" },
  ];

  function displayUsers(user) {
    if (user.role === "Technical architecture") {
      return (
        <p class="detailsPara">
          Logging in as Technical Architecture, Welcome {user.firstName} .
        </p>
      );
    } else if (user.role === "admin") {
      return (
        <p class="detailsPara">
          Logging in as Admin, Welcome {user.firstName}.
        </p>
      );
    } else {
      if (user.role === "guest") {
        return (
          <p class="detailsPara">
            Logging in as Guest, Welcome {user.firstName}.
          </p>
        );
      }
    }
  }

  return (
    <div className="App">
      <header className="App-header">
        <h3>Display Name based on Role.</h3>
        <p>
          {displayUsers(users[0])}
          {displayUsers(users[1])}
          {displayUsers(users[2])}
        </p>
      </header>
    </div>
  );
}

export default UserRole;
