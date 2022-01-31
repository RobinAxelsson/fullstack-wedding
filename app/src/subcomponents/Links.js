import React from 'react';
import { Link } from 'react-router-dom';
import { langShift } from '../Services/Utilities';

const Links = ({ language }) => {
  return (
    <>
      <Link to="/">{langShift(language, 'OSA', 'OSA', 'OSA')}</Link>
      <Link to="/party">
        {langShift(language, 'Kurdi', 'Festlokal', 'Party')}
      </Link>
      <Link to="/birgittaskapell">
        {langShift(language, 'Kyrkaka', 'Kapellet', 'Chapel')}
      </Link>
      <Link to="/contact">
        {langShift(language, 'Kurdi', 'Kontakt', 'Contact')}
      </Link>
      <Link to="/program">
        {langShift(language, 'Schemaka', 'Schema', 'Schedule')}
      </Link>
    </>
  );
};

export default Links;
