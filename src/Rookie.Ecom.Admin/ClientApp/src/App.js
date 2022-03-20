import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';

import CallbackPage from './components/callback/CallbackPage';
import ProfilePage from './components/profile/ProfilePage';

import User from './components/User';

import Category from './components/Category';
import UpdateCategory from './components/UpdateCategory';
import AddCategory from './components/AddCategory';

import Product from './components/Product';
import UpdateProduct from './components/UpdateProduct'
import UpdateProductImage from './components/UpdateProductImage '
import AddProductImage from './components/AddProductImage'
import AddProduct from './components/AddProduct'


export default () => (
    <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/counter" component={Counter} />
        <Route path="/fetch-data/:startDateIndex?" component={FetchData} />

        <Route path="/profile" component={ProfilePage} />
        <Route path="/callback" component={CallbackPage} />

        <Route path="/user/:page?" component={User} />

        <Route path="/category/:page?" component={Category} />
        <Route path="/updatecategory" component={UpdateCategory} />
        <Route path="/addcategory" component={AddCategory} />

        <Route path="/product/:page?" component={Product} />
        <Route path="/updateproduct" component={UpdateProduct} />
        <Route path="/updateproductimage" component={UpdateProductImage} />
        <Route path="/addproduct" component={AddProduct} />
        <Route path="/addproductimage" component={AddProductImage} />

    </Layout>
);
