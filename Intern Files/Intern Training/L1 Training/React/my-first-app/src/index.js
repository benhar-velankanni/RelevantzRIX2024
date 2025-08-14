import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import User from "./User";
import UserAge from "./UserAge";
import UserGreet from "./UserGreet";
import UserDetails from "./UserDetails";
import UserRole from "./UserRole";
import PropTraining from "./PropTraining";
import reportWebVitals from "./reportWebVitals";

const root = ReactDOM.createRoot(document.getElementById("root"));

root.render(
  <React.StrictMode>
    <App />
    <User />
    <UserAge />
    <UserGreet />
    <UserDetails />
    <UserRole />
    <PropTraining />
  </React.StrictMode>
);
// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
