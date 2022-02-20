//const apiBase = process.env.REACT_APP_SERVER_URL === undefined? '' : process.env.REACT_APP_SERVER_URL;
const baseUrl = () => window.location.origin + '/';
export const urlPostGuest = () => baseUrl() + 'api/guest';
export const urlGetTest = () => baseUrl() + 'api/test';
// export const URL = {
//     postGuest: apiBase + 'api/guest',
//     getTest: apiBase + 'api/test'
// }