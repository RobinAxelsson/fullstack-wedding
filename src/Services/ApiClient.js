import axios from 'axios';
import { URL } from '../consts/urls';
export async function postGuest({
  name,
  language,
  //relation,
  //age,
  //myPreferedLanguage,
  closestTo,
  //hobbies,
}) {
  console.log('postUrl', URL.postGuest);
  const guest = {
    name: name,
    age: 30,
    myPreferedLanguage: language,
    closestTo: closestTo,
    relation: "Met her on Yaki-da, we are close",
    hobbies: ["sailing", "gym", "makeup"],
  }
  const response = await axios
    .post(URL.postGuest, guest
      
      // name: name,
      // age: age,
      // myPreferedLanguage: myPreferedLanguage,
      // closestTo: closestTo,
      // relation: relation,
      // hobbies: hobbies,
    )
    .catch((err) => {
      console.log(err);
      return;
    });
  console.log('response', response);
}
export async function testBackend() {
  console.log(URL.getTest);
  const response = await axios.get(URL.getTest).catch((err) => {
    console.log(err);
    return;
  });
  console.log('response', response);
}
