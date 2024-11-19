-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Nov 19. 13:31
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `computer`
--
CREATE DATABASE IF NOT EXISTS `computer` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `computer`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `comp`
--

CREATE TABLE `comp` (
  `Id` char(36) NOT NULL,
  `Brand` varchar(37) DEFAULT NULL,
  `Type` varchar(30) DEFAULT NULL,
  `Display` double DEFAULT NULL,
  `Memory` int(11) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `OsId` char(36) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `os`
--

CREATE TABLE `os` (
  `Id` char(36) NOT NULL,
  `Name` varchar(27) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- A tábla adatainak kiíratása `os`
--

INSERT INTO `os` (`Id`, `Name`, `CreatedTime`) VALUES
('1c1c752e-be12-4183-b73c-710ff11b0a39', 'Linux', '2024-11-19 12:10:03'),
('38c5c46a-9067-484f-b659-17729df693bf', 'Microsoft Vista Home Basic ', '2024-11-19 12:21:05'),
('4a6fbaa8-3850-4810-829c-a5b39d891e8d', 'Microsoft Vista Business', '2024-11-19 12:08:51'),
('d149d23c-cf95-40fa-845d-5cd1fa5fd984', 'Windows XP Home Magyar', '2024-11-19 13:01:04'),
('d820005e-d6df-4083-8541-8030ff63fa4f', 'Free Dos', '2024-11-19 12:07:46');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `comp`
--
ALTER TABLE `comp`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `OsId` (`OsId`);

--
-- A tábla indexei `os`
--
ALTER TABLE `os`
  ADD PRIMARY KEY (`Id`);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `comp`
--
ALTER TABLE `comp`
  ADD CONSTRAINT `comp_ibfk_1` FOREIGN KEY (`OsId`) REFERENCES `os` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
