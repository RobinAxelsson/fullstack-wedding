import React from 'react';

const FlagBar = ({ setLanguage }) => {
  return (
    <div className='flex flex-row items-center'>
      <div className="px-2 cursor-pointer" onClick={() => setLanguage('swe')}>
        <svg
          className="w-12 h-8"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="1 1 13 8"
        >
          <path fill="#006aa7" d="M0 0h16v10H0z"></path>
          <path fill="#fecc00" d="M0 4h5V0h2v4h9v2H7v4H5V6H0z"></path>
        </svg>
      </div>
      <div className="px-2 cursor-pointer" onClick={() => setLanguage('kurdi')}>
        <svg
          xmlns="http://www.w3.org/2000/svg"
          className="w-12 h-10"
          viewBox="0 0 900 600"
        >
          <g fillRule="evenodd">
            <path fill="#fff" d="M0 0h900v600H0z"></path>
            <path fill="#ed2024" d="M0 0h900v200H0z"></path>
            <path fill="#278e43" d="M0 400h900v200H0z"></path>
          </g>
          <path
            fill="#febd11"
            fillRule="evenodd"
            d="M450 150l11.24 76.264 33.222-69.563-11.738 76.19 52.249-56.68-33.674 69.344 66.634-38.761-52.616 56.338 75.098-17.399-66.885 38.327 76.89 5.51-75.21 16.909 71.85 27.929-76.852-6.011 60.425 47.867-71.666-28.397 43.632 63.55-60.113-48.259 22.962 73.589-43.217-63.834.25 77.087L450 376.264 427.518 450l.251-77.087-43.217 63.834 22.962-73.589-60.113 48.26 43.632-63.551-71.666 28.397 60.425-47.867-76.852 6.011 71.85-27.93-75.21-16.908 76.89-5.51-66.885-38.327 75.098 17.399-52.616-56.338 66.634 38.76-33.674-69.343 52.249 56.68-11.738-76.19 33.221 69.563z"
          ></path>
        </svg>
      </div>
      <div className="px-2 cursor-pointer" onClick={() => setLanguage('eng')}>
      <svg
      xmlns="http://www.w3.org/2000/svg"
      className="w-13 h-8"
      viewBox="5 0 50 30"
    >
      <clipPath id="s">
        <path d="M0 0v30h60V0z"></path>
      </clipPath>
      <clipPath id="t">
        <path d="M30 15h30v15zv15H0zH0V0zV0h30z"></path>
      </clipPath>
      <g clipPath="url(#s)">
        <path fill="#012169" d="M0 0v30h60V0z"></path>
        <path stroke="#fff" strokeWidth="6" d="M0 0l60 30m0-30L0 30"></path>
        <path
          stroke="#C8102E"
          strokeWidth="4"
          d="M0 0l60 30m0-30L0 30"
          clipPath="url(#t)"
        ></path>
        <path stroke="#fff" strokeWidth="10" d="M30 0v30M0 15h60"></path>
        <path stroke="#C8102E" strokeWidth="6" d="M30 0v30M0 15h60"></path>
      </g>
    </svg>
    </div>
    </div>
  );
};

export default FlagBar;
