import {
  nameText,
  closestToText,
  submitBtnText,
  titleText,
  ageText,
  relationText,
  hobbiesText,
} from '../Services/Translator';
import { useState } from 'react';
import { postGuest } from '../Services/ApiClient';



const GuestForm = ({ language }) => {
  const [name, setName] = useState([]);
  const [closestTo, setClosestTo] = useState([]);
  const [age, setAge] = useState([]);
  const [relation, setRelation] = useState([]);
  const [hobbies, setHobbies] = useState([]);

  

  return (
    <div className="">
      <div className="flex justify-center items-center">
        {
          <form className="w-11/12 tablet:w-6/12 laptop:w-4/12 rounded-md border-white border-8 border-opacity-5 bg-white bg-opacity-75 mt-6 flex-col flex justify-center items-center">
            <div className="w-full border-white border-8 border-opacity-5 flex justify-center items-center">
              <h2 className="font-bold text-4xl">{titleText(language)}</h2>
            </div>
            {
              (() => {const field = (text, setFunc) => {
                return (
                  <div className="mt-4 w-11/12">
                    <input
                      maxLength="30"
                      type="text"
                      className='w-full shadow-sm focus:ring-indigo-500 focus:border-indigo-500 block sm:text-sm border-gray-300 rounded-md'
                      placeholder={text}
                      onChange={(e) => setFunc(e.target.value)}
                      required
                    />
                  </div>
                );
              };              
              return <>
                {field(nameText(language), setName)}
                {field(closestToText(language), setClosestTo)}
                {field(ageText(language), setAge)}
                {field(hobbiesText(language), setHobbies)}
                {field(relationText(language), setRelation)}
              </>
            })()
          }
            <button
              className='btn-style'
              onClick={async (e) => {
                e.preventDefault();
                let guest = {
                  name,
                  closestTo,
                  myPreferedLanguage: language,
                  relation,
                  age,
                  hobbies: hobbies,
                };
                console.log('submitted', guest);
                await postGuest(guest);
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
