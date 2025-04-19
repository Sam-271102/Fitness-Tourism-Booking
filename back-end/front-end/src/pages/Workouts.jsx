import React from 'react';
import './Workouts.css';

const workouts = [
  {
    id: 1,
    name: 'Beach Yoga',
    description: 'Morning yoga sessions on the beach in Hawaii.'
  },
  {
    id: 2,
    name: 'Mountain Hike',
    description: 'High-intensity alpine hiking for strength and endurance.'
  },
  {
    id: 3,
    name: 'Meditation Flow',
    description: 'Guided breathing and relaxation flow in Bali.'
  }
];

const Workouts = () => (
  <div className="workout-container">
    <h1 className="page-title">Workouts for Your Trip</h1>
    <div className="workout-grid">
      {workouts.map(workout => (
        <div key={workout.id} className="workout-card">
          <h2>{workout.name}</h2>
          <p>{workout.description}</p>
        </div>
      ))}
    </div>
  </div>
);

export default Workouts;
