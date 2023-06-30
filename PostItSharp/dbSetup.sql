-- Active: 1687896089164@@SG-Sandbox-7678-mysql-master.servers.mongodirector.com@3306@GregsList

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

-- make the table here after you are done with auth and account  ADD

-- CREATE TABLE ablums(

-- id is not null,

-- title catagory coverImg creatroID in sql it should be the same thing as you reference what ever you reference put the same thing you have for it 's REFERENCES

-- to create a relationship we do the following thing

-- FOREING KEY:(creatroID) REFERENCES accounts(id) this is called constrained

-- -- )

-- -- (

--   then start to insert some information in the table. ADD bring the creatorId from account table

--   for deleting the whole album or account we need to put the (ON DELED  CASCADE) with  FOREIGN KEY.

--   to join  2 albums together we say ADD

--    SELECT title , name FROM ALBUM join accounts for being more specific we need to go deep and specify which table to select.;

--    then go make the model

-- )

CREATE TABLE
    recipe (
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        title VARCHAR(255) NOT NULL,
        instructions VARCHAR(1000),
        img VARCHAR(1000) NOT NULL,
        category VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    ingredients (
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(500) NOT NULL,
        quantity VARCHAR(500) NOT NULL,
        recipeId INT NOT NULL,
        FOREIGN KEY (recipeId) REFERENCES recipe(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    favorite (
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        accountId VARCHAR(500) NOT NULL,
        Foreign Key (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
        recipeId INT NOT NULL,
        FOREIGN KEY(recipeId) REFERENCES recipe(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';
