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
    other_source_id     INT NULL,
    full_article_other  LONGTEXT NULL,
    seen_twice          BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (source_id)       REFERENCES article_source (id),
    FOREIGN KEY (other_source_id) REFERENCES article_source (id)
)
