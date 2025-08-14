import "./App.css";

function UserAge() {
  //Check the age eligibility.
  const user1 = {
    firstName: "Nisanth",
    lastName: "Saravanan",
    age: 10,
  };

  const user2 = {
    firstName: "Bonsai",
    lastName: "Plays",
    age: 21,
  };

  const checkAge = (user) => {
    if (user.age >= 18) {
      return <p>{user.firstName} is eligible. Given age: {user.age}.</p>;
    } else {
      return <p>{user.firstName} is not eligibile. Given age: {user.age}.</p>;
    }
  };

  return (
    <div className="App">
      <header className="App-header">
        <h3>Check the age eligibility.</h3>
        <p>
          {checkAge(user1)}
          {checkAge(user2)}
        </p>
      </header>
    </div>
  );
}

export default UserAge;
