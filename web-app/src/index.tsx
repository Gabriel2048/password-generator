import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './app';

const rootElement = document.getElementById('root') as HTMLElement;
const appRoot = ReactDOM.createRoot(rootElement);

appRoot.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);