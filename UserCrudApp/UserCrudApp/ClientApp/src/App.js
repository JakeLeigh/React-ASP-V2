import React, { Component, Fragment } from 'react';
import AppHeader from './components/AppHeader';
import Home from './components/Home';
import AppFooter from './components/AppFooter';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Fragment>
      <AppHeader />
      <Home />
      <AppFooter />
    </Fragment>
    );
  }
}
