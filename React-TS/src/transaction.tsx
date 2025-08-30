import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_URL = 'http://localhost:3000/userTrans'; // Update the API endpoint

type TransactionType = {
    id: number;
    sender: string;
    receiver: string;
    amount: number;
    description: string;
};

const Transaction = () => {
    const [trans, setTrans] = useState<TransactionType[]>([]);
    const [tran, setTran] = useState<Omit<TransactionType, 'id'>>({
        sender: '',
        receiver: '',
        amount: 0,
        description: ''
    });

    const [isEdit, setIsEdit] = useState<boolean>(false);
    const [editId, setEditId] = useState<number | null>(null);

    const fetchTrans = async () => {
            const response = await axios.get(API_URL);
            setTrans(response.data);
    };

    useEffect(() => {
        fetchTrans();
    }, []);

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if (isEdit && editId !== null) {
                await axios.put(`${API_URL}/${editId}`, { id: editId, ...tran });
        } else {
                await axios.post(API_URL, tran);
        }
        resetForm();
        fetchTrans();
    };

    const handleDelete = async (id: number) => {
            await axios.delete(`${API_URL}/${id}`);
        fetchTrans();
    };

    const resetForm = () => {
        setTran({
            sender: '',
            receiver: '',
            amount: 0,
            description: '',
        });
        setIsEdit(false);
        setEditId(null);
    };

    return (
        <div>
            <h2>Transaction</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="sender">Sender</label>
                    <input type="text" id="sender" value={tran.sender} onChange={(e) => setTran({ ...tran, sender: e.target.value })} />
                </div>
                <div>
                    <label htmlFor="receiver">Receiver</label>
                    <input type="text" id="receiver" value={tran.receiver} onChange={(e) => setTran({ ...tran, receiver: e.target.value })} />
                </div>
                <div>
                    <label htmlFor="amount">Amount</label>
                    <input type="number" id="amount" value={tran.amount} onChange={(e) => setTran({ ...tran, amount: Number(e.target.value) })} />
                </div>
                <div>
                    <label htmlFor="description">Description</label>
                    <input type="text" id="description" value={tran.description} onChange={(e) => setTran({ ...tran, description: e.target.value })} />
                </div> 
                <button type="submit" >Submit</button>
                <button type="button" >Cancel</button>

            </form>
            <h3>Transaction</h3>
            <table>
                <tr>
                    <th>Sender</th>
                    <th>Receiver</th>
                    <th>Amount</th>
                    <th>Description</th>
                    <th>Actions</th>
                </tr>
                <tbody>
                    {trans.map((trans) => (
                        <tr key={trans.id}>
                            <td>{trans.sender}</td>
                            <td>{trans.receiver}</td>
                            <td>{trans.amount}</td>
                            <td>{trans.description}</td>
                            <td>
                                <button 
                                onClick={
                                    () => {
                                        const { id, ...rest } = trans;
                                        setTran(rest);
                                        setIsEdit(true);
                                        setEditId(id);
                                    }
                                }>Edit</button>
                            </td>
                            <td>
                                <button onClick={() => handleDelete(trans.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default Transaction;
