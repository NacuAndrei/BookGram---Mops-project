import './pages/authentication/Authentication.css'
// import {Login} from "./Authentication/Login";
// import {Register} from "./Authentication/Register";
// import { RecoverPassword } from "./Authentication/RecoverPassword";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { Login } from "./pages/authentication/Login";
function App() {
  return (
    <>
      <Router>
        <Routes>
          <Route exact path="" element={<Login />} />
        </Routes>
      </Router>
    </>
  );
}

export default App;
