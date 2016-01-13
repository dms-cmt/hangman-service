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

/***************************
 * KREIRANJE TEST PODATAKA *
 ***************************/

INSERT INTO rekordi (broj_pogresnih_slova, broj_sekundi, ime_korisnika) values (10, 100, "Test User 1");
INSERT INTO rekordi (broj_pogresnih_slova, broj_sekundi, ime_korisnika) values (11, 101, "Test User 2");
INSERT INTO rekordi (broj_pogresnih_slova, broj_sekundi, ime_korisnika) values (12, 102, "Test User 3");
