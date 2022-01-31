import React from 'react';
import Links from '../subcomponents/Links';
const Dropdown = ({ isOpen, toggle, language }) => {
  return (
    <div
      className={
        isOpen
          ? 'grid grid-rows-5 items-center text-lg m-5'
          : 'hidden'
      }
      onClick={toggle}
    >
    <Links language={language} />
    </div>
  );
};

export default Dropdown;