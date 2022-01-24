import React from 'react';
import { Link } from 'react-router-dom';
import { langShift } from '../Services/Utilities';
const Navbar = ({ language }) => {
  return (
    <nav className="">
      <Link to="/test">{langShift(language, 'Testaka', 'Test', 'Trial')}</Link>
      <Link to="/">{langShift(language, 'Kurdi', 'OSA', 'Apply')}</Link>
      <Link to="/party">
        {langShift(language, 'Kurdi', 'Festlokal', 'Party')}
      </Link>
      <Link to="/birgittaskapell">
        {langShift(language, 'Kyrkaka', 'Kapellet', 'The Chapel')}
      </Link>
      <Link to="/contact">
        {langShift(language, 'Kurdi', 'Kontakt', 'Contact')}
      </Link>
      <Link to="/program">Bröllopsdagen</Link>
    </nav>
  );
};

export default Navbar;
