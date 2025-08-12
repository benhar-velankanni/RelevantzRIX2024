import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Table, Button, Form, Container, Row, Col, Alert } from 'react-bootstrap';

function CustomerManager() {
  const [customers, setCustomers] = useState([]);
  const [customer, setCustomer] = useState({ name: '', email: '', phone: '' });
  const [editingId, setEditingId] = useState(null);
  const [message, setMessage] = useState(null);

  // Fetch customers only once on mount
  useEffect(() => {
    fetchCustomers();
  }, []);

  // Debug: log editingId when it changes
  useEffect(() => {
    console.log("Editing ID changed:", editingId);
  }, [editingId]);

  const fetchCustomers = () => {
    axios.get('http://localhost:5174/api/CustomerApi')
      .then(response => {
        if (Array.isArray(response.data)) {
          setCustomers(response.data);
        } else {
          console.error('Unexpected response format:', response.data);
          setCustomers([]);
        }
      })
      .catch(error => {
        console.error('Error fetching customers:', error);
      });
  };

  const handleChange = (e) => {
    setCustomer({ ...customer, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      if (editingId) {
        // Edit mode
        await axios.put(`http://localhost:5174/api/CustomerApi/${editingId}`, {
          id: editingId,
          ...customer
        });
        setCustomers(customers.map(c => c.id === editingId ? { ...customer, id: editingId } : c));
      } else {
        // Add mode
        const response = await axios.post('http://localhost:5174/api/CustomerApi', customer);
        setCustomers([...customers, response.data]);
      }
      resetForm();
      setMessage(`Customer ${editingId ? 'updated' : 'added'} successfully!`);
    } catch (error) {
      console.error('Failed to submit customer:', error);
      setMessage(`Error: ${error.response.data}`);
    }
  };

  const handleEdit = (c) => {
    setCustomer({ name: c.name, email: c.email, phone: c.phone });
    setEditingId(c.id);
  };

  const handleDelete = (id) => {
    axios.delete(`http://localhost:5174/api/CustomerApi/${id}`)
      .then(() => {
        setCustomers(customers.filter(c => c.id !== id));
        if (editingId === id) resetForm();
        setMessage(`Customer deleted successfully!`);
      })
      .catch(error => {
        console.error('Error deleting customer:', error);
        setMessage(`Error: ${error.response.data}`);
      });
  };

  const resetForm = () => {
    setCustomer({ name: '', email: '', phone: '' });
    setEditingId(null);
    setMessage(null);
  };

  return (
    <Container>
      <h2 className="text-center mt-4">Customer  Manager System</h2>
      {message && <Row className="mb-4">
        <Col sm={12} md={{ span: 6, offset: 3 }}>
          <Alert variant="success">{message}</Alert>
        </Col>
      </Row>}

      <Form onSubmit={handleSubmit} className="mb-4">
        <Row>
          <Col sm={12} md={6}>
            <Form.Group className="mb-2">
              <Form.Label>Name</Form.Label>
              <Form.Control
                type="text"
                name="name"
                placeholder="Name"
                value={customer.name}
                onChange={handleChange}
                required
              />
            </Form.Group>
          </Col>
          <Col sm={12} md={6}>
            <Form.Group className="mb-2">
              <Form.Label>Email</Form.Label>
              <Form.Control
                type="email"
                name="email"
                placeholder="Email"
                value={customer.email}
                onChange={handleChange}
                required
              />
            </Form.Group>
          </Col>
        </Row>
        <Row>
          <Col sm={12} md={6}>
            <Form.Group className="mb-2">
              <Form.Label>Phone</Form.Label>
              <Form.Control
                type="text"
                name="phone"
                placeholder="Phone"
                value={customer.phone}
                onChange={handleChange}
                required
              />
            </Form.Group>
          </Col>
        </Row>
        <Button type="submit" variant={editingId ? "warning" : "success"}>
          {editingId ? "Update Customer" : "Add Customer"}
        </Button>
        {editingId && (
          <Button variant="secondary" className="ms-2" onClick={resetForm}>
            Cancel Edit
          </Button>
        )}
      </Form>

      {customers.length === 0 ? (
        <p className="text-center">No customers found.</p>
      ) : (
        <Table striped bordered hover responsive>
          <thead>
            <tr>
              <th>Name</th><th>Email</th><th>Phone</th><th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {customers.map(c => (
              <tr key={c.id}>
                <td>{c.name}</td>
                <td>{c.email}</td>
                <td>{c.phone}</td>
                <td>
                  <Button variant="primary" size="sm" onClick={() => handleEdit(c)}>Edit</Button>{' '}
                  <Button variant="danger" size="sm" onClick={() => handleDelete(c.id)}>Delete</Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      )}
    </Container>
  );
}

export default CustomerManager;

