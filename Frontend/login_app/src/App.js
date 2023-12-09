import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';

const App = () => {
    const [loginAttempts, setLoginAttempts] = useState([]);

    return (
        <div className="App">
            <LoginForm onSubmit={({ login, password }) => {
                const updatedLoginAttempts = [...loginAttempts, { login, password }];
                setLoginAttempts(updatedLoginAttempts)
                console.log({ login, password });
                console.log("all attempts");
                console.log(loginAttempts);
            }} />
            <LoginAttemptList attempts={loginAttempts} />
        </div>
    );
};

export default App;
