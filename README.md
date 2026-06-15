# 📸 PamerYuk - Social Media Desktop App

Aplikasi media sosial berbasis desktop (Windows Forms / C#) yang memungkinkan pengguna berbagi foto 🖼️, berinteraksi dengan teman 👥, dan mengelola profil pribadi mereka dengan mudah.

---

## 🧰 Teknologi

- 💻 **Bahasa:** C# (.NET Framework — Windows Forms)
- 🗄️ **Database:** MySQL (via `pjuas.sql`)
- 🛠️ **IDE:** Visual Studio
- 📦 **Dependensi:** NuGet Packages (lihat folder `packages/`)

---

## ✨ Fitur Utama

- 🔐 **Autentikasi** — Login dan registrasi akun pengguna
- 🏠 **Beranda (FormUtama)** — Feed utama untuk melihat postingan
- 📤 **Upload Foto** — Unggah dan bagikan foto ke pengguna lain
- 👤 **Profil Pengguna** — Lihat dan edit profil sendiri
- 🔍 **Profil Orang Lain** — Kunjungi halaman profil pengguna lain
- 🔎 **Pencarian** — Cari pengguna berdasarkan nama
- 🤝 **Pertemanan** — Lihat daftar teman
- 🚫 **Blokir Pengguna** — Blokir dan kelola daftar blokir
- 💬 **Chat** — Kirim pesan langsung ke pengguna lain
- 🔔 **Notifikasi** — Terima pemberitahuan aktivitas
- 🏷️ **Tag** — Tandai pengguna di postingan
- 📖 **Kisah Hidup** — Bagian khusus cerita/bio pengguna

---

## 🗂️ Struktur Proyek
PamerYuk/
├── 📁 PAMERYUK/ # Source code utama (C# WinForms)
│ ├── FormLogin.cs # 🔐 Form login
│ ├── FormRegister.cs # 📝 Form registrasi
│ ├── FormUtama.cs # 🏠 Beranda / feed utama
│ ├── FormProfile.cs # 👤 Halaman profil sendiri
│ ├── FormEditProfile.cs # ✏️ Edit profil
│ ├── FormUpload.cs # 📤 Upload foto
│ ├── FormChat.cs # 💬 Fitur chat
│ ├── FormSearch.cs # 🔎 Pencarian pengguna
│ ├── FormNotifikasi.cs # 🔔 Notifikasi
│ ├── FormTag.cs # 🏷️ Fitur tag
│ ├── FormKisahHidup.cs # 📖 Kisah hidup pengguna
│ ├── FormDaftarTeman.cs # 🤝 Daftar teman
│ ├── FormDaftarBlock.cs # 🚫 Daftar blokir
│ ├── FormOtherPost.cs # 🖼️ Lihat postingan orang lain
│ └── FormOtherUserPage.cs # 👥 Halaman profil orang lain
├── 📁 Class_PamerYuk/ # Class library pendukung
├── 📁 packages/ # NuGet packages
├── 🗄️ pjuas.sql # Script database MySQL
└── 📄 PAMERYUK.sln # Solution file Visual Studio

---

## ⚙️ Cara Menjalankan

### 📋 Prasyarat
- Visual Studio 2019 / 2022
- MySQL Server (lokal atau remote)
- .NET Framework 4.x

### 🚀 Langkah Instalasi

1. **📥 Clone repositori**
   ```bash
   git clone https://github.com/imyourchel/PamerYuk.git
   ```

2. **🗄️ Import database**
   Buka MySQL, buat database baru, lalu import file SQL:
   ```sql
   CREATE DATABASE pjuas;
   USE pjuas;
   SOURCE pjuas.sql;
   ```

3. **🔧 Konfigurasi koneksi database**
   Edit file `PAMERYUK/App.config`, sesuaikan string koneksi:
   ```xml
   <connectionStrings>
     <add name="..." connectionString="server=localhost;database=pjuas;uid=root;pwd=YOUR_PASSWORD;" />
   </connectionStrings>
   ```

4. **▶️ Jalankan aplikasi**
   Buka file `PAMERYUK.sln` di Visual Studio, lalu tekan `F5`.

---

## 📄 Lisensi

Proyek ini dibuat untuk keperluan akademik 🎓 (Ujian Akhir Semester). Bebas digunakan untuk referensi pembelajaran.

---

## 👤 Author

**imyourchel** — [GitHub](https://github.com/imyourchel) 🐱
