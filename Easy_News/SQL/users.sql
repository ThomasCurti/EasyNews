CREATE USER IF NOT EXISTS 'defaultuser'@'localhost' IDENTIFIED BY 'password';

GRANT SELECT, INSERT ON earlynews_test.*
      TO 'defaultuser'@'localhost';
