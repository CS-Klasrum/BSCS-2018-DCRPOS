-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 22, 2020 at 02:46 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.2.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dcr`
--

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `EID` int(3) NOT NULL,
  `E_USERNAME` varchar(20) NOT NULL,
  `E_PASSWORD` varchar(16) NOT NULL,
  `E_FN` varchar(20) NOT NULL,
  `E_LN` varchar(20) NOT NULL,
  `E_ROLE` varchar(20) NOT NULL,
  `E_REGDATE` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`EID`, `E_USERNAME`, `E_PASSWORD`, `E_FN`, `E_LN`, `E_ROLE`, `E_REGDATE`) VALUES
(1, 'admin', 'admin', 'Clarence', 'Bauzon', 'Admin', '2020-02-29'),
(2, 'admin2', 'admin2', 'Dianamae', 'Bauzon', 'Admin', '2020-03-20'),
(3, 'rollyboy', 'japson', 'Rolly', 'Boy', 'Cashier', '2020-03-22');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `PROD_ID` int(3) NOT NULL,
  `PROD_NAME` varchar(20) NOT NULL,
  `PROD_SKU` varchar(20) NOT NULL,
  `PROD_STCK` int(3) NOT NULL,
  `PROD_PRICE` int(3) NOT NULL,
  `PROD_DELIVERYDATE` date NOT NULL,
  `PROD_EXPDATE` date NOT NULL,
  `PROD_MANUF` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`PROD_ID`, `PROD_NAME`, `PROD_SKU`, `PROD_STCK`, `PROD_PRICE`, `PROD_DELIVERYDATE`, `PROD_EXPDATE`, `PROD_MANUF`) VALUES
(1, 'Piattos', 'PTS-SRCRM-LRG', 96, 35, '2020-03-22', '2020-03-28', 'JACK AND JILL');

-- --------------------------------------------------------

--
-- Table structure for table `product_sales`
--

CREATE TABLE `product_sales` (
  `SD_ID` int(20) NOT NULL,
  `SALES_ID` int(3) NOT NULL,
  `PROD_ID` int(5) NOT NULL,
  `SALES_PRICE` int(5) NOT NULL,
  `SALES_QTY` int(5) NOT NULL,
  `SALES_BUY_PRICE` int(11) NOT NULL,
  `SALES_DATE` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `product_sales`
--

INSERT INTO `product_sales` (`SD_ID`, `SALES_ID`, `PROD_ID`, `SALES_PRICE`, `SALES_QTY`, `SALES_BUY_PRICE`, `SALES_DATE`) VALUES
(1, 1, 1, 35, 2, 70, '2020-03-22 00:00:00'),
(2, 1, 1, 35, 2, 70, '2020-03-22 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `SALES_ID` int(5) NOT NULL,
  `SALES_DATE` date NOT NULL,
  `SALES_TOTAL` int(5) NOT NULL,
  `SALES_CASH` int(5) NOT NULL,
  `SALES_CHANGE` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sales`
--

INSERT INTO `sales` (`SALES_ID`, `SALES_DATE`, `SALES_TOTAL`, `SALES_CASH`, `SALES_CHANGE`) VALUES
(1, '2020-03-22', 70, 70, 0),
(2, '2020-03-22', 70, 100, 30);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`EID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`PROD_ID`);

--
-- Indexes for table `product_sales`
--
ALTER TABLE `product_sales`
  ADD PRIMARY KEY (`SD_ID`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`SALES_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `EID` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `PROD_ID` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `product_sales`
--
ALTER TABLE `product_sales`
  MODIFY `SD_ID` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `sales`
--
ALTER TABLE `sales`
  MODIFY `SALES_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
