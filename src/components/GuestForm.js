import {
  langShift,
} from '../Services/Utilities';
import { useState } from 'react';
import { postGuest } from '../Services/ApiClient';
import button from '../subcomponents/button';

const GuestForm = ({ language }) => {
  const [name, setName] = useState([]);
  const [closestTo, setClosestTo] = useState([]);
  const [age, setAge] = useState([]);
  const [relation, setRelation] = useState([]);
  const [specialFood, setSpecialFood] = useState([]);
  const [hobbies, setHobbies] = useState([]);
  const [email, setEmail] = useState([]);

  return (
    <div className="">
      <div className="flex justify-center items-center">
        {
          <form className="w-11/12 tablet:w-6/12 laptop:w-4/12 rounded-md border-white border-8 border-opacity-5 bg-white bg-opacity-75 mt-6 flex-col flex justify-center items-center">
            <div className="w-full border-white border-8 border-opacity-5 flex justify-center items-center">
              <h2 className="font-bold text-4xl">
                {langShift(
                  language,
                  'Bexerben bo',
                  'Fira våran dag!',
                  'Join our wedding!'
                )}
              </h2>
            </div>
            {(() => {
              const field = (text, setFunc) => {
                return (
                  <div className="mt-4 w-11/12">
                    <input
                      maxLength="30"
                      type="text"
                      className="w-full shadow-sm focus:ring-indigo-500 focus:border-indigo-500 block sm:text-sm border-gray-300 rounded-md"
                      placeholder={text}
                      onChange={(e) => setFunc(e.target.value)}
                      required
                    />
                  </div>
                );
              };
              return (
                <>
                  {field(
                    langShift(language, 'Nauwet chiya', 'Namn', 'Name'),
                    setName
                  )}
                  {field(langShift(language, 'Shan yan Robin?', 'Närmast?', 'Closest to?'), setClosestTo)}
                  {field(langShift(language, 'To ment chende?', 'Ålder', 'Age'), setAge)}
                  {field(langShift(language, 'Berdjewendi?', 'Intressen', 'Interests'), setHobbies)}
                  {field(langShift(language, 'Phiuhndi', 'Hur träffade ni bruden/brudgummen?', 'How did you meet the bride/groom?'), setRelation)}
                  {field(langShift(language, 'Allergiaka', 'Någon specialmat?', 'Any special foods?'), setSpecialFood)}
                  {field(langShift(language, 'Email', 'Email', 'Email'), setEmail)}
                </>
              );
            })()}
            {button(langShift(language, 'Bale', 'OSA', 'Submit!'), async () => {
              let guest = {
                name,
                closestTo,
                myPreferedLanguage: language,
                relation,
                age,
                hobbies: hobbies,
                specialFood: specialFood,
                email: email,
              };
              console.log('submitted', guest);
              await postGuest(guest);
            })}
          </form>
        }
      </div>
    </div>
  );
};

export default GuestForm;
