import axios from "axios";

const API_URL = "http://localhost:3000/users";

export const getUsers = async () => axios.get(API_URL);
export const createUser = async (user: { name: string; email: string }) => axios.post(API_URL, user);
export const updateUser = async (id: number, user: { name: string; email: string }) => axios.put(`${API_URL}/${id}`, user);
export const deleteUser = async (id: number) => axios.delete(`${API_URL}/${id}`);

export const fetchUsers = async () => {
    try {
        const response = await getUsers();
        return response.data;
    } catch (error) {
        console.error("Error fetching users:", error);
        throw error;
    }
};
