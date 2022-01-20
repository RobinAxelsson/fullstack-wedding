import { useState, useEffect } from 'react';
import { namePlaceHolder, relationPlaceHolder } from '../Services/Translator'

const GuestForm = (LANG) => {

  const [showForm, setShowForm] = useState(true);


  return (
    <div className="">
      <div className="flex justify-center items-center">
        {showForm && (
          <form
            className="w-11/12 tablet:w-6/12 laptop:w-4/12 rounded-md border-white border-8 border-opacity-5 bg-white bg-opacity-75 mt-6 flex-col flex justify-center items-center"
          >
            <div className="w-full border-white border-8 border-opacity-5 flex justify-center items-center">
              <h2 className="font-bold text-4xl"></h2>
            </div>
            <div className="mt-4 w-11/12">
              <input
                maxlength="30"
                type="text"
                className="w-full shadow-sm focus:ring-indigo-500 focus:border-indigo-500 block sm:text-sm border-gray-300 rounded-md"
                placeholder={namePlaceHolder(LANG)}
                required
              />
            </div>
            <div className="mt-1 w-11/12">
              <input
                maxlength="30"
                type="text"
                className="w-full shadow-sm focus:ring-indigo-500 focus:border-indigo-500 block sm:text-sm border-gray-300 rounded-md"
                placeholder={relationPlaceHolder(LANG)}
                required
                //onChange={(e) => {setEnd(e.target.value); filterEndStation(e)}}
              />
            </div>
            {/* {endStationFilter.length !== 0 &&
          <div className="bg-white w-11/12 border-white border-8 border-opacity-5">
          <ul>
            {endStationFilter && endStationFilter
             .map((item) =>
              <li className="cursor-pointer" onClick={() => {setEnd(item.name); setEndStationFilter([])}} key={item.id}>{item.name}</li>
            )}
          </ul>
          </div>
          } */}
            <button className="mt-1 inline-flex items-center px-4 py-2 border border-transparent text-sm font-medium rounded-md text-indigo-700 bg-indigo-100 hover:bg-indigo-200 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500">
              
            </button>
          </form>
        )}
      </div>
    </div>
  );
};

export default GuestForm;
