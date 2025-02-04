import axios from "axios";

const API_BASE_URL = "http://localhost:5000/api/BankAccount"; // Adjust the port if necessary

export const getAccounts = async () => {
  const response = await axios.get(API_BASE_URL);
  return response.data;
};

export const getAccountById = async (id: number) => {
  const response = await axios.get(`${API_BASE_URL}/${id}`);
  return response.data;
};

export const createAccount = async (account: { accountNumber: string; accountHolderName: string; balance: number }) => {
  const response = await axios.post(API_BASE_URL, account);
  return response.data;
};

export const updateAccount = async (id: number, account: { accountNumber: string; accountHolderName: string; balance: number }) => {
  await axios.put(`${API_BASE_URL}/${id}`, account);
};

export const deleteAccount = async (id: number) => {
  await axios.delete(`${API_BASE_URL}/${id}`);
};
