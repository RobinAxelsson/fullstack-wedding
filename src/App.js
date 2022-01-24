import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import GuestForm from './components/GuestForm';
import { useState } from 'react';
import Devbar from './components/Devbar';
import LangBar from './components/LangBar';
import Navbar from './components/Navbar';

function App() {
  document.title = 'Wedding app';
  const [language, setLanguage] = useState('eng');

  return (
    <div className="flex flex-col min-h-screen">
      <Router>
          <Navbar language={language} />
        <Routes>
          <Route
            path="/"
            element={
              <div>

                <GuestForm language={language} />
                <LangBar language={language} setLanguage={setLanguage}/>
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
