import React,{useState,useEffect} from "react";
import { getEmployees,handleUpdate,handleDelete,handleSearch,fetchEmployees} from "../services/api";

import EmployeeForm from "./EmployeeForm";

const EmployeeList: React.FC = () => {
    const [employees, setEmployees] = useState([]);
    const [isEdit, setIsEdit] = useState(false);
    const [editId, setEditId] = useState<number | null>(null);  
    const [initialData, setInitialData] = useState({name: "", email: "", phone: 0, address: ""});    

    useEffect(() => {
        fetchEmployees().then(data => setEmployees(data));
    })
export default EmployeeList;