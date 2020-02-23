MariaDB
-------
Install WSL (Unbuntu LTS 18):
--

https://docs.microsoft.com/en-us/windows/wsl/install-win10

Run thoses commands:
--

sudo apt-get install software-properties-common
 
sudo apt-key adv --recv-keys --keyserver hkp://keyserver.ubuntu.com:80 0xF1656F24C74CD1D8
 
sudo add-apt-repository 'deb [arch=amd64,arm64,ppc64el] http://mariadb.nethub.com.hk/repo/10.1/ubuntu bionic main'

sudo apt update

sudo apt install mariadb-server

sudo service mysql start

If this works
--
sudo service mysql status 
mysql
mysql> SHOW GLOBAL VARIABLES LIKE 'PORT';

Configure MariaDB
--
Install HeidiSQL on your windows

Try to connect on your server (localhost, port)

if it doesn't work, go back on your ubuntu and type:
mysql
mysql> GRANT ALL PRIVILEGES on *.* to 'root'@'localhost' IDENTIFIED BY '<password>';
mysql> FLUSH PRIVILEGES;

sudo service mysql restart

mysql -u root -p 
then type your <password>

If it worked, type your password in HeidiSQL