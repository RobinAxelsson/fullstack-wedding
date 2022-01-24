import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import GuestForm from './components/GuestForm';
import { useState } from 'react';
import Devbar from './components/Devbar';
import Navbar from './components/Navbar';

function App() {
  document.title = 'Wedding app';
  const [language, setLanguage] = useState('eng');

  return (
    <div className="flex flex-col min-h-screen">
      <Router>
        <Routes>
          <Route
            path="/"
            element={
              <div>
                <Navbar language={language} setLanguage={setLanguage}/>
                <GuestForm language={language} />
                {process.env.REACT_APP_ENVIRONMENT === 'Development' && (<Devbar />)}
              </div>
            }
          />
          <Route path="/test" element={<h1>Hello Test</h1>} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
