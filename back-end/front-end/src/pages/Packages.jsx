import React from 'react';

const packages = [
  {
    id: 1,
    name: 'Surf & Strength',
    location: 'Hawaii',
    details: 'Includes beach workouts and surf lessons.'
  },
  {
    id: 2,
    name: 'Alpine Power',
    location: 'Swiss Alps',
    details: 'Mountain trail bootcamps and ski conditioning.'
  },
  {
    id: 3,
    name: 'Bali Bliss',
    location: 'Bali',
    details: 'Daily yoga, meditation, and spa treatments.'
  }
];

const Packages = () => (
  <div style={{ padding: '1rem' }}>
    <h1 className="page-title">Tour Packages</h1>
    <div className="package-list">
      {packages.map(pkg => (
        <div key={pkg.id} className="package-card" style={{ border: '1px solid #ccc', padding: '1rem', marginBottom: '1rem', borderRadius: '8px' }}>
          <h2>{pkg.name}</h2>
          <p><strong>Location:</strong> {pkg.location}</p>
          <p>{pkg.details}</p>
        </div>
      ))}
    </div>
  </div>
);

export default Packages;
