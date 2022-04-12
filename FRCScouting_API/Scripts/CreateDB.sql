/* Create Scouting Database */

USE [scouting-frc2386];


/* Drop Existing Tables */
PRINT 'Dropping Existing Tables';
PRINT '';
DROP TABLE IF EXISTS Note;
DROP TABLE IF EXISTS Scout;
DROP TABLE IF EXISTS Template;
DROP TABLE IF EXISTS Match;
DROP TABLE IF EXISTS Team;
DROP TABLE IF EXISTS Event;
GO

PRINT 'Create Event Table';
CREATE TABLE Event (
	_key VARCHAR(50) PRIMARY KEY,
	name VARCHAR(255) NOT NULL,
	short_name VARCHAR(255) NULL,
	city VARCHAR(255) NULL,
	state_prov VARCHAR(255) NULL,
	country VARCHAR(255) NULL,
	address VARCHAR(MAX) NULL,
	postal_code VARCHAR(50) NULL,
	location_name VARCHAR(MAX) NULL,
	website VARCHAR(MAX) NULL,
	start_date DATE NOT NULL,
	end_date DATE NOT NULL,
	year INT NOT NULL,
	event_type VARCHAR(50) NOT NULL,
	week INT NULL
);
GO

PRINT 'Create Team Table';
CREATE TABLE Team (
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
GO

PRINT 'Create Match Table';
CREATE TABLE Match (
	_key VARCHAR(50) PRIMARY KEY,
	red_1 VARCHAR(50) NULL FOREIGN KEY REFERENCES Team(_key),
	red_2 VARCHAR(50) NULL FOREIGN KEY REFERENCES Team(_key),
	red_3 VARCHAR(50) NULL FOREIGN KEY REFERENCES Team(_key),
	blue_1 VARCHAR(50) NULL FOREIGN KEY REFERENCES Team(_key),
	blue_2 VARCHAR(50) NULL FOREIGN KEY REFERENCES Team(_key),
	blue_3 VARCHAR(50) NULL FOREIGN KEY REFERENCES Team(_key),
	event_key VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Event(_key),
	red_score INT NULL,
	blue_score INT NULL,
	winning_alliance VARCHAR(10) NULL,
	time DATETIME NULL,
	actual_time DATETIME NULL,
	predicted_time DATETIME NULL
);
GO

PRINT 'Create Template Table';
CREATE TABLE Template (
	_id INT IDENTITY(0,1),
	_version INT NOT NULL DEFAULT 0,
	type VARCHAR(10) NOT NULL,
	name VARCHAR(255) NOT NULL,
	default_template BIT NULL DEFAULT 0,
	created DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
	xml XML NOT NULL,
	PRIMARY KEY (_id, _version)
);
GO

PRINT 'Create Scout Table';
CREATE TABLE Scout (
	_id INT IDENTITY(0,1),
	team_key VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Team(_key),
	event_key VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Event(_key),
	template_id INT NOT NULL,
	template_version INT NOT NULL,
	match_key VARCHAR(50) NULL FOREIGN KEY REFERENCES Match(_key),
	scout_name VARCHAR(255) NOT NULL,
	xml XML NOT NULL,
	FOREIGN KEY(template_id, template_version) REFERENCES Template(_id, _version)
);
GO

PRINT 'Create Note Table';
CREATE TABLE Note (
	_id INT IDENTITY(0,1) PRIMARY KEY,
	team_key VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Team(_key),
	event_key VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Event(_key),
	scout_name VARCHAR(255) NOT NULL,
	text VARCHAR(MAX) NOT NULL
);
GO

PRINT '';
PRINT 'DONE!';
GO