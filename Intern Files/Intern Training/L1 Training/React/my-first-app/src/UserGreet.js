import "./App.css";

function UserGreet() {
  //Display time based Greetings using Userdata
  const user = {
    firstName: "Nisanth",
    lastName: "Saravanan",
  };

  let timeOfDay;
  let hours = new Date().getHours();

  const checkTime = () => {
    if (hours < 12) {
      timeOfDay = "Good Morning";
    } else if (hours < 18) {
      timeOfDay = "Good Afternoon";
    } else {
      timeOfDay = "Good Evening";
    }
    return timeOfDay;
  };

  return (
    <div className="App">
      <header className="App-header">
        <h3>Display time based Greetings using Userdata.</h3>
        <p>
          {checkTime()} {user.firstName}!
        </p>
      </header>
    </div>
  );
}

export default UserGreet;
