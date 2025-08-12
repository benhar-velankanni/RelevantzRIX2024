import React from "react";
import {
  render,
  screen,
  fireEvent,
  waitFor,
  act,
} from "@testing-library/react";
import renderer from 'react-test-renderer';
import App from "./App";
import axios from "axios";

jest.mock("axios");

describe("App and CustomerManager Integration", () => {
  const mockCustomers = [
    { id: 1, name: "Alice", email: "alice@example.com", phone: "1234567890" },
    { id: 2, name: "Bob", email: "bob@example.com", phone: "0987654321" },
    { id: 3, name: "Charlie", email: "charlie@example.com", phone: "1112223333" },
    { id: 4, name: "Dave", email: "dave@example.com", phone: "4445556666" },
    { id: 5, name: "Eve", email: "eve@example.com", phone: "7778889990" },
  ];

  beforeEach(() => {
    jest.clearAllMocks();
  });

  test("matches snapshot for initial render with no customers", async () => {
    axios.get.mockResolvedValue({ data: [] });

    const tree = renderer.create(<App />);
    await Promise.resolve(); // allow useEffect to run
    expect(tree.toJSON()).toMatchSnapshot();
  });

  test("matches snapshot for initial render", async () => {
    const tree = renderer.create(<App />);
    expect(tree.toJSON()).toMatchSnapshot();
  });

  test("matches snapshot for render with customer list", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });

    const tree = renderer.create(<App />);
    await Promise.resolve(); // allow useEffect to run
    expect(tree.toJSON()).toMatchSnapshot();
  });

  test("renders App and CustomerManager components", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });

    await act(async () => {
      render(<App />);
    });

    expect(
      screen.getByRole("heading", { name: /online salon booking/i })
    ).toBeInTheDocument();
    expect(screen.getByText(/Customer Manager/i)).toBeInTheDocument();
  });

  test("fetches and displays customer data on render", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });

    await act(async () => {
      render(<App />);
    });

    expect(screen.getByText("Alice")).toBeInTheDocument();
    expect(screen.getByText("Bob")).toBeInTheDocument();
    expect(screen.getByText("Charlie")).toBeInTheDocument();
    expect(screen.getByText("Dave")).toBeInTheDocument();
    expect(screen.getByText("Eve")).toBeInTheDocument();
  });

  test("creates a new customer and displays it", async () => {
    const newCustomer = {
      id: 6,
      name: "Frank",
      email: "frank@example.com",
      phone: "2223334444",
    };
    axios.get.mockResolvedValue({ data: mockCustomers });
    axios.post.mockResolvedValue({ data: newCustomer });

    await act(async () => {
      render(<App />);
    });

    fireEvent.change(screen.getByPlaceholderText(/Name/i), {
      target: { value: "Frank" },
    });
    fireEvent.change(screen.getByPlaceholderText(/Email/i), {
      target: { value: "frank@example.com" },
    });
    fireEvent.change(screen.getByPlaceholderText(/Phone/i), {
      target: { value: "2223334444" },
    });

    await act(async () => {
      fireEvent.click(screen.getByRole("button", { name: /Add Customer/i }));
    });

    expect(screen.getByText("Frank")).toBeInTheDocument();
  });

  test("edits an existing customer and updates the display", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });
    axios.put.mockResolvedValue({});

    await act(async () => {
      render(<App />);
    });

    await act(async () => {
      fireEvent.click(screen.getAllByText(/Edit/i)[0]); // Edit Alice
    });

    fireEvent.change(screen.getByPlaceholderText(/Name/i), {
      target: { value: "Alice Updated" },
    });

    await act(async () => {
      fireEvent.click(screen.getByRole("button", { name: /Update Customer/i }));
    });

    expect(screen.getByText("Alice Updated")).toBeInTheDocument();
  });

  test("deletes a customer and removes it from display", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });
    axios.delete.mockResolvedValue({});

    await act(async () => {
      render(<App />);
    });

    await act(async () => {
      fireEvent.click(screen.getAllByText(/Delete/i)[0]); // Delete Alice
    });

    expect(screen.queryByText("Alice")).not.toBeInTheDocument();
  });

  test("deletes a customer and removes it from display", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });
    axios.delete.mockResolvedValue({});

    await act(async () => {
      render(<App />);
    });

    await act(async () => {
      fireEvent.click(screen.getAllByText(/Delete/i)[1]); // Delete Bob
    });

    expect(screen.queryByText("Bob")).not.toBeInTheDocument();
  });

  test("edits a customer and updates the display", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });
    axios.put.mockResolvedValue({});

    await act(async () => {
      render(<App />);
    });

    await act(async () => {
      fireEvent.click(screen.getAllByText(/Edit/i)[1]); // Edit Bob
    });

    fireEvent.change(screen.getByPlaceholderText(/Name/i), {
      target: { value: "Bob Updated" },
    });

    await act(async () => {
      fireEvent.click(screen.getByRole("button", { name: /Update Customer/i }));
    });

    expect(screen.getByText("Bob Updated")).toBeInTheDocument();
  });

  test("edits a customer and updates the display", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });
    axios.put.mockResolvedValue({});

    await act(async () => {
      render(<App />);
    });

    await act(async () => {
      fireEvent.click(screen.getAllByText(/Edit/i)[2]); // Edit Charlie
    });

    fireEvent.change(screen.getByPlaceholderText(/Name/i), {
      target: { value: "Charlie Updated" },
    });

    await act(async () => {
      fireEvent.click(screen.getByRole("button", { name: /Update Customer/i }));
    });

    expect(screen.getByText("Charlie Updated")).toBeInTheDocument();
  });

  test("edits a customer and updates the display", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });
    axios.put.mockResolvedValue({});

    await act(async () => {
      render(<App />);
    });

    await act(async () => {
      fireEvent.click(screen.getAllByText(/Edit/i)[3]); // Edit Dave
    });

    fireEvent.change(screen.getByPlaceholderText(/Name/i), {
      target: { value: "Dave Updated" },
    });

    await act(async () => {
      fireEvent.click(screen.getByRole("button", { name: /Update Customer/i }));
    });

    expect(screen.getByText("Dave Updated")).toBeInTheDocument();
  });

  test("edits a customer and updates the display", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });
    axios.put.mockResolvedValue({});

    await act(async () => {
      render(<App />);
    });

    await act(async () => {
      fireEvent.click(screen.getAllByText(/Edit/i)[4]); // Edit Eve
    });

    fireEvent.change(screen.getByPlaceholderText(/Name/i), {
      target: { value: "Eve Updated" },
    });

    await act(async () => {
      fireEvent.click(screen.getByRole("button", { name: /Update Customer/i }));
    });

    expect(screen.getByText("Eve Updated")).toBeInTheDocument();
  });

  test("edits a customer and updates the display", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });
    axios.put.mockResolvedValue({});

    await act(async () => {
      render(<App />);
    });

    await act(async () => {
      fireEvent.click(screen.getAllByText(/Edit/i)[0]); // Edit Alice
    });

    fireEvent.change(screen.getByPlaceholderText(/Email/i), {
      target: { value: "alice.updated@example.com" },
    });

    await act(async () => {
      fireEvent.click(screen.getByRole("button", { name: /Update Customer/i }));
    });

    expect(screen.getByText("alice.updated@example.com")).toBeInTheDocument();
  });

  test("edits a customer and updates the display", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });
    axios.put.mockResolvedValue({});

    await act(async () => {
      render(<App />);
    });

    await act(async () => {
      fireEvent.click(screen.getAllByText(/Edit/i)[1]); // Edit Bob
    });

    fireEvent.change(screen.getByPlaceholderText(/Email/i), {
      target: { value: "bob.updated@example.com" },
    });

    await act(async () => {
      fireEvent.click(screen.getByRole("button", { name: /Update Customer/i }));
    });

    expect(screen.getByText("bob.updated@example.com")).toBeInTheDocument();
  });

  test("edits a customer and updates the display", async () => {
    axios.get.mockResolvedValue({ data: mockCustomers });
    axios.put.mockResolvedValue({});

    await act(async () => {
      render(<App />);
    });

    await act(async () => {
      fireEvent.click(screen.getAllByText(/Edit/i)[2]); // Edit Charlie
    });

    fireEvent.change(screen.getByPlaceholderText(/Email/i), {
      target: { value: "charlie.updated@example.com" },
    });

    await act(async () => {
      fireEvent.click(screen.getByRole("button", { name: /Update Customer/i }));
    });

  });
});