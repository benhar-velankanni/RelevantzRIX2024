import "../App.css";
import React, { useState } from "react";

class BankAccount {
  constructor(owner, balance) {
    this.owner = owner;
    this.balance = balance;
  }

  deposit(amount) {
    if (amount > 0) {
      this.balance += amount;
    }
  }

  withdraw(amount) {
    if (amount > 0 && amount <= this.balance) {
      this.balance -= amount;
    }
  }
}

class SavingsAccount extends BankAccount {
  constructor(owner, balance) {
    super(owner, balance);
  }
}

class CurrentAccount extends BankAccount {
  constructor(owner, balance) {
    super(owner, balance);
  }
}

const App = () => {
  const [bank, setBank] = useState({
    savings: new SavingsAccount("Nisanth Saravanan", 1000),
    current: new CurrentAccount("Bonsai Plays", 500),
  });

  const handleDeposit = (type) => {
    const amount = parseFloat(prompt("Enter deposit amount:"));
    if (type === "savings") {
      bank.savings.deposit(amount);
    } else {
      bank.current.deposit(amount);
    }
    setBank({ ...bank });
  };

  const handleWithdraw = (type) => {
    const amount = parseFloat(prompt("Enter withdraw amount:"));
    if (type === "savings") {
      bank.savings.withdraw(amount);
    } else {
      bank.current.withdraw(amount);
    }
    setBank({ ...bank });
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>Banking System</h1>
        <div>
          <h4>Savings Account : {bank.savings.owner}</h4>
          <p>
            <i>Balance: ${bank.savings.balance}</i>
          </p>
          <button onClick={() => handleDeposit("savings")}>Deposit</button>
          <button onClick={() => handleWithdraw("savings")}>Withdraw</button>
        </div>
        <div>
          <h4>Current Account : {bank.current.owner}</h4>
          <p>
            <i>Balance: ${bank.current.balance}</i>
          </p>
          <button onClick={() => handleDeposit("current")}>Deposit</button>
          <button onClick={() => handleWithdraw("current")}>Withdraw</button>
        </div>
      </header>
    </div>
  );
};

export default App;
