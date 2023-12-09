import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({ attempt }) => (
	<li {...attempt}>
		<strong>Login:</strong> {attempt.login}, <strong>Password:</strong> {attempt.password}
	</li>
);

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