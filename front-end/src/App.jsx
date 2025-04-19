import { Routes, Route, Link } from 'react-router-dom';
import Destinations from './pages/Destinations';
import Bookings from './pages/Bookings';
import Workouts from './pages/Workouts';
import Packages from './pages/Packages';
import Exercises from './pages/Exercises';

function App() {
  return (
    <div style={{ padding: '1rem' }}>
      <nav style={{ marginBottom: '1rem' }}>
        <Link to="/destinations">Destinations</Link> |{' '}
        <Link to="/workouts">Workouts</Link> |{' '}
        <Link to="/packages">Packages</Link> |{' '}
        <Link to="/exercises">Exercises</Link> |{' '}
        <Link to="/bookings">Bookings</Link>
      </nav>

      <Routes>
        <Route path="/destinations" element={<Destinations />} />
        <Route path="/workouts" element={<Workouts />} />
        <Route path="/workouts/:destinationId" element={<Workouts />} />
        <Route path="/exercises" element={<Exercises />} />
        <Route path="/exercises/:destinationId" element={<Exercises />} />
        <Route path="/packages" element={<Packages />} />
        <Route path="/bookings" element={<Bookings />} />
      </Routes>
    </div>
  );
}

export default App;

