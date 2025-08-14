import "./App.css";

function UserDetails() {
  //Display user Profile Data.
  const user = {
    firstName: "Benhar",
    lastName: "Charles",
    age: 42,
    email: "benharcharles@gmail.com",
    location: "India",
  };

  const  displayDetails = (user) => {
    return (
      <div>
        <h4>User Details:</h4>
        <p class="detailsPara">
        <table>
          <tr>
          <td class={"var"}>Full Name: </td>
          <td class={"varValue"}>{user.firstName} {user.lastName}</td>
          </tr>
          <tr>
          <td class={"var"}>Email: </td>
          <td class={"varValue"}>{user.email}</td>
          </tr>
          <tr>
          <td class={"var"}>Age: </td>
          <td class={"varValue"}>{user.age}</td>
          </tr>
          <tr>
          <td class={"var"}>Location: </td>
          <td class={"varValue"}>{user.location}</td>
          </tr>
        </table>
        </p>
      </div>
    );
  }

  return (
    <div className="App">
      <header className="App-header">
        <h3>Display user Profile Data</h3>
        {displayDetails(user)}
      </header>
    </div>
  );
}

export default UserDetails;
