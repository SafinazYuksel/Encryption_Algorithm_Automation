# 🔐 Kriptoloji Şifreleme Algoritmaları

Bu proje, klasik kriptografi yöntemlerini kullanarak düz metinlerin (plaintext) şifrelenmesini sağlayan algoritmaları içermektedir. 

Şifreleme işlemleri, projenin **şifre çözme modülüyle tam uyumlu** çalışacak şekilde tasarlanmıştır.

## 🚀 Proje Özellikleri

* **Dil:** C#
* **Yöntem:** Hazır kriptografi kütüphaneleri **kullanılmamış**, tüm algoritmalar manuel matematiksel işlemlerle kodlanmıştır.
* **Dil Desteği:** Türkçe karakter desteği sağlanmıştır.
* **İndeksleme:** `A = 0` olacak şekilde alfabetik indeksleme mantığı esas alınmıştır.

## 🛠 İçerik: Algoritmalar

Projede şifreleme işlemleri aşağıdaki **11 algoritma** için uygulanmıştır:

1.  Sezar Şifreleme (Caesar Cipher)
2.  Kaydırmalı Şifreleme (Shift Cipher)
3.  Doğrusal (Affine) Şifreleme
4.  Yerdeğiştirme (Substitution) Şifreleme
5.  Permütasyon Şifreleme
6.  Sayı Anahtarlı Yerdeğiştirme Şifreleme (Number-Keyed Substitution)
7.  Rota Şifreleme (Route Cipher)
8.  Zigzag / Rail Fence Şifreleme
9.  Vigenère Şifreleme
10. 4 Kare (Four-Square) Şifreleme
11. Hill Şifreleme (NxN Matris)

## 💻 Kullanım

Program çalıştırıldığında kullanıcıdan aşağıdaki veriler istenir:

1.  **Algoritma Seçimi:** Listeden uygulanmak istenen şifreleme yöntemi seçilir.
2.  **Anahtar Verileri:** Seçilen algoritmaya özgü parametreler girilir (Örn: Kaydırma sayısı, matris boyutu, anahtar kelime vb.).
3.  **Metin Girişi:** Şifrelenecek açık metin (plaintext) girilir.

**Sonuç:** Program, girilen verilere göre **şifreli metni (ciphertext)** konsol ekranına yazdırır.
