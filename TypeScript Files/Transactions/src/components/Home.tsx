import "./Home.css";
import "../App.css";
import { useEffect } from "react";

function Home() {
  useEffect(() => {
    document.title = "Z Contacts - Home";
  });

  return (
    <div className="App">
      <header className="App-header">
        <div className="home-container">
          <h1 className="home-title">Welcome to Z - Transactions</h1>
          <p className="home-description">
            Z - Transactions is a simple app that allows you to manage your
            transactions with ease. You can add, update and view your
            transactions. This app is built using React, TypeScript and
            Bootstrap.
          </p>
        </div>
      </header>
    </div>
  );
}

export default Home;
