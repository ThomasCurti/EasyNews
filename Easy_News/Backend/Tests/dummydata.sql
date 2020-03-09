INSERT INTO event_type VALUES (null, "plague");

INSERT INTO article_source VALUES (null, "AFP");

INSERT INTO article (id, title, description, full_article, source_id)
    SELECT null as id,
    	   "Naissance du Coronavirus" as title,
           "Le coronavirus est une maladie qui est apparu en Chine dans la ville de Wuhan." as description,
           "bla bla bla" as full_article,
           id as source_id
    FROM article_source
    WHERE name="AFP";

INSERT INTO event VALUES
(null, 1, 1, "2020-03-02");

