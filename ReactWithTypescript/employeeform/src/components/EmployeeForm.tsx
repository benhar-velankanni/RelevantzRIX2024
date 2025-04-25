import React,{useState,useEffect} from "react";

interface EmployeeFormProps {
    fetchEmployees: () => void;
    isEdit: boolean;
    editId: number | null;
    initialData:{name: string, email: string, phone: number, address: string};
    handleUpdate:(id: number, userdata: any) => Promise<void>;
    handleAdd: (userdata: any) => Promise<void>;
    handleSearch: (userdata: any) => Promise<void>;
    handleDelete: (id: number) => Promise<void>;
  }

const EmployeeForm: React.FC<EmployeeFormProps> = ({ fetchEmployees, isEdit, editId, initialData, handleUpdate, handleAdd, handleSearch, handleDelete }) => {
    const [name, setName] = useState<string>("");
    const [email, setEmail] = useState<string>("");
    const [phone, setPhone] = useState<number>(0);
    const [address, setAddress] = useState<string>("");
    const [id, setId] = useState<number | null>(null);  

    useEffect(() => {
        if (isEdit && editId !== null) {
            setId(editId);
            setName(initialData.name);
            setEmail(initialData.email);
            setPhone(initialData.phone);
            setAddress(initialData.address);
        } else {
            setName("");
            setEmail("");
            setPhone(0);
            setAddress("");
            setId(null);
        }
    }, [isEdit, editId, initialData]);

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if (isEdit) {
            await handleUpdate(id!, { name, email, phone, address });
        } else {
            await handleAdd({ name, email, phone, address });
        }
        fetchEmployees();
        setName("");
        setEmail("");
        setPhone(0);
        setAddress("");
        setId(null);
    };

    const handleSearchSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        await handleSearch({ name, email, phone, address });
        fetchEmployees();
        setName("");
        setEmail("");
        setPhone(0);
        setAddress("");
        setId(null);
    };

    const handleDeleteSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        await handleDelete(id!);
        fetchEmployees();
        setName("");
        setEmail("");
        setPhone(0);
        setAddress("");
        setId(null);
    };

    return (
        <div>
             <h2>{isEdit ? "Edit Employee" : "Add Employee"}</h2>
            <form onSubmit={isEdit ? handleSearchSubmit : handleSubmit}>
              <TextField label="Name" value={name} onChange={(e) => setName(e.target.value)} />
                <TextField label="Email" value={email} onChange={(e)=> setEmail(e.target.value)}/>
                <TextField label="Phone" value={phone} onChange={(e) => setPhone(parseInt(e.target.value))} />
                <TextField label="Address" value={address} onChange={(e) => setAddress(e.target.value)} />
                <button type="submit">{isEdit ? "Search" : "Add"}</button>
            </form>
            {isEdit && (
                <form onSubmit={handleDeleteSubmit}>
                    <button type="submit">Delete</button>
                </form>
            )}
        </div>
    );
    };

    export default EmployeeForm;
