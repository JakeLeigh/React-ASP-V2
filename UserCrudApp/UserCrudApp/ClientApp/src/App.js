import React, { Component, Fragment } from 'react';
import AppHeader from './components/AppHeader';
import AppFooter from './components/AppFooter';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Fragment>
      <AppHeader />
      <AppFooter />
    </Fragment>
    );
  }
}
