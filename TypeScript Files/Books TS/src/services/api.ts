import axios from "axios";

const API_URL = "http://localhost:5000/books";

export const getBooks = async () => {
  return axios.get(API_URL);
};

export const fetchBooks = async () => {
  try {
    const response = await getBooks();
    return response.data;
  } catch (error) {
    console.error("Error fetching users: ", error);
    throw error;
  }
};

export const createBook = async (book: {
  bookId: number | "";
  bookName: string;
  bookPages: number | "";
}) => {
  return axios.post(API_URL, book);
};

export const updateBook = async (
  id: number,
  book: {
    bookId: number | "";
    bookName: string;
    bookPages: number | "";
  }
) => {
  return axios.put(`${API_URL}/${id}`, book);
};

export const deleteBook = async (id: number) => {
  return axios.delete(`${API_URL}/${id}`);
};
