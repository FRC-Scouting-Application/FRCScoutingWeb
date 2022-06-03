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