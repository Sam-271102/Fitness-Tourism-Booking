import React from 'react';
import './Exercises.css';

const exercises = [
  {
    id: 1,
    name: 'Sun Salutations',
    imageUrl: 'https://cdn.pixabay.com/photo/2017/03/27/14/56/yoga-2176668_960_720.jpg',
  },
  {
    id: 2,
    name: 'Trail Running',
    imageUrl: 'https://cdn.pixabay.com/photo/2020/04/27/17/57/running-5100867_960_720.jpg',
  },
  {
    id: 3,
    name: 'Deep Breathing Meditation',
    imageUrl: 'https://cdn.pixabay.com/photo/2016/11/29/04/00/adult-1867743_960_720.jpg',
  },
];

const Exercises = () => {
  return (
    <div className="exercise-container">
      <h1 className="page-title">Explore Exercises</h1>
      <div className="exercise-grid">
        {exercises.map(exercise => (
          <div key={exercise.id} className="exercise-card">
            <img src={exercise.imageUrl} alt={exercise.name} className="exercise-image" />
            <h2>{exercise.name}</h2>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Exercises;
