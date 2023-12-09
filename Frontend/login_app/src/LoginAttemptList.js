import React, { useState } from "react";
import "./LoginAttemptList.css";

/**
 * Used Chat GPT for a few things on this page, however, I used what I learned from ChatGPT
 * here and the other components to do the following things myself
 * I converted LoginAttemptList to be a full component myself instead of directly returning
 * html so that I could use useState React stuff I learned about.
 * I implemented the filter logic myself.
 * I implemented the onChange event myself
 */

/**
 * 
 * @param {any} param0
 * @returns
 */
const LoginAttempt = ({ attempt }) => (
	<li {...attempt}>
		<strong>Login:</strong> {attempt.login}, <strong>Password:</strong> {attempt.password}
	</li>
);

/**
 * 
 * @param {any} param0
 * @returns
 */
const LoginAttemptList = ({ attempts }) => {

	const [data, setData] = useState({
		filter: ""
	});

	const handleFilterUpdate = (event) => {
		setData({ ...data, filter: event.target.value.toLowerCase() })
	};

	return (

		<div className="Attempt-List-Main">
			<p>Recent activity</p>
			<input type="input" placeholder="Filter..." value={data.filter} onChange={handleFilterUpdate} />
			<ul className="Attempt-List">
				{
					attempts
						// search filter by login and password
						.filter(
							(attempt) =>
								attempt.login.toLowerCase().includes(data.filter) ||
								attempt.password.toLowerCase().includes(data.filter))
						// map function
						.map(
							(attempt) => (
								<LoginAttempt attempt={attempt}></LoginAttempt>
							)
					)
				}
			</ul>
		</div>
	)
};

export default LoginAttemptList;