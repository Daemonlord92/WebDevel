import React from 'react';
import {
  BrowserRouter as Router,
  Routes,
  Route
} from "react-router-dom";
import NavBar from './component/static/navbar';
import Home from './component/static/home';

import './App.scss';

function App() {
  return (
    <Router>
      <NavBar />
      <Routes>
        <Route path="/" element={ <Home />} />
      </Routes>
    </Router>
  );
}

export default App;
