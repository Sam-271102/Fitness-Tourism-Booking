import React, { useEffect, useState } from 'react';
import api from '../api';
import './Bookings.css';

const Bookings = () => {
  const [bookings, setBookings] = useState([]);
  const [packages, setPackages] = useState([]);
  const [form, setForm] = useState({
    customerName: '',
    bookingDate: '',
    packageId: ''
  });

  useEffect(() => {
    api.get('/Bookings').then(res => setBookings(res.data));
    api.get('/Packages').then(res => setPackages(res.data));
  }, []);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await api.post('/Bookings', form);
    const res = await api.get('/Bookings');
    setBookings(res.data);
    setForm({ customerName: '', bookingDate: '', packageId: '' });
  };

  return (
    <div className="booking-container">
      <h1 className="page-title">Book Your Experience</h1>
      
      <form className="booking-form" onSubmit={handleSubmit}>
        <input
          type="text"
          name="customerName"
          placeholder="Your Name"
          value={form.customerName}
          onChange={handleChange}
          required
        />
        <input
          type="date"
          name="bookingDate"
          value={form.bookingDate}
          onChange={handleChange}
          required
        />
        <select name="packageId" value={form.packageId} onChange={handleChange} required>
          <option value="">Select a Package</option>
          {packages.map(pkg => (
            <option key={pkg.id} value={pkg.id}>{pkg.name}</option>
          ))}
        </select>
        <button type="submit">Book Now</button>
      </form>

      <h2 className="sub-title">Recent Bookings</h2>
      <ul className="booking-list">
        {bookings.map(b => (
          <li key={b.id}>
            {b.customerName} - {new Date(b.bookingDate).toLocaleDateString()}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Bookings;
