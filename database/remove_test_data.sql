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

/**************************
 * BRISANJE TEST PODATAKA *
 **************************/

DELETE FROM rekordi WHERE ime_korisnika="Test User 1";
DELETE FROM rekordi WHERE ime_korisnika="Test User 2";
DELETE FROM rekordi WHERE ime_korisnika="Test User 3";
