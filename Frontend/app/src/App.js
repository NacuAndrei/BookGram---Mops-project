import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { Login } from "./pages/authentication/Login";
import { RecoverPassword } from "./pages/authentication/RecoverPassword";
import { Register } from "./pages/authentication/Register";
import "./pages/authentication/Authentication.css";

function App() {
  return (
    <>
      <Router>
        <Routes>
          <Route exact path="" element={<Login />} />
          <Route
            exact
            path="/Authentication/RecoverPassword"
            element={<RecoverPassword />}
          />
          <Route exact path="/Authentication/Register" element={<Register />} />
        </Routes>
      </Router>
    </>
  );
}

export default App;
