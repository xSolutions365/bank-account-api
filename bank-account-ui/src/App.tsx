import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import BankAccountList from "./components/BankAccountList";
import CreateAccountForm from "./components/CreateAccountForm";
import "./styles.css";

const App: React.FC = () => {
  return (
    <Router>
      <div id="main-container">
        <h1>Bank Account Management</h1>

        <nav>
          <ul>
            <li><Link to="/">View Accounts</Link></li>
            <li><Link to="/create">Create Account</Link></li>
          </ul>
        </nav>

        <Routes>
          <Route path="/" element={<BankAccountList />} />
          <Route path="/create" element={<CreateAccountForm />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;
