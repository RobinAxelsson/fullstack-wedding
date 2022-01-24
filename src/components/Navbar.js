import React from 'react';
import button from '../minicomponents/button'
const Navbar = ({ setLanguage }) => {
  return (
    <div>
          {button('Svenska', () => setLanguage('swe'))}
          {button('Kurdi', () => setLanguage('kurdi'))}
          {button('English', () => setLanguage('eng'))}
    </div>
  );
};

export default Navbar;
