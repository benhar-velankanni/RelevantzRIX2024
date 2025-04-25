import axios from "axios";

const API_URL = "http://localhost:5000/users";


export const getEmployees = async () => axios.get(API_URL);
export const handleAdd = async (data: any) => axios.post(API_URL, data);

export const handleUpdate = async (id: number, data: any) => axios.put(`${API_URL}/${id}`, data);

export const handleDelete = async (id: number) => axios.delete(`${API_URL}/${id}`);

export const handleSearch = async (data: any) => axios.get(`${API_URL}?name=${data.name}&email=${data.email}&phone=${data.phone}&address=${data.address}`);
export const fetchEmployees = async () => {

    try {
        const response = await axios.get(API_URL);
        return response.data;
    } catch (error) {
        console.log(error);
    }
}