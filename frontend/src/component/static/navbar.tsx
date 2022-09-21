import * as React from 'react';
import { Link } from 'react-router-dom';

const NavBar = () => {
    return(
    <nav className='nav d-flex justify-content-end bg-dark'>
        <Link className='nav-link text-light' to="/">
          Home
        </Link>
        <Link className='nav-link text-light' to="/bug-tracker">
          Bug Tracker
        </Link>
        <Link className='nav-link text-light' to='/project'>
          Project
        </Link>
        <Link className='nav-link text-light' to='/contact-me'>
          Contact Me
        </Link>
      </nav>
    )
}

export default NavBar;