import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import GuestForm from './components/GuestForm';
import { useState } from 'react';
import { languageBtnText } from './Services/Translator';
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
                <GuestForm language={language} />
                <button
                  className="mt-1 inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md text-indigo-700 bg-indigo-100 hover:bg-indigo-200 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
                  onClick={(e) => {
                    e.preventDefault();
                    setLanguage(
                      language === 'swe'
                        ? 'eng'
                        : language === 'eng'
                        ? 'kurdi'
                        : language === 'kurdi'
                        ? 'swe'
                        : undefined
                    );
                  }}
                >
                  {languageBtnText(language)}
                </button>
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
