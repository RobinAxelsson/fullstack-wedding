import axios from 'axios';
import { urlPostGuest, urlGetTest } from '../consts/urls';
export async function postGuest(guest) {
  console.log('postUrl', urlPostGuest());
  const response = await axios
    .post(urlPostGuest(), guest)
    .catch((err) => {
      console.log(err);
      return;
    });
  console.log('response', response);
}
export async function testBackend() {
  console.log("URL.getTest", urlGetTest());
  const response = await axios.get(urlGetTest()).catch((err) => {
    console.log(err);
    return;
  });
  console.log('response', response);
}
