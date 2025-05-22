import axios from "axios";
import { useEffect, useState } from "react";

interface Budget {
    id: number;
    category: string;
    amount: number;
    date: string;
    mode: string;
}

const BudgetTable = () => {
    const [budgets, setBudgets] = useState<Budget[]>([]);
    const [searchBudget, setSearchBudget] = useState<string>("");
    const [editBudget, setEditBudget] = useState<Budget | null>(null);

    useEffect(() => {
        const fetchBudgets = async () => {
            try {
                const response = await axios.get("http://localhost:3000/budgets");
                setBudgets(response.data);
            } catch (error) {
                console.error(error);
            }
        };

        fetchBudgets();
    }, []);

    const handleDelete = async (expenseid: number) => {
        try {
            await axios.delete(`http://localhost:3000/budgets/${expenseid}`);
            setBudgets(budgets.filter((budget) => budget.id !== expenseid));
            alert("Budget deleted successfully!");
        } catch (error) {
            console.error(error);
        }
    };

    const handleUpdate = async (budget: Budget) => {
        try {
            await axios.put(`http://localhost:3000/budgets/${budget.id}`, budget);
            setBudgets(budgets.map((b) => (b.id === budget.id ? budget : b)));
            setEditBudget(null);
            alert("Budget updated successfully!");
        } catch (error) {
            console.error(error);
        }
    };

    const handleEdit = (budget: Budget) => {
        setEditBudget(budget);
    };

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) =>
        setSearchBudget(event.target.value);

    const filteredBudgets = budgets.filter((budget) =>
        budget.category.toLowerCase().includes(searchBudget.toLowerCase())
    );

    return (
        <div>
            <h2>Budget Search</h2>
            <input
                type="text"
                placeholder="Search by category"
                value={searchBudget}
                onChange={handleInputChange}
            />
            <table>
                <thead>
                    <tr>
                        <th>Category</th>
                        <th>Amount</th>
                        <th>Date</th>
                        <th>Mode</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {filteredBudgets.map((budget) => (
                        <tr key={budget.id}>
                            <td>
                                {editBudget?.id === budget.id ? (
                                    <input
                                        type="text"
                                        value={editBudget.category}
                                        onChange={(e) =>
                                            setEditBudget({
                                                ...editBudget,
                                                category: e.target.value,
                                            })
                                        }
                                    />
                                ) : (
                                    budget.category
                                )}
                            </td>
                            <td>
                                {editBudget?.id === budget.id ? (
                                    <input
                                        type="number"
                                        value={editBudget.amount}
                                        onChange={(e) =>
                                            setEditBudget({
                                                ...editBudget,
                                                amount: Number(e.target.value),
                                            })
                                        }
                                    />
                                ) : (
                                    budget.amount
                                )}
                            </td>
                            <td>
                                {editBudget?.id === budget.id ? (
                                    <input
                                        type="date"
                                        value={editBudget.date}
                                        onChange={(e) =>
                                            setEditBudget({
                                                ...editBudget,
                                                date: e.target.value,
                                            })
                                        }
                                    />
                                ) : (
                                    budget.date
                                )}
                            </td>
                            <td>
                                {editBudget?.id === budget.id ? (
                                    <input
                                        type="text"
                                        value={editBudget.mode}
                                        onChange={(e) =>
                                            setEditBudget({
                                                ...editBudget,
                                                mode: e.target.value,
                                            })
                                        }
                                    />
                                ) : (
                                    budget.mode
                                )}
                            </td>
                            <td>
                                <button onClick={() => handleUpdate(budget)} style={{backgroundColor: "blue"}}>Edit</button>
                                <button onClick={() => handleDelete(budget.id)} style={{backgroundColor: "red"}}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default BudgetTable;

