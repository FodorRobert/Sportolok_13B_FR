-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Sep 23, 2026 at 06:37 AM
-- Server version: 8.4.7
-- PHP Version: 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sportolok13b`
--
CREATE DATABASE IF NOT EXISTS `sportolok13b` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `sportolok13b`;

-- --------------------------------------------------------

--
-- Table structure for table `eredmeny`
--

DROP TABLE IF EXISTS `eredmeny`;
CREATE TABLE IF NOT EXISTS `eredmeny` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Competition` varchar(40) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Description` text COLLATE utf8mb4_unicode_ci,
  `ResultTime` datetime DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  `SportoloId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `SportoloId` (`SportoloId`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `eredmeny`
--

INSERT INTO `eredmeny` (`Id`, `Competition`, `Description`, `ResultTime`, `UpdateTime`, `SportoloId`) VALUES
(1, 'Budapest Maraton', '2:58:12-es idővel 14. hely az abszolút mezőnyben.', '2025-05-04 12:30:00', '2025-05-04 12:30:00', 1),
(2, 'Megyei bajnokság', 'Aranyérem 100 m gátfutásban, 13.42 mp.', '2025-05-18 15:00:00', '2025-05-18 15:00:00', 2),
(3, 'Országos diákolimpia', 'Ezüstérem magasugrásban, 178 cm.', '2025-06-01 10:15:00', '2025-06-01 10:15:00', 3),
(4, 'Úszó verseny', '100 m gyors, 2. hely, 58.3 mp.', '2025-06-10 09:00:00', '2025-06-10 09:00:00', 5),
(5, 'Atlétikai kupa', 'Súlylökés, 3. hely, 11.8 m.', '2025-06-22 14:20:00', '2025-06-22 14:20:00', 6);

-- --------------------------------------------------------

--
-- Table structure for table `sportolo`
--

DROP TABLE IF EXISTS `sportolo`;
CREATE TABLE IF NOT EXISTS `sportolo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `age` int NOT NULL,
  `password` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `registrationTime` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `sportolo`
--

INSERT INTO `sportolo` (`id`, `name`, `email`, `age`, `password`, `registrationTime`) VALUES
(1, 'Kovács Bence', 'kovacs.bence@example.com', 21, 'jelszo123', '2025-01-12 09:15:00'),
(2, 'Nagy Petra', 'nagy.petra@example.com', 19, 'titkosjelszo', '2025-02-03 14:30:00'),
(3, 'Szabó Márk', 'szabo.mark@example.com', 24, 'sport2025', '2025-02-20 08:00:00'),
(4, 'Tóth Zsófia', 'toth.zsofia@example.com', 22, 'futas!42', '2025-03-15 17:45:00'),
(5, 'Horváth Dávid', 'horvath.david@example.com', 20, 'uszas99', '2025-04-01 11:20:00'),
(6, 'Varga Lili', 'varga.lili@example.com', 23, 'atletika7', '2025-04-18 16:05:00');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
