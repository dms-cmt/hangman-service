/*
 *
 * Autor: Milos Zivlak (zivlakmilos@gmail.com)
 *
 * Kreiranje tabela za bug-ove
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

/* Kreiranje tabele bugs */
CREATE TABLE IF NOT EXISTS bugs
(
    id int NOT NULL AUTO_INCREMENT,
    opis varchar(255) NULL,
    otkrio_korisnik varchar(50) NULL,
    datum_otkrivanja date NULL,
    popravio_korisnik varchar(50) NULL,
    datum_popravke date NULL,
    bug tinyint(1) NOT NULL DEFAULT 0,
    PRIMARY KEY(id)
) DEFAULT CHARSET=utf8 AUTO_INCREMENT=1;

/*****************************
 * KREIRANJE POMOCNIH TABELA *
 *****************************/

/****************************************
 * SPAJANJE TABELA, KREIRANJE "SPOJEVA" *
 ****************************************/
