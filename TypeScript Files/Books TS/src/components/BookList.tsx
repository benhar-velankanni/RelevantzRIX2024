import {
  fetchBooks,
  createBook,
  updateBook,
  deleteBook,
} from "../services/api";
import BookForm from "./BookForm";
import "./BookList.css";
import { useState, useEffect } from "react";

const BookList: React.FC = () => {
  const [books, setBooks] = useState<any[]>([]);
  const [editingBook, setEditingBook] = useState<any | null>(null);

  useEffect(() => {
    fetchBooks().then(setBooks);
  }, []);

  const handleDelete = async (id: number) => {
    await deleteBook(id);
    fetchBooks().then(setBooks);
  };

  const handleEdit = async (book: any) => {
    setEditingBook(book);
  };

  const hanleUpdate = async (id: number, book: any) => {
    if (book.bookId === "" || book.bookName === "" || book.bookPages === "") {
      alert("All fields are required!");
      return;
    }
    if (!book.bookName) {
      alert("Book name is required!");
      return;
    }
    if (!book.bookId) {
      alert("Book iD is required!");
      return;
    }
    if (!book.bookPages) {
      alert("Book Pages is required!");
      return;
    }
    await updateBook(id, book);
  };

  const handleCreate = async (book: any) => {
    if (book.bookId === "" || book.bookName === "" || book.bookPages === "") {
      alert("All fields are required!");
      return;
    }
    if (!book.bookName) {
      alert("Book name is required!");
      return;
    }
    if (!book.bookId) {
      alert("Book iD is required!");
      return;
    }
    if (!book.bookPages) {
      alert("Book Pages is required!");
      return;
    }
    await createBook(book);
    fetchBooks().then(book);
  };

  if (books.length === 0) {
    return (
      <div>
        <h2>Books Form</h2>
        <BookForm
          fetchBooks={() => {
            fetchBooks().then(setBooks);
          }}
          isEditing={!!editingBook}
          editId={editingBook !== null ? editingBook.id : null}
          initialData={
            editingBook || {
              empId: 0,
              empName: "",
              empAge: 0,
              empDesignation: "",
            }
          }
          handleCreate={handleCreate}
          handleUpdate={hanleUpdate}
        />
        <h2>Books List</h2>
        <p>No Books Data Found!</p>
      </div>
    );
  } else {
    return (
      <div>
        <h2>Books Form</h2>
        <BookForm
          fetchBooks={() => {
            fetchBooks().then(setBooks);
          }}
          isEditing={!!editingBook}
          editId={editingBook !== null ? editingBook.id : null}
          initialData={
            editingBook || {
              empId: 0,
              empName: "",
              empAge: 0,
              empDesignation: "",
            }
          }
          handleCreate={handleCreate}
          handleUpdate={hanleUpdate}
        />
        <h2>Books List</h2>
        <table className="user-table">
          <thead>
            <tr>
              <th>Book ID</th>
              <th>Book Name</th>
              <th>Book Page</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {books.map((book: any) => (
              <tr key={book.id}>
                <td>{book.bookId}</td>
                <td>{book.bookName}</td>
                <td>{book.bookPages}</td>
                <td>
                  <button
                    className="edit-button"
                    onClick={() => handleEdit(book)}
                  >
                    Edit
                  </button>
                  <button
                    className="delete-button"
                    onClick={() => handleDelete(book.id)}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
};

export default BookList;
