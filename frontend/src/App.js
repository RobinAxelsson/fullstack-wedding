import './App.css';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import GuestForm from "./components/GuestForm";
const LANGUAGE = "eng";
function App() {
  document.title = "Wedding app";
  return (
    <div className="flex flex-col min-h-screen">
      <Router>
        {/* <LogoForm></LogoForm> */}
        <Routes>
          {/* <Route path="/" element={<TravelForm />} /> */}
          <Route path="/" element={(<GuestForm LANGUAGE={LANGUAGE} />)}/>
          <Route path="/test" element={(<h1>Hello Test</h1>)}/>
        </Routes>
      </Router>
      {/* <Footer /> */}
    </div>
  );
}

export default App;
