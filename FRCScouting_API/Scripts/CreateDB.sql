/* Create Scouting Database */

USE [scouting-frc2386];


/* Drop Existing Tables */
PRINT 'Dropping Existing Tables';
PRINT '';
DROP TABLE IF EXISTS Notes;
DROP TABLE IF EXISTS Scouts;
DROP TABLE IF EXISTS Templates;
DROP TABLE IF EXISTS Matches;
DROP TABLE IF EXISTS Teams;
DROP TABLE IF EXISTS Events;
GO

PRINT 'Create Events Table';
CREATE TABLE Events (
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

PRINT 'Create Teams Table';
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
GO

PRINT 'Create Matches Table';
CREATE TABLE Matches (
	_key VARCHAR(50) PRIMARY KEY,
	match_number INT NOT NULL,
	red_1 VARCHAR(50) NULL FOREIGN KEY REFERENCES Teams(_key),
	red_2 VARCHAR(50) NULL FOREIGN KEY REFERENCES Teams(_key),
	red_3 VARCHAR(50) NULL FOREIGN KEY REFERENCES Teams(_key),
	blue_1 VARCHAR(50) NULL FOREIGN KEY REFERENCES Teams(_key),
	blue_2 VARCHAR(50) NULL FOREIGN KEY REFERENCES Teams(_key),
	blue_3 VARCHAR(50) NULL FOREIGN KEY REFERENCES Teams(_key),
	event_key VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Events(_key),
	red_score INT NULL,
	blue_score INT NULL,
	winning_alliance VARCHAR(10) NULL,
	time DATETIME NULL,
	actual_time DATETIME NULL,
	predicted_time DATETIME NULL
);
GO

PRINT 'Create Templates Table';
CREATE TABLE Templates (
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

PRINT 'Create Scouts Table';
CREATE TABLE Scouts (
	_id INT IDENTITY(0,1),
	team_key VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Teams(_key),
	event_key VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Events(_key),
	template_id INT NOT NULL,
	template_version INT NOT NULL,
	match_key VARCHAR(50) NULL FOREIGN KEY REFERENCES Matches(_key),
	scout_name VARCHAR(255) NOT NULL,
	xml XML NOT NULL,
	FOREIGN KEY(template_id, template_version) REFERENCES Templates(_id, _version)
);
GO

PRINT 'Create Notes Table';
CREATE TABLE Notes (
	_id INT IDENTITY(0,1) PRIMARY KEY,
	team_key VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Teams(_key),
	event_key VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Events(_key),
	scout_name VARCHAR(255) NOT NULL,
	text VARCHAR(MAX) NOT NULL
);
GO

PRINT '';
PRINT 'DONE!';
GO