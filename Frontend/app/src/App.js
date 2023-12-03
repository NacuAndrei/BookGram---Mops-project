import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { Login } from "./pages/authentication/Login";
import { RecoverPassword } from './pages/authentication/RecoverPassword';
import './pages/authentication/Authentication.css'
function App() {
  return (
    <>
      <Router>
        <Routes>
          <Route exact path="" element={<Login />} />
          <Route exact path="/Authentication/RecoverPassword" element={<RecoverPassword/>}/>
        </Routes>
      </Router>
    </>
  );
}

export default App;
