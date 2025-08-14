import "./App.css";

function UserAge() {
  //Prop Training.
  function PrintProp(props) {
    return (
      <p class={"detailsPara"}>The given prop was: {props.propToPrint}.</p>
    );
  }

  return (
    <div className="App">
      <header className="App-header">
        <h3>Prop Training I.</h3>
        <PrintProp propToPrint={"Bonsai Plays"} />
      </header>
    </div>
  );
}

export default UserAge;
