import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';

/**
 * Given my inexperience with React I did as much as I could by myself. Then I asked ChatGPT
 * to teach me how to fix the things that were not working right. I did not copy paste what
 * ChatGPT showed me rather I typed it myself and asked ChatGPT to teach me the things I did
 * not understand.
 * 
 * Here is the link to ChatGPT that for the conversation I had to learn and figure out how to 
 * complete this assignment. https://chat.openai.com/share/2c0a2312-f431-48ef-8a41-4852ae450a9c
 * @returns
 */
const App = () => {
    const [loginAttempts, setLoginAttempts] = useState([]);

    return (
        <div className="App">
            <LoginForm onSubmit={({ login, password }) => {
                const updatedLoginAttempts = [...loginAttempts, { login, password }];
                setLoginAttempts(updatedLoginAttempts)
                console.log({ login, password });
                console.log("all previous attempts");
                console.log(loginAttempts);
            }} />
            <LoginAttemptList attempts={loginAttempts} />
        </div>
    );
};

export default App;
