CREATE TABLE Teams (
	_key VARCHAR(50) PRIMARY KEY,
	team_number INT NOT NULL,
	nickname VARCHAR(255) NULL,
	name VARCHAR(MAX) NOT NULL,
	school_name VARCHAR(MAX) NULL,
	city VARCHAR(255) NULL,
	state_prov VARCHAR(255) NULL,
	country VARCHAR(255) NULL,
	address VARCHAR(MAX) NULL,
	postal_code VARCHAR(50) NULL,
	location_name VARCHAR(MAX) NULL,
	website VARCHAR(MAX) NULL,
	rookie_year INT NULL
);