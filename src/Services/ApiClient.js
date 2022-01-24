import axios from 'axios';
import { URL } from '../consts/urls';
export async function postGuest(guest) {
  console.log('postUrl', URL.postGuest);
  const response = await axios
    .post(URL.postGuest, guest)
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
