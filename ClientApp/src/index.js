import React, { Suspense } from 'react';
import ReactDOM, { createRoot } from 'react-dom/client';
import App from './App';
import store from './store/store';
import { Provider} from 'react-redux';
import { BrowserRouter } from 'react-router-dom';

const root = document.getElementById('root');

const rootInstance = createRoot(root);
rootInstance.render(
  <Provider store={store}>
    <Suspense>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Suspense>
  </Provider>
)
