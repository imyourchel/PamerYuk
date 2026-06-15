-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 11 Jan 2025 pada 12.27
-- Versi server: 10.4.20-MariaDB
-- Versi PHP: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pjuas`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `kisahhidup`
--

CREATE TABLE `kisahhidup` (
  `Organisasi_id` int(11) NOT NULL,
  `username` varchar(40) NOT NULL,
  `thawal` varchar(4) DEFAULT NULL,
  `thakhir` varchar(4) DEFAULT NULL,
  `deskripsi` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `kisahhidup`
--

INSERT INTO `kisahhidup` (`Organisasi_id`, `username`, `thawal`, `thakhir`, `deskripsi`) VALUES
(1, 'chel', '2010', '2016', 'masih polos'),
(2, 'chel', '2016', '2019', 'mulai nakal'),
(3, 'cath', '2019', '2022', 'masa remaja'),
(4, 'chel', '2023', NULL, 'lagi senang-senangnya'),
(5, 'rofi', '2022', NULL, 'cuan cuan'),
(6, 'dev', '2023', NULL, 'lanjut lanjuttt'),
(7, 'chel', '2023', NULL, 'mau stop, tapi tetap lanjut'),
(8, 'chel', '2019', '2022', 'masa rajin belajar'),
(9, 'jenni', '2019', '2022', 'ketemu debubuy'),
(10, 'dev', '2019', '2022', 'gak tau, yang penting sekolah');

-- --------------------------------------------------------

--
-- Struktur dari tabel `komen`
--

CREATE TABLE `komen` (
  `id` int(11) NOT NULL,
  `komentar` text DEFAULT NULL,
  `tgl` datetime DEFAULT NULL,
  `username` varchar(40) NOT NULL,
  `Konten_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `komen`
--

INSERT INTO `komen` (`id`, `komentar`, `tgl`, `username`, `Konten_id`) VALUES
(1, 'As kiww', '2024-12-12 18:00:31', 'jenni', 1),
(2, 'foto dimana tuh', '2024-12-31 19:31:45', 'cath', 2),
(3, 'yang foto siapa tuhh? kiwkiw', '2024-12-31 20:45:34', 'chel', 2),
(4, 'cupu luu', '2024-12-31 22:32:45', 'chel', 5),
(5, 'dimana tuh?', '2024-10-12 23:10:26', 'rofi', 3);

-- --------------------------------------------------------

--
-- Struktur dari tabel `konten`
--

CREATE TABLE `konten` (
  `id` int(11) NOT NULL,
  `caption` text DEFAULT NULL,
  `foto` varchar(45) DEFAULT NULL,
  `video` varchar(45) DEFAULT NULL,
  `tglUpload` datetime DEFAULT NULL,
  `username` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `konten`
--

INSERT INTO `konten` (`id`, `caption`, `foto`, `video`, `tglUpload`, `username`) VALUES
(1, 'pap', 'chel.jpg', NULL, '2024-12-12 17:20:13', 'chel'),
(2, 'life recently', 'jenni.jpg', NULL, '2024-12-31 19:00:17', 'jenni'),
(3, 'random', 'cath.jpg', NULL, '2024-10-12 12:10:28', 'cath'),
(4, 'gabut', 'rofi.jpg', NULL, '2024-12-25 23:30:21', 'rofi'),
(5, 'game', 'dev.jpg', NULL, '2024-12-31 22:02:50', 'dev');

-- --------------------------------------------------------

--
-- Struktur dari tabel `kota`
--

CREATE TABLE `kota` (
  `id` int(11) NOT NULL,
  `nama` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `kota`
--

INSERT INTO `kota` (`id`, `nama`) VALUES
(1, 'Jakarta'),
(2, 'Surabaya'),
(3, 'Bandung'),
(4, 'Yogyakarta'),
(5, 'Bali'),
(6, 'Makassar'),
(7, 'Merauke'),
(8, 'Malang'),
(9, 'Medan'),
(10, 'Semarang');

-- --------------------------------------------------------

--
-- Struktur dari tabel `organisasi`
--

CREATE TABLE `organisasi` (
  `id` int(11) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `jenis` enum('SD','SMP','SMA','Kuliah','Tempat Kerja','Organisasi') DEFAULT NULL,
  `Kota_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `organisasi`
--

INSERT INTO `organisasi` (`id`, `nama`, `jenis`, `Kota_id`) VALUES
(1, 'SDN 1 SBY', 'SD', 2),
(2, 'SMPN 1 SBY', 'SMP', 2),
(3, 'SMAN 1 SBY', 'SMA', 2),
(4, 'UBAYA', 'Kuliah', 2),
(5, 'Tesla', 'Tempat Kerja', 1),
(6, 'KSM IF', 'Organisasi', 2),
(7, 'KMM PPM', 'Organisasi', 2),
(8, 'SMA Katolik Rajawali', 'SMA', 6),
(9, 'SMA Katolik St.Louis 1', 'SMA', 2),
(10, 'SMA Kristen Petra 5', 'SMA', 2);

-- --------------------------------------------------------

--
-- Struktur dari tabel `percakapan`
--

CREATE TABLE `percakapan` (
  `User_pengirim` varchar(40) NOT NULL,
  `User_penerima` varchar(40) NOT NULL,
  `isiPesan` text DEFAULT NULL,
  `waktuKirim` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `percakapan`
--

INSERT INTO `percakapan` (`User_pengirim`, `User_penerima`, `isiPesan`, `waktuKirim`) VALUES
('cath', 'chel', 'coba tebak', '2024-12-31 14:33:00'),
('chel', 'dev', 'g mau.', '2024-12-31 14:34:00'),
('jenni', 'chel', 'siapa yaa?', '2024-12-31 14:32:00');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tag`
--

CREATE TABLE `tag` (
  `Konten_id` int(11) NOT NULL,
  `username` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `tag`
--

INSERT INTO `tag` (`Konten_id`, `username`) VALUES
(1, 'cath'),
(1, 'jenni'),
(2, 'cath'),
(2, 'rofi'),
(5, 'chel');

-- --------------------------------------------------------

--
-- Struktur dari tabel `teman`
--

CREATE TABLE `teman` (
  `username1` varchar(40) NOT NULL,
  `username2` varchar(40) NOT NULL,
  `tglBerteman` date DEFAULT NULL,
  `status` enum('request','blokir') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `teman`
--

INSERT INTO `teman` (`username1`, `username2`, `tglBerteman`, `status`) VALUES
('cath', 'chel', '2023-10-18', NULL),
('chel', 'cath', '2023-10-18', NULL),
('chel', 'dev', '2023-12-12', NULL),
('chel', 'jenni', '2023-08-20', NULL),
('chel', 'rofi', '2024-01-21', NULL),
('dev', 'chel', '2023-12-12', NULL),
('jenni', 'cath', NULL, 'request'),
('jenni', 'chel', '2023-08-20', NULL),
('jenni', 'dev', NULL, 'blokir'),
('rofi', 'chel', '2024-01-21', NULL);

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `username` varchar(40) NOT NULL,
  `password` varchar(128) DEFAULT NULL,
  `namaLengkap` varchar(45) DEFAULT NULL,
  `tglLahir` date DEFAULT NULL,
  `noKTP` varchar(16) DEFAULT NULL,
  `fotoDiri` varchar(45) DEFAULT NULL,
  `fotoProfile` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `Kota_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `user`
--

INSERT INTO `user` (`username`, `password`, `namaLengkap`, `tglLahir`, `noKTP`, `fotoDiri`, `fotoProfile`, `email`, `Kota_id`) VALUES
('cath', '123', 'Catharina', '2005-07-25', '1234567890123458', 'cath.jpg', 'cath.jpg', 'cath@gmail.com', 2),
('chel', '123', 'Rachel', '2005-10-04', '1234567890123456', 'chel.jpg', 'chel.jpg', 'chel@gmail.com', 6),
('dev', '123', 'Devina', '2005-01-02', '1234567890123459', 'dev.jpg', 'dev.jpg', 'dev@gmail.com', 4),
('jenni', '123', 'Jennifer', '2005-03-01', '1234567890123457', 'jenni.jpg', 'jenni.jpg', 'jenni@gmail.com', 7),
('rofi', '123', 'Rofi', '2004-01-03', '1234567890123460', 'rofi.jpg', 'rofi.jpg', 'rofi@gmail.com', 5);

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `kisahhidup`
--
ALTER TABLE `kisahhidup`
  ADD PRIMARY KEY (`Organisasi_id`,`username`),
  ADD KEY `fk_Organisasi_username_username1_idx` (`username`),
  ADD KEY `fk_Organisasi_username_Organisasi1_idx` (`Organisasi_id`);

--
-- Indeks untuk tabel `komen`
--
ALTER TABLE `komen`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Komen_User1_idx` (`username`),
  ADD KEY `fk_Komen_Konten1_idx` (`Konten_id`);

--
-- Indeks untuk tabel `konten`
--
ALTER TABLE `konten`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Konten_User1_idx` (`username`);

--
-- Indeks untuk tabel `kota`
--
ALTER TABLE `kota`
  ADD PRIMARY KEY (`id`);

--
-- Indeks untuk tabel `organisasi`
--
ALTER TABLE `organisasi`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Organisasi_Kota_idx` (`Kota_id`);

--
-- Indeks untuk tabel `percakapan`
--
ALTER TABLE `percakapan`
  ADD PRIMARY KEY (`User_pengirim`,`User_penerima`),
  ADD KEY `fk_User_has_User_User2_idx` (`User_penerima`),
  ADD KEY `fk_User_has_User_User1_idx` (`User_pengirim`);

--
-- Indeks untuk tabel `tag`
--
ALTER TABLE `tag`
  ADD PRIMARY KEY (`Konten_id`,`username`),
  ADD KEY `fk_Konten_User_User1_idx` (`username`),
  ADD KEY `fk_Konten_User_Konten1_idx` (`Konten_id`);

--
-- Indeks untuk tabel `teman`
--
ALTER TABLE `teman`
  ADD PRIMARY KEY (`username1`,`username2`),
  ADD KEY `fk_User_User_User2_idx` (`username2`),
  ADD KEY `fk_User_User_User1_idx` (`username1`);

--
-- Indeks untuk tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`username`),
  ADD KEY `fk_User_Kota1_idx` (`Kota_id`);

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `kisahhidup`
--
ALTER TABLE `kisahhidup`
  ADD CONSTRAINT `fk_Organisasi_username_Organisasi1` FOREIGN KEY (`Organisasi_id`) REFERENCES `organisasi` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Organisasi_username_username1` FOREIGN KEY (`username`) REFERENCES `user` (`username`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `komen`
--
ALTER TABLE `komen`
  ADD CONSTRAINT `fk_Komen_Konten1` FOREIGN KEY (`Konten_id`) REFERENCES `konten` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Komen_User1` FOREIGN KEY (`username`) REFERENCES `user` (`username`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `konten`
--
ALTER TABLE `konten`
  ADD CONSTRAINT `fk_Konten_User1` FOREIGN KEY (`username`) REFERENCES `user` (`username`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `organisasi`
--
ALTER TABLE `organisasi`
  ADD CONSTRAINT `fk_Organisasi_Kota` FOREIGN KEY (`Kota_id`) REFERENCES `kota` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `percakapan`
--
ALTER TABLE `percakapan`
  ADD CONSTRAINT `fk_User_has_User_User1` FOREIGN KEY (`User_pengirim`) REFERENCES `user` (`username`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_User_has_User_User2` FOREIGN KEY (`User_penerima`) REFERENCES `user` (`username`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `tag`
--
ALTER TABLE `tag`
  ADD CONSTRAINT `fk_Konten_User_Konten1` FOREIGN KEY (`Konten_id`) REFERENCES `konten` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Konten_User_User1` FOREIGN KEY (`username`) REFERENCES `user` (`username`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `teman`
--
ALTER TABLE `teman`
  ADD CONSTRAINT `fk_User_User_User1` FOREIGN KEY (`username1`) REFERENCES `user` (`username`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_User_User_User2` FOREIGN KEY (`username2`) REFERENCES `user` (`username`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ketidakleluasaan untuk tabel `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `fk_User_Kota1` FOREIGN KEY (`Kota_id`) REFERENCES `kota` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
