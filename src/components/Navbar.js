import React from 'react';
import { Link } from 'react-router-dom';
import { langShift } from '../Services/Utilities';
import Links from '../subcomponents/Links';

const Navbar = ({ language, toggle }) => {
  return (
    <nav
    className='flex justify-between items-center h-16 bg-white text-black relative shadow-sm'
    role='navigation'
  >
    <div className='px-4 cursor-pointer md:hidden' onClick={toggle}>
      <svg
        className='w-8 h-8'
        fill='none'
        stroke='currentColor'
        viewBox='0 0 24 24'
        xmlns='http://www.w3.org/2000/svg'
      >
        <path
          strokeLinecap='round'
          strokeLinejoin='round'
          strokeWidth='2'
          d='M4 6h16M4 12h16M4 18h16'
        />
      </svg>
    </div>
    <div className='pr-8 md:block hidden space-x-8 text-lg'>
      <Links language={language} />
    </div>
  </nav>
);
};

export default Navbar;
