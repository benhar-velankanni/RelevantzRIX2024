import React from "react";
import { useState, useEffect } from "react";
import "./BookForm.css";

interface BookFormProps {
  fetchBooks: () => void;
  isEditing: boolean;
  editId: number | null;
  initialData: {
    bookId: number | "";
    bookName: string;
    bookPages: number | "";
  };
  handleUpdate: (id: number, bookData: any) => Promise<void>;
  handleCreate: (bookData: any) => Promise<void>;
}

const BookForm: React.FC<BookFormProps> = ({
  fetchBooks,
  isEditing,
  editId,
  handleUpdate,
  handleCreate,
  initialData = {
    bookId: "",
    bookName: "",
    bookPages: "",
  },
}) => {
  const [bookId, setBookId] = useState(initialData.bookId);
  const [bookName, setBookName] = useState(initialData.bookName);
  const [bookPages, setBookPages] = useState(initialData.bookPages);

  useEffect(() => {
    setBookId(initialData.bookId || "");
    setBookName(initialData.bookName || "");
    setBookPages(initialData.bookPages || "");
  }, [initialData]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (isEditing && editId !== null) {
      await handleUpdate(editId, { bookId, bookName, bookPages });
    } else {
      await handleCreate({ bookId, bookName, bookPages });
    }

    fetchBooks();
    setBookId("");
    setBookName("");
    setBookPages("");
  };

  return (
    <div className="form-container">
      <form onSubmit={handleSubmit} noValidate>
        <table>
          <tr>
            <td style={{ textAlign: "left" }}>
              <label htmlFor="bookId">Book ID:</label>
            </td>
            <td>
              <input
                type="number"
                id="bookId"
                value={bookId}
                onChange={(e) => {
                  setBookId(parseInt(e.target.value));
                }}
              />
            </td>
          </tr>
          <tr>
            <td style={{ textAlign: "left" }}>
              <label htmlFor="bookName">Book Name:</label>
            </td>
            <td>
              <input
                type="text"
                id="bookName"
                value={bookName}
                onChange={(e) => {
                  setBookName(e.target.value);
                }}
              />
            </td>
          </tr>
          <tr>
            <td style={{ textAlign: "left" }}>
              <label htmlFor="bookPages">Book Pages:</label>
            </td>
            <td>
              <input
                type="number"
                id="bookPages"
                value={bookPages}
                onChange={(e) => {
                  setBookPages(parseInt(e.target.value));
                }}
              />
            </td>
          </tr>
          <br />
          <tr>
            <td colSpan={2}>
              <button className="submit-button" type="submit">
                {isEditing ? "Update" : "Submit"}
              </button>
            </td>
          </tr>
        </table>
      </form>
    </div>
  );
};

export default BookForm;
