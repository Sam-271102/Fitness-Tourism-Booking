import React from 'react';
import './Destinations.css';

const destinations = [
  {
    id: 1,
    name: 'Hawaii Adventure',
    location: 'Hawaii',
    description: 'A tropical paradise with surfing and hiking.',
    imageUrl: 'https://images.unsplash.com/photo-1507525428034-b723cf961d3e'
  },
  {
    id: 2,
    name: 'Swiss Alps Retreat',
    location: 'Switzerland',
    description: 'Mountain getaway with skiing and trails.',
    imageUrl: 'https://images.unsplash.com/photo-1508264165352-258db2ebd59b'
  },
  {
    id: 3,
    name: 'Bali Wellness Escape',
    location: 'Bali',
    description: 'Island escape with yoga and meditation.',
    imageUrl: 'https://images.unsplash.com/photo-1506744038136-46273834b3fb'
  }
];

const Destinations = () => (
  <div className="destination-container">
    <h1 className="page-title">Explore Destinations</h1>
    <div className="destination-grid">
      {destinations.map(dest => (
        <div key={dest.id} className="destination-card">
          <img src={dest.imageUrl} alt={dest.name} className="destination-image" />
          <h2>{dest.name}</h2>
          <p>{dest.location}</p>
          <p>{dest.description}</p>
        </div>
      ))}
    </div>
  </div>
);

export default Destinations;
