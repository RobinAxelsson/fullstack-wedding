import {
  nameText,
  closestToText,
  submitBtnText,
  titleText,
} from '../Services/Translator';
import { useState } from 'react';
import { postGuest } from '../Services/ApiClient';

const GuestForm = ({ language }) => {
  const [name, setName] = useState([]);
  const [closestTo, setClosestTo] = useState([]);

  return (
    <div className="">
      <div className="flex justify-center items-center">
        {
          <form className="w-11/12 tablet:w-6/12 laptop:w-4/12 rounded-md border-white border-8 border-opacity-5 bg-white bg-opacity-75 mt-6 flex-col flex justify-center items-center">
            <div className="w-full border-white border-8 border-opacity-5 flex justify-center items-center">
              <h2 className="font-bold text-4xl">{titleText(language)}</h2>
            </div>
            <div className="mt-4 w-11/12">
              <input
                maxLength="30"
                type="text"
                className="w-full shadow-sm focus:ring-indigo-500 focus:border-indigo-500 block sm:text-sm border-gray-300 rounded-md"
                placeholder={nameText(language)}
                onChange={(e) => setName(e.target.value)}
                required
              />
            </div>
            <div className="mt-1 w-11/12">
              <input
                maxLength="30"
                type="text"
                className="w-full shadow-sm focus:ring-indigo-500 focus:border-indigo-500 block sm:text-sm border-gray-300 rounded-md"
                placeholder={closestToText(language)}
                required
                onChange={(e) => setClosestTo(e.target.value)}
              />
            </div>
            <button
              className="mt-1 inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md text-indigo-700 bg-indigo-100 hover:bg-indigo-200 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
              onClick={async (e) => {
                e.preventDefault();
                console.log('submitted', { name: name, closestTo: closestTo });
                await postGuest({ name: name, closestTo: closestTo, language: language });
              }}
            >
              {submitBtnText(language)}
            </button>
          </form>
        }
      </div>
    </div>
  );
};

export default GuestForm;
