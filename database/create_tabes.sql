/*
 *
 * Autor: Milos Zivlak (zivlakmilos@gmail.com)
 *
 * Kreiranje tabela za projektni zadatak
 * CMT (Hangman)
 *
 * Database: MySql
 *  host: zivlakmilos.ddns.net
 *  port: 3306 (default port)
 *  username: cmt
 *  password: cmt2#
 *  admin: Milos Zivlak (admin@zivlakmilos.ddns.net)
 *
 * DatabaseName: hangman
 */

/* Koristi hangman bazu podataka */
USE hangman;

/*****************************
 * KREIRANJE OSNOVNIH TABELA *
 *****************************/

/* Kreiranje tabele rekordi */
CREATE TABLE IF NOT EXISTS rekordi
(
    id int NOT NULL AUTO_INCREMENT,
    broj_sekundi bigint NULL,
    ime_korisnika varchar(50) NULL,
    PRIMARY KEY(id)
) DEFAULT CHARSET=utf8 AUTO_INCREMENT=1;

/* Kreiranje tabele nazivi */
CREATE TABLE IF NOT EXISTS nazivi
(
    id int NOT NULL AUTO_INCREMENT,
    naziv varchar(50) NULL,
    PRIMARY KEY(id)
) DEFAULT CHARSET=utf8 AUTO_INCREMENT=1;

/*****************************
 * KREIRANJE POMOCNIH TABELA *
 *****************************/

/****************************************
 * SPAJANJE TABELA, KREIRANJE "SPOJEVA" *
 ****************************************/
