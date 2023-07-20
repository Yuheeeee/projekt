-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Máj 26. 17:31
-- Kiszolgáló verziója: 10.4.27-MariaDB
-- PHP verzió: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `vizsga`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `arkategoria`
--

CREATE TABLE `arkategoria` (
  `kaucio` int(11) DEFAULT NULL,
  `ar` int(11) DEFAULT NULL,
  `kategoria` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `arkategoria`
--

INSERT INTO `arkategoria` (`kaucio`, `ar`, `kategoria`) VALUES
(100000, 5000, 'A'),
(125000, 6500, 'B'),
(150000, 8000, 'C'),
(200000, 12500, 'D');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `auto`
--

CREATE TABLE `auto` (
  `azo` int(11) NOT NULL,
  `marka` text DEFAULT NULL,
  `tipus` text DEFAULT NULL,
  `evjarat` int(11) DEFAULT NULL,
  `ulesszam` int(11) DEFAULT NULL,
  `valto` text DEFAULT NULL,
  `uzemanyag` text DEFAULT NULL,
  `kolcsonozve` date DEFAULT NULL,
  `rendszam` text DEFAULT NULL,
  `arkategoria` text DEFAULT NULL,
  `csomagtarto` int(11) DEFAULT NULL,
  `gps` text NOT NULL DEFAULT '\'\\\'0\\\'\'',
  `ajtoszam` int(11) NOT NULL,
  `url` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `auto`
--

INSERT INTO `auto` (`azo`, `marka`, `tipus`, `evjarat`, `ulesszam`, `valto`, `uzemanyag`, `kolcsonozve`, `rendszam`, `arkategoria`, `csomagtarto`, `gps`, `ajtoszam`, `url`) VALUES
(1, 'Suzuki', 'Swift', 2022, 5, 'Manuális', 'Benzin', NULL, 'TDF321', 'A', 246, 'Nem', 5, 'https://e0.pxfuel.com/wallpapers/25/432/desktop-wallpaper-suzuki-swift.jpg'),
(2, 'Toyota', 'Yarris', 2022, 5, 'Manuális', 'Elektromos', NULL, 'TAD554', 'A', 286, 'Nem', 5, 'https://i1.wp.com/naccar.com.br/wp-content/uploads/2020/10/Toyota-Yaris-2021-ganha-serie-especial-S-abre.jpg?fit=1920%2C1080&ssl=1'),
(3, 'Volkswagen', 'Polo', 2021, 5, 'Manuális', 'Elektromos', NULL, 'TVF487', 'A', 351, 'Igen', 5, 'https://e0.pxfuel.com/wallpapers/876/352/desktop-wallpaper-volkswagen-polo-vw-polo.jpg'),
(4, 'Opel', 'Corsa', 2020, 5, 'Manuális', 'Benzin', NULL, 'ZAS154', 'A', 309, 'Nem', 5, 'https://e0.pxfuel.com/wallpapers/156/645/desktop-wallpaper-opel-cars-side-view-corsa.jpg'),
(5, 'Hyuandai', 'i10', 2021, 5, 'Manuális', 'Benzin', NULL, 'TCF395', 'A', 256, 'Nem', 5, 'https://e1.pxfuel.com/desktop-wallpaper/837/329/desktop-wallpaper-2020-hyundai-i10-revealed-with-upscale-motor1-hyundai-i10.jpg'),
(6, 'Ford', 'Mondeo', 2022, 5, 'Manuális', 'Benzin', NULL, 'VAO254', 'B', 550, 'Igen', 5, 'https://e1.pxfuel.com/desktop-wallpaper/710/156/desktop-wallpaper-2015-ford-mondeo-new-concept-ford-mondeo.jpg'),
(7, 'Audi', 'A6', 2020, 5, 'Automata', 'Dízel', NULL, 'VFG259', 'B', 530, 'Igen', 4, 'https://e1.pxfuel.com/desktop-wallpaper/297/907/desktop-wallpaper-2017-audi-a6-avant-euro-audi-a6.jpg'),
(8, 'Volvo', 'S90', 2022, 5, 'Automata', 'Elektromos', NULL, 'VXC657', 'B', 500, 'Igen', 4, 'https://e1.pxfuel.com/desktop-wallpaper/919/380/desktop-wallpaper-volvo-s90-2017-exotic-car-of-104-diesel-station-volvo-s90.jpg'),
(9, 'Skoda', 'Superb', 2021, 5, 'Manuális', 'Dízel', NULL, 'TKL891', 'B', 660, 'Igen', 5, 'https://e1.pxfuel.com/desktop-wallpaper/665/598/desktop-wallpaper-skoda-superb-sportline-2015-1920%D1%851080-skoda-superb.jpg'),
(10, 'Volkswagen', 'Passat', 2022, 5, 'Automata', 'Dízel', NULL, 'VJH141', 'B', 650, 'Igen', 5, 'https://e0.pxfuel.com/wallpapers/804/497/desktop-wallpaper-volkswagen-passat.jpg'),
(11, 'Renault', 'Grand Scenic', 2020, 7, 'Manuális', 'Dízel', NULL, 'UHG554', 'C', 233, 'Nem', 5, 'https://autopult.hu/galeria/1703teszt/scenic/renault_grand_scenic_2018_14_medium.JPG'),
(12, 'Mercedes', 'Vito', 2020, 9, 'Manuális', 'Dízel', NULL, 'UDF256', 'C', 990, 'Igen', 5, 'https://carsguide-res.cloudinary.com/image/upload/f_auto,fl_lossy,q_auto,t_cg_hero_large/v1/editorial/segment_review/hero_image/2021-Mercedes-benz-Vito-black-van-mark-oastler-1001x565-%281%29.jpg'),
(13, 'Volkswagen', 'Transporter', 2020, 9, 'Manuális', 'Dízel', NULL, 'UHG554', 'C', 845, 'Nem', 4, 'https://editorial.pxcrush.net/carsales/general/editorial/volkswagen_t61_transporter-013-gsz8.jpg?width=1024&height=682'),
(14, 'Ford', 'S-MAX', 2020, 7, 'Automata', 'Benzin', NULL, 'VGF356', 'C', 293, 'Nem', 5, 'https://www.ford.de/content/dam/guxeu/rhd/central/cars/new-s-max/gallery/videos/Ford-SMAX-eu-vlcsnap-RHD-2020-02-05-14h49m46s911-16x9-2160x1215.jpg.renditions.original.png'),
(15, 'Citroen', 'Grand Picasso', 2019, 7, 'Manuális', 'Benzin', NULL, 'UGZ168', 'C', 295, 'Nem', 5, 'https://kocsi-media.hu/549266/citroen-c4-picasso-1-6-bluehdi-collection-ss-grand-976580_366536_10xl.jpg'),
(16, 'Aston Martin', 'Vintage', 2020, 2, 'Automata', 'Benzin', NULL, 'VAD324', 'D', 350, 'Igen', 2, 'https://www.motortrend.com/uploads/sites/11/2019/10/2020-Aston-Martin-Vantage-AMR-Manual-81.jpg'),
(17, 'Bentley', 'Bentayga', 2020, 5, 'Automata', 'Benzin', NULL, 'VKH763', 'D', 451, 'Igen', 5, 'https://www.completecar.ie/img/testdrives/10307_large.jpg'),
(18, 'BMW', '750i', 2022, 5, 'Automata', 'Benzin', NULL, 'VGT418', 'D', 515, 'Igen', 4, 'https://mediacloud.carbuyer.co.uk/image/private/s--X-WVjvBW--/f_auto,t_content-image-full-desktop@1/v1650452556/carbuyer/2022/04/BMW%207%20Series%20and%20i7-6.jpg'),
(19, 'Ford', 'Mustang Shelby GT500', 2022, 4, 'Manuális', 'Benzin', NULL, 'VSR491', 'D', 342, 'Igen', 2, 'https://img.philkotse.com/2021/09/10/WFFKkBCT/shelby-gt500-3-fb23_wm.jpg'),
(20, 'Jaguar', 'F-Type P450', 2021, 2, 'Automata', 'Dízel', NULL, 'VRE254', 'D', 205, 'Igen', 2, 'https://www.nationwide-cars.co.uk/media/range/Jaguar_F-Type_2021.jpg');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `nyilvantartas`
--

CREATE TABLE `nyilvantartas` (
  `autoazo` int(11) DEFAULT NULL,
  `ugyfelazo` int(11) DEFAULT NULL,
  `berlesazo` text DEFAULT NULL,
  `kezdonap` date DEFAULT NULL,
  `zaronap` date DEFAULT NULL,
  `berletidij` int(20) DEFAULT NULL,
  `osszeg` int(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `nyilvantartas`
--

INSERT INTO `nyilvantartas` (`autoazo`, `ugyfelazo`, `berlesazo`, `kezdonap`, `zaronap`, `berletidij`, `osszeg`) VALUES
(16, 91, 'GD8BK2NA', '2023-05-23', '2023-05-23', 12500, 212500),
(16, 91, 'ZAMHG3W5', '2023-05-24', '2023-06-22', 375000, 575000),
(17, 91, '7UQEER9G', '2023-05-23', '2023-05-23', 12500, 212500),
(17, 91, 'ENZE27K4', '2023-05-25', '2023-05-25', 12500, 212500),
(17, 91, 'SNQJW3BH', '2023-06-22', '2023-06-22', 12500, 212500),
(17, 91, '4G1B7J2E', '2023-06-21', '2023-06-21', 12500, 212500),
(17, 91, 'SG1LVTT4', '2023-06-19', '2023-06-20', 25000, 225000),
(17, 91, 'R7LEN77V', '2023-06-15', '2023-06-15', 12500, 212500),
(17, 91, 'FZTTIIZ7', '2023-06-11', '2023-06-12', 25000, 225000),
(19, 91, 'FNCVJJSH', '2023-05-23', '2023-05-23', 12500, 212500),
(1, 91, 'K28HUTS4', '2023-05-23', '2023-05-23', 5000, 105000),
(1, 91, '420NOKAG', '2023-05-25', '2023-06-02', 45000, 145000),
(1, 91, 'DPVDNJWN', '2023-06-04', '2023-06-04', 5000, 105000),
(1, 91, 'XTGL0J7F', '2023-06-06', '2023-06-06', 5000, 105000),
(1, 91, 'FSG5QD28', '2023-06-07', '2023-06-07', 5000, 105000),
(1, 91, 'X0PDSMH9', '2023-06-09', '2023-06-09', 5000, 105000),
(7, 91, 'MVOEQAOY', '2023-06-02', '2023-06-03', 13000, 138000),
(2, 91, 'WWG7PGML', '2023-05-26', '2023-06-02', 40000, 140000),
(2, 91, 'IG2I2V9Y', '2023-06-08', '2023-06-08', 5000, 105000),
(17, 91, 'CBZY26P7', '2023-06-16', '2023-06-17', 25000, 225000),
(1, 91, '7OIVN2GA', '2023-06-14', '2023-06-16', 15000, 115000),
(1, 91, '4ARFPEKZ', '2023-06-12', '2023-06-13', 10000, 110000),
(1, 91, '8CBI5SA3', '2023-06-19', '2023-06-21', 15000, 115000),
(16, 91, 'FU3DS3RL', '2023-06-23', '2023-06-23', 12500, 212500),
(17, 91, 'PUPPPFMS', '2023-05-28', '2023-06-02', 75000, 275000),
(17, 91, '13S8ZSVO', '2023-06-04', '2023-06-05', 25000, 225000),
(17, 91, '34H45MJB', '2023-06-03', '2023-06-03', 12500, 212500),
(12, 91, 'IZQG4CM2', '2023-05-25', '2023-05-26', 16000, 166000),
(16, 91, 'J83EZRBH', '2023-06-24', '2023-06-24', 12500, 212500),
(12, 91, 'XA5WFBSW', '2023-05-31', '2023-06-02', 24000, 174000),
(8, 91, 'SBYQ4LP9', '2023-05-26', '2023-05-26', 6500, 131500),
(1, 91, 'FHP7MUDA', '2023-06-22', '2023-06-23', 10000, 110000),
(4, 91, 'OABKCLOB', '2023-06-08', '2023-06-12', 25000, 125000),
(17, 91, '55CRK80P', '2023-05-27', '2023-05-27', 12500, 212500),
(6, 91, 'EMWOLDSF', '2023-05-26', '2023-05-31', 39000, 164000),
(11, 91, 'IHMPJXXO', '2023-05-31', '2023-06-24', 200000, 350000),
(13, 91, 'H1V0JV7H', '2023-05-30', '2023-05-31', 16000, 166000),
(14, 91, 'XBBQR5VO', '2023-05-31', '2023-05-31', 8000, 158000),
(19, 91, 'KVXH58RF', '2023-05-25', '2023-05-26', 12500, 212500),
(19, 91, 'Y2R2VOFG', '2023-05-27', '2023-05-31', 0, 200000),
(1, 91, '51166225', '2023-06-17', '2023-06-18', 5000, 10000),
(19, 6, '37148750', '2023-05-28', '2023-05-31', 50000, 250000),
(20, 97, 'EPTWPF4J', '2023-05-28', '2023-05-31', 50000, 250000),
(4, 7, '64306721', '2023-05-25', '2023-05-27', 15000, 115000),
(5, 4, '71626800', '2023-05-25', '2023-05-28', 20000, 120000),
(12, 7, '24038624', '2023-05-27', '2023-06-10', 120000, 270000),
(6, 5, '68185700', '2023-05-27', '2023-06-01', 39000, 164000),
(2, 91, '5XZEBJHG', '2023-06-04', '2023-06-06', 15000, 115000),
(1, 91, '1684121594689', '0000-00-00', '0000-00-00', NULL, NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ugyfel`
--

CREATE TABLE `ugyfel` (
  `ugyfelazo` int(11) NOT NULL,
  `nev` varchar(30) NOT NULL,
  `nem` varchar(5) NOT NULL,
  `iranyitoszam` int(10) NOT NULL,
  `orszag` varchar(50) NOT NULL,
  `telepules` varchar(40) NOT NULL,
  `cim` varchar(100) NOT NULL,
  `email` char(50) NOT NULL,
  `telefon` varchar(20) NOT NULL,
  `jelszo` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ugyfel`
--

INSERT INTO `ugyfel` (`ugyfelazo`, `nev`, `nem`, `iranyitoszam`, `orszag`, `telepules`, `cim`, `email`, `telefon`, `jelszo`) VALUES
(1, 'Martin Admin', '', 0, '', '', '', 'martin@mukebu.hu', '', 'Martin'),
(2, 'Gábor Admin', '', 0, '', '', '', 'gabor@mukebu.hu', '', 'Gabor'),
(3, 'Murzsicz Martin', '', 5600, '', 'Békéscsaba', 'Trefort 41.', 'murzsicz.martin@gmail.com', '43242344', '123'),
(4, 'Murzsicz Martin', '', 5600, '', 'Békéscsaba', 'Trefort 41.', 'murzsicz.martin@gmail.com', '43242344', '123'),
(5, 'Murzsicz Martin', '', 5600, '', 'Békéscsaba', 'Trefort 41.', 'murzsicz.martin@gmail.com', '43242344', '123'),
(6, 'fefesf', '', 43432, '', 'fefesf', 'fesfes', 'fesfe@sff.com', '343242', 'efesfe'),
(7, 'dedaedea', '', 0, '', '', '', 'murzsicz.martn@gmail.com', '524326', 'dedad'),
(8, 'rewff', '', 0, '', 'fefe', '', 'murzsicz.martin2@gmail.com', '', '3434'),
(9, '31232131', '', 3, '', '', '', '3432@gmail.com', '', '321'),
(10, '31221', '', 0, '', '', '', '3432w@gmail.com', '', '2132'),
(11, '31221', '', 0, '', '', '', '34322w@gmail.com', '', '2132'),
(12, '31221', '', 0, '', '', '', '3432212w@gmail.com', '', '2132'),
(13, '312321', '', 0, '', '', '', '121221@gmail.com', '', '2132'),
(14, '312321', '', 0, '', '', '', '12122221@gmail.com', '', '2132'),
(15, '312321', '', 0, '', '', '', '121222211@gmail.com', '', '2132'),
(16, '3213', '', 0, '', '', '', '3231231@gmail.com', '', '23132'),
(17, '231312', '', 22, '', '', '', '23232@fe34.com', '', '2122'),
(18, '231312', '', 22, '', '', '', '232132@fe34.com', '', '2122'),
(19, '123', '', 0, '', '', '', 'murzsicz.martin3@gmail.com', '', '123'),
(20, '123', '', 0, '', '', '', 'murzsicz.martin4@gmail.com', '', '123'),
(21, '123', '', 0, '', '', '', 'murzsicz.martin5@gmail.com', '', '123'),
(22, '123', '', 0, '', '', '', 'murzsicz.martin7@gmail.com', '', '123'),
(23, '123', '', 0, '', '', '', 'murzsicz.martin7@gmail.com', '', '123'),
(24, '123', '', 0, '', '', '', 'vmurzsicz.martin7@gmail.com', '', '123'),
(25, '123', '', 0, '', '', '', 'murzsicz.martin8@gmail.com', '', '123'),
(26, '123', '', 0, '', '', '', 'mu@mu.hu', '', '123'),
(27, '123', '', 0, '', '', '', 'murzsicz.martin9@gmail.com', '', '123'),
(28, '123346', '', 3213, '', '321', '231312', 'murzsicz.mar2tin@gmail.com', '132321', '12345'),
(29, '123346', '', 3213, '', '321', '231312', 'murzsicz.mar2tin@gmail.com', '132321', '12345'),
(30, '123346', '', 3213, '', '321', '231312', 'murzsicz.mar2tin@gmail.com', '132321', '12345'),
(31, '123346', '', 3213, '', '321', '231312', 'murzsicz.mar2tin@gmail.com', '132321', '12345'),
(32, '123346', '', 3213, '', '321', '231312', 'murzsicz.mar2tin@gmail.com', '132321', '12345'),
(33, '123346', '', 3213, '', '321', '231312', 'murzsicz.mar2tin@gmail.com', '132321', '12345'),
(34, '123346', '', 3213, '', '321', '231312', 'murzsicz.mar2tin@gmail.com', '132321', '12345'),
(35, '123346', '', 3213, '', '321', '231312', 'murzsicz.mar2tin@gmail.com', '132321', '12345'),
(36, '123346', '', 3213, '', '321', '231312', 'murzsicz.mar2tin@gmail.com', '132321', '12345'),
(37, '123', '', 0, '', '', '', 'murzsicz.mar22tin@gmail.com', '', '123'),
(38, '32312', '', 0, '', '', '', 'dwada@gmail.com', '', '1996'),
(39, '123', '', 123, '', '123', '123', 'murzsicz.martin2223@gmail.com', '123', '19960902'),
(40, 'fenfksln', '', 1234, '', 'deaf', '213', 'murzsffno.martin@gmail.com', '213', '12345670'),
(41, 'fenfksln', '', 1234, '', 'deaf', '213', 'murzsffno.mar22tin@gmail.com', '213', '12345670'),
(42, 'vdvd', '', 0, '', 'dvdv', '', 'grgnjr@gmail.com', '', '12345678'),
(43, '123', '', 0, '', '', '', 'murzsicz.1martin@gmail.com', '', '12345678'),
(44, 'refwf', '', 0, '', '', '', 'fdsjghrg@gmail.com', '', '12345678'),
(45, 'defa', '', 0, '', '', '', 'grs@frfs', '', '12345678'),
(46, 'dedqfd', '', 0, '', '', '', 'frsgsr@grgg', '', '00000000'),
(47, 'cdcdcd', '', 0, '', '', '', 'ffefs@efefa', '', '00000000'),
(48, '0000', '', 0, '', '', '', 'fefef@de', '', '00000000'),
(49, 'cdvsv', '', 0, '', '', '', 'few@dddd', '', '111111111'),
(50, 'fefea', '', 0, '', '', '', 'mur1zsicz.martin@gmail.com', '', '12345678'),
(51, 'efe', '', 0, '', '', '', 'feafae@gmail.com', '', '12345678'),
(52, '123', '', 0, '', '', '', 'efe@feff.com', '', '11111111'),
(53, 'fe', '', 0, '', '', '', 'fe@fe', '', '11111111'),
(54, 'tdhddt', '', 0, '', '', '', 'mur12zsicz.martin@gmail.com', '', '00000000'),
(55, 'vrdgr', '', 0, '', '', '', 'murz111sicz.martin@gmail.com', '', '00000000'),
(56, 'rdgrg', '', 0, '', '', '', '4352@5.hu', '', '00000000'),
(57, 'bvrfgrs', '', 0, '', '', '', 'fefe@fesfse', '', '0000000000'),
(58, '000', '', 0, '', '', '', 'dwdwa@dw', '', '000'),
(59, '000', '', 0, '', '', '', 'frfs@gmail', '', '00000000'),
(60, '000', '', 0, '', '', '', 'fefae@fe', '', '00000000'),
(61, '00', '', 0, '', '', '', 'feffe@fefe.com', '', '00000000'),
(62, '000', '', 0, '', '', '', 'vevsvse@fef.hu', '', '000000000'),
(63, 'fjfseih', '', 0, '', '', '', 'ffefafa@gmail.com', '', '$2b$08$dHTnQzXfpVeqmX2lH0qdaOW'),
(64, 'fgsrgsr', '', 0, '', '', '', 'fefa@fefjs.com', '', '00000000'),
(65, 'vdvsd', '', 0, '', '', '', 'gfrsges@gmail.com', '', '$2b$08$gGNJhPWcwCLV9izesg.RR..'),
(66, 'fefsfee', '', 0, '', '', '', 'fefesf@11111.com', '', '$2b$08$OgpvrrIyxy064wOvDUhSD.G'),
(67, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murhdvlk@gmail.com', '0345321', '$2b$08$RB6AUGZwwpaUpTVha0MCSO.'),
(68, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murhdvdlk@gmail.com', '0345321', '$2b$08$ETLqZla6AVyAhVLXOwFI6Ol'),
(69, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murh1dvdlk@gmail.com', '0345321', '$2b$08$XVX5I6dBVZhnWKPibnja.uT'),
(70, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murh1dv1dlk@gmail.com', '0345321', '$2b$08$l0ppIcWKMu6.oE2z9hkI.OC'),
(71, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murhf1dv1dlk@gmail.com', '0345321', '$2b$08$gkHMQvNy1VJ/yOf3YkIqzel'),
(72, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin10@gmail.com', '0345321', '$2b$08$DENXRmpRT83Uo1sFLQc1LeR'),
(73, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin11@gmail.com', '0345321', '$2b$08$N/XqZBOuDarnkED0JWnyEOQ'),
(74, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin12@gmail.com', '0345321', '$2b$08$weLkMGa3j.ltgZOXbZYfV.D'),
(75, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin13@gmail.com', '0345321', '$2b$08$4Jx.YT3RJlvUrrCWTq70WOr'),
(76, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin14@gmail.com', '0345321', '$2b$08$9epXWnLbF11N5/l3KfZJ1eK'),
(77, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin15@gmail.com', '0345321', '$2b$08$Nb./bQCMtu4moxQ.Fjflz.o'),
(78, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin16@gmail.com', '0345321', '$2b$08$sVB3KYxoaaJR1HdE0DlZ5uq'),
(79, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin161@gmail.com', '0345321', '$2b$08$couUPaDZKajA54lfj2eRy.v'),
(80, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin1611@gmail.com', '0345321', '$2b$08$J5YTMBcirUdAcGerQF9Ps.d'),
(81, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin16111@gmail.com', '0345321', '$2b$08$WBYvgioEFzvKSaOf1AG5xeK'),
(82, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin161111@gmail.com', '0345321', '$2b$08$yE6/QSvByUTA09u2ppQuuuJ/0Mywig.3xVya5uxHIBBL6/uWCtlsm'),
(83, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin1611111@gmail.com', '0345321', '$2b$08$Jth.1RP.CT8QO150XQTDdunVapDKHUfYgeqxvVqVgxZqnJyGnuOoO'),
(84, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin16211111@gmail.com', '0345321', '$2b$08$qQMiEJi8OyNjjwoPAQ/Wr.8gcs0rRW42yhqh8H1gOgsaUX.r6K.06'),
(85, '11111', '', 0, '', '', '', '11@11.com', '', '$2b$08$KbV3W6Hd54JE5v3Urjj6JecqL3kDA6nmItKdXqfepfOF5QRST8mIO'),
(86, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'murzsicz.martin116211111@gmail.com', '0345321', '$2b$08$09GIG/b8s7YNrYxEmCSqFOU0egs4Oze/H1yOeUNReA2Qr/ngXT8rG'),
(87, 'martin', '', 5600, '', 'Bekescsaba', 'Valami utca', 'test@test.com', '0345321', '$2b$08$yTn8dryZkpLCOrwsJe8lxu5BtviMocFf0WL76BcrDxQCMxIIUStz6'),
(88, '000', '', 0, '', '', '', 'efef@fref.com', '', '$2b$08$EE17.vHfX39MHBeX58lkBOxnYa8ompMfYKZIGGwoW46XmG6L74nDi'),
(89, 'martin1', '', 5600, '', 'Bekescsaba', 'Valami utca', 'test111@test.com', '0345321', '$2b$08$/EHUmDyBHBHJ8g4iJTpELugzVTn.GsEP9whL2EuRfvnxPE5kdhUkG'),
(90, 'martin11', '', 0, '', '', '', 'ffege@frfr.com', '', '$2b$08$2/uFly4HhgcL6.BkVT3NHOu3EqCyQwBJUItoz3FTb5.W6H6Ir./lS'),
(91, 'martinn', '', 0, '', '', '', 'test@test.hu', '', '$2b$08$Y1J3lRddvt3hEZ1L32dri..vHjG4KYxLutuJwcXvyrYLoXbo61FVC'),
(92, 'martinka', '', 0, '', '', '', 'murzsicz.martin1111@gmail.com', '', '$2b$08$g3G6uYnZvB7A6s.XstAc2.b5iMah4aNdlIzyFCOlsFh0F3G1Zi5we'),
(93, 'Mátyás Király', '', 0, '', 'Visegrád', '', 'matyas@kiraly.hu', '', '$2b$08$BIP.uFfFj8o5MknW./DNSubZYRPw/m5jNb1YEOpp5h3N9sS/AJvQK'),
(94, 'cdcs', '', 0, '', '', '', '123@123.hu', '', '$2b$08$u/yzBvFhF3U7/DiomCdnJeCwKdTWPGlxhJ4bRgqXWY0WE8u2OZ2qq'),
(95, 'cdcs2', '', 0, '', '', '', '123@1231.hu', '', '$2b$08$kZ09BqZSBUy2FXT5fqkuKuH8X7i4u.HelAbLzJz5Uxbxyx0pLPLV.'),
(96, 'cdcs22', '', 0, '', '', '', '123@12231.hu', '', '$2b$08$vfunU8swgIuVo3kLyGj6f.rMYSCoIiy30ScbIg5xoIzdfkqBGmcP6'),
(97, 'Dénes Enikő', '', 0, '', '', '', 'szaboeni@bekescsaba.hu', '', '$2b$08$UuRcLrxUDJeqmPXGNoseYOvUYLCbnF6UqtE0VbrCWlEEGS36k8YWe');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `auto`
--
ALTER TABLE `auto`
  ADD PRIMARY KEY (`azo`);

--
-- A tábla indexei `nyilvantartas`
--
ALTER TABLE `nyilvantartas`
  ADD KEY `autoazo` (`autoazo`),
  ADD KEY `ugyfelazo` (`ugyfelazo`);

--
-- A tábla indexei `ugyfel`
--
ALTER TABLE `ugyfel`
  ADD PRIMARY KEY (`ugyfelazo`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `auto`
--
ALTER TABLE `auto`
  MODIFY `azo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT a táblához `ugyfel`
--
ALTER TABLE `ugyfel`
  MODIFY `ugyfelazo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=98;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `nyilvantartas`
--
ALTER TABLE `nyilvantartas`
  ADD CONSTRAINT `nyilvantartas_ibfk_1` FOREIGN KEY (`autoazo`) REFERENCES `auto` (`azo`),
  ADD CONSTRAINT `nyilvantartas_ibfk_2` FOREIGN KEY (`ugyfelazo`) REFERENCES `ugyfel` (`ugyfelazo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
