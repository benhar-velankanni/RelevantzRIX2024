import axios from "axios";

const API_URL = "http://localhost:5000/employees";

export const getEmployees = async () => axios.get(API_URL);

export const fetchEmployees = async () => {
  try {
    const response = await getEmployees();
    return response.data;
  } catch (error) {
    console.error("Error fetching users:", error);
    throw error;
  }
};

export const createEmployee = async (employee: {
  empId: number;
  empName: string;
  empAge: number;
  empDesignation: string;
}) => {
  return axios.post(API_URL, employee);
};

export const updateEmployee = async (
  id: number,
  employee: {
    empId: number;
    empName: string;
    empAge: number;
    empDesignation: string;
  }
) => {
  return axios.put(`${API_URL}/${id}`, employee);
};

export const deleteEmployee = async (id: number) =>
  axios.delete(`${API_URL}/${id}`);
