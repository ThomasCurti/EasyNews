CREATE OR REPLACE DATABASE earlynews_test;

USE earlynews_test;

CREATE OR REPLACE TABLE event_type (
    id   INT      AUTO_INCREMENT PRIMARY KEY,
    name CHAR(32)
);

CREATE OR REPLACE TABLE article_source (
    id   INT      AUTO_INCREMENT PRIMARY KEY,
    name CHAR(16)
);

CREATE OR REPLACE TABLE article (
    id           INT       AUTO_INCREMENT PRIMARY KEY,
    title        CHAR(32),
    description  TEXT,
    full_article LONGTEXT,
    source_id    INT,
    FOREIGN KEY (source_id) REFERENCES article_source (id)
);

CREATE OR REPLACE TABLE event (
    id         INT   AUTO_INCREMENT PRIMARY KEY,
    type_id    INT,
    article_id INT,
    published  DATE,
    FOREIGN KEY (type_id)    REFERENCES event_type (id),
    FOREIGN KEY (article_id) REFERENCES article (id)
);

CREATE OR REPLACE TABLE dubious_article (
    id                  INT                    AUTO_INCREMENT PRIMARY KEY,
    title               CHAR(32),
    source_id           INT,
    full_article_source LONGTEXT,
	 kw_frequency		   TEXT,
    FOREIGN KEY (source_id)       REFERENCES article_source (id)
);

CREATE OR REPLACE TABLE logs (
	id					INT                    AUTO_INCREMENT PRIMARY KEY,
	type				CHAR(32)	NOT NULL,
	class				CHAR(128) NOT NULL,
	message		 	LONGTEXT NULL
);

CREATE OR REPLACE TABLE scenarios (
	id					   INT                    AUTO_INCREMENT PRIMARY KEY,
	illnes_type	    	INT	NOT NULL,
	virus 				CHAR(128) NOT NULL,
	town_id 				INT NOT NULL,
	begin_date		 	CHAR(128) NOT NULL,
	description			LONGTEXT
);