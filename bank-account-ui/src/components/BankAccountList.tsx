import React, { useEffect, useState } from "react";
import { getAccounts } from "../services/api";
import "../styles.css";

const BankAccountList: React.FC = () => {
  const [accounts, setAccounts] = useState<{ id: number; accountHolderName: string; balance: number }[]>([]);

  useEffect(() => {
    getAccounts().then(setAccounts);
  }, []);

  return (
    <div className="account-list">
      <h2>Bank Accounts</h2>
      <ul>
        {accounts.map((acc) => (
          <li key={acc.id}>
            <span>{acc.accountHolderName}</span>
            <span>${acc.balance.toLocaleString()}</span>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default BankAccountList;
