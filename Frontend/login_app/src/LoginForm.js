import React, { useState } from "react";
import './LoginForm.css';

/**
 * I have no experience with react, but from research online this would be a component
 * Although it is not built like the ones I am finding on stackoverflow. I know that I
 * need to create a variables to bind the data too. So for now I will do this like I would
 * in standard JS and see what happens. 
 * 
 * #Update 20231209 I noticed there was an issue with the login form become unusable after the first submittion
 * given my unfamiliarity with React I used ChatGPT to teach me what was wrong with my code.
 */


const LoginForm = (props) => {

	const [loginData, setLoginData] = useState({
		username: "",
		password: ""
	});

	const handleSubmit = (event) =>{
		event.preventDefault();

		props.onSubmit({
			login: loginData.username,
			password: loginData.password
		});
	}

	const handleUsernameUpdate = (event) => {
		setLoginData({ ...loginData, username: event.target.value })
		//loginData.username = event.target.value;
	}
	const handlePasswordUpdate = (event) => {
		setLoginData({ ...loginData, password: event.target.value })
		//loginData.password = event.target.value;
	}

	return (
		<form className="form">
			<h1>Login</h1>
			<label htmlFor="name">Name</label>
			<input type="text" id="name" value={loginData.username} onChange={ handleUsernameUpdate } />
			<label htmlFor="password">Password</label>
			<input type="password" id="password" value={loginData.password} onChange={ handlePasswordUpdate} />
			<button type="submit" onClick={handleSubmit}>Continue</button>
		</form>
	)
}

export default LoginForm;