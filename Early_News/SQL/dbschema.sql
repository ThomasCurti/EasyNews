CREATE OR REPLACE DATABASE earlynews_test;
USE earlynews_test;

CREATE OR REPLACE TABLE event_type (
    id   INT      AUTO_INCREMENT PRIMARY KEY,
    name CHAR(32)
);

CREATE OR REPLACE TABLE article (
    id           INT       AUTO_INCREMENT PRIMARY KEY,
    title        CHAR(32),
    description  TEXT,
    full_article LONGTEXT
);

CREATE OR REPLACE TABLE event (
    id         INT   AUTO_INCREMENT PRIMARY KEY,
    type_id    INT,
    article_id INT,
    published  DATE,
    FOREIGN KEY (type_id)    REFERENCES event_type (id),
    FOREIGN KEY (article_id) REFERENCES article (id)
);
