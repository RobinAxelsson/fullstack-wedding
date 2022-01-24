import React from 'react';
import button from '../minicomponents/button';
import { testBackend } from '../Services/ApiClient';

const Devbar = () => {
  return <div>{button('Test Backend', async () => await testBackend())}</div>;
};

export default Devbar;
