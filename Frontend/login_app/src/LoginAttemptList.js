import React from "react";
import "./LoginAttemptList.css";

const LoginAttempt = ({ attempt }) => (
	<li {...attempt}>
		<strong>Login:</strong> {attempt.login}, <strong>Password:</strong> {attempt.password}
	</li>
);

const LoginAttemptList = ({ attempts }) => (
	<div className="Attempt-List-Main">
	 	<p>Recent activity</p>
	  	<input type="input" placeholder="Filter..." />
		<ul className="Attempt-List">
			{attempts.map((attempt) => (
				<LoginAttempt attempt={attempt}></LoginAttempt>
			))}
		</ul>
	</div>
);

export default LoginAttemptList;