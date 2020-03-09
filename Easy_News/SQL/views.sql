USE earlynews_test;

CREATE VIEW pretty_list AS
  SELECT a.title as titre, t.name as type
  FROM event e
  JOIN event_type t ON e.type_id = t.id
  JOIN article a ON e.article_id = a.id;
