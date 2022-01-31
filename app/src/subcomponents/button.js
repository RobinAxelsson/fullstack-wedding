import React from 'react';

const button = (text, func) => (
  <button
    className="btn-style"
    onClick={(e) => {
      e.preventDefault();
      func();
    }}
  >
    {text}
  </button>
);

export default button;
