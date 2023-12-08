import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';

const App = () => {
    /**
     * Here I am not sure what to do with setLoginAttempts yet. 
     * However I am going to use loginAttempts as a list
     */
    const [loginAttempts, setLoginAttempts] = useState([]);

  return (
    <div className="App">
          <LoginForm onSubmit={({ login, password }) => {
              loginAttempts.push({
                  login, password
              });
              console.log({ login, password })
          }} />
      <LoginAttemptList attempts={loginAttempts} />
    </div>
  );
};

export default App;
