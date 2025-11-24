<img width="654" height="502" alt="image" src="https://github.com/user-attachments/assets/7110b809-b870-49fe-b607-12da74f5cb98" />


Bu proje klasik kriptografi yöntemlerini kullanarak düz metinlerin şifrelenmesini sağlayan algoritmaları içermektedir. 

Şifreleme işlemleri, şifre çözme modülüyle tam uyumlu çalışacak şekilde tasarlanmıştır.

Tüm algoritmalar C# dili kullanılarak, hazır kriptografi kütüphaneleri kullanılmadan manuel matematiksel işlemlerle geliştirilmiştir.

Türkçe karakter desteği sağlanmış, A harfi = 0 olacak şekilde alfabetik indeksleme mantığı esas alınmıştır.

İÇERİK
Projede şifreleme işlemleri aşağıdaki 11 algoritma için uygulanmıştır:
Sezar Şifreleme (Caesar Cipher)
Kaydırmalı Şifreleme (Shift Cipher)
Doğrusal (Affine) Şifreleme
Yerdeğiştirme (Substitution) Şifreleme
Permütasyon Şifreleme
Sayı Anahtarlı Yerdeğiştirme Şifreleme (Number-Keyed Substitution)
Rota Şifreleme (Route Cipher)
Zigzag / Rail Fence Şifreleme
Vigenère Şifreleme
4 Kare (Four-Square) Şifreleme
Hill Şifreleme (NxN Matris)

Kullanıcıdan şifrelenecek açık metin ve seçilen algoritmaya özgü anahtar verileri alınmakta ve çıktı olarak şifreli metin döndürülmektedir.
