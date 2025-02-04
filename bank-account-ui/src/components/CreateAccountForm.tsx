import React, { useState } from "react";
import { createAccount } from "../services/api";

const CreateAccountForm: React.FC = () => {
  const [accountNumber, setAccountNumber] = useState("");
  const [accountHolderName, setAccountHolderName] = useState("");
  const [balance, setBalance] = useState(0);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    await createAccount({ accountNumber, accountHolderName, balance });
    alert("Account Created!");
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Create Bank Account</h2>
      <input placeholder="Account Number" value={accountNumber} onChange={(e) => setAccountNumber(e.target.value)} required />
      <input placeholder="Account Holder" value={accountHolderName} onChange={(e) => setAccountHolderName(e.target.value)} required />
      <input type="number" placeholder="Balance" value={balance} onChange={(e) => setBalance(Number(e.target.value))} required />
      <button type="submit">Create Account</button>
    </form>
  );
};

export default CreateAccountForm;
