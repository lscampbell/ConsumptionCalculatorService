import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import FetchData from './components/FetchData';
import Counter from './components/Counter';
import RawConsumption from './components/RawConsumption';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/consumption-uploaded' component={ RawConsumption } />
    <Route path='/counter' component={ Counter } />
    <Route path='/fetchdata/:startDateIndex?' component={ FetchData } />
</Layout>;
