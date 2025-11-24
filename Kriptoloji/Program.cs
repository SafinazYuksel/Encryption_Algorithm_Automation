using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Kriptoloji
{
    class Program
    {
        static string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
        
        public static string KaydırmalıSifreleme(string metin, int kaydirma)
        {
            metin = metin.ToUpper();

            string temizMetin = "";

            foreach (char c in metin)         //ilk önce metin büyük harfe çevrilir
            {                                 //daha sonra alfabe dışındaki karakterler atılır. 
                if (alfabe.Contains(c))
                {
                    temizMetin += c;
                }
            }

            
            string sonuc = "";
            foreach (char c in temizMetin)               //bu döngü şifreleme kısmıdır
            {
                int index = alfabe.IndexOf(c);            //her harfin indeksi bulunur
                int yeniIndex = (index + kaydirma) % alfabe.Length;      //o indekse kaydırma miktarı eklenir 29a mod alınır
                sonuc += alfabe[yeniIndex];          //hesaplanan indekslerin harf karşılığı sonuca eklenir
            }

            return sonuc;
        }

        static string DogrusalSifrele(string metin, int a, int b)
        {
            metin = metin.ToUpper();   //metin büyük harfe çevrilir


            string temizMetin = "";

            foreach (char c in metin)  //alfabe dışındaki karakterler atılır
            {
                if (alfabe.Contains(c))
                {
                    temizMetin += c;
                }
            }

            string sonuc = "";

            foreach (char c in temizMetin)                     
            {
                    int x = alfabe.IndexOf(c);     // her harfin indeksi hesaplanır
                    int yeniIndex = (a * x + b) % alfabe.Length;     //kullanıcının girdiği a değeri indeksle çarpılır b değeri eklenir bu şwkilde yeni indeksler hesaplanır
                    sonuc += alfabe[yeniIndex];  // hesaplanan indeksin harf karşılıkları sonuca eklenir
            }

            return sonuc;
        }

        static string YerDegistirmeAlfabeIle(string metin)
        {
            string yeniAlfabe = "ZÜYVUTŞSRPÖONMLKJİIHĞGFEDÇCBA"; //  yeni bir alfabe tanımlanır 
            metin = metin.ToUpper(); //kullanıcının girdiği metin büyük harfe çevrilir


            string temizMetin = "";

            foreach (char c in metin) //metnin içindeki alfabe haricindeki karakterler atılır.
            { 
                if (alfabe.Contains(c))
                {
                    temizMetin += c;
                }
            }


            string sonuc = "";

            foreach (char c in temizMetin)       //metindeki her harfi tek tek gezer
            {
                    int index = alfabe.IndexOf(c); //her harfin önce alfabedeki indeksi bulunur
                    sonuc += yeniAlfabe[index];  //bulunan bu indeksin yeni alfabedeki harf karşılığı sonuca eklenir
                
            }

            return sonuc;
        }

        static string PermutasyonSifrele(string mesaj4, int[] anahtar4)
        {
            
            mesaj4 = mesaj4.ToUpper(); //metin büyük harfe çevrilir

            string temizMesaj = "";

            foreach (char c in mesaj4) //alfabe dışındaki karakterler atılır
            {
                if (alfabe.Contains(c))
                {
                    temizMesaj += c;
                }
            }

           
            int m = anahtar4.Length; // her bloğun uzunluğu belirlenir

            while (temizMesaj.Length % m != 0) // eğer metin bu bloğa tam bölünmezse bölünebilene kadar Ğ eklenir
            {
                temizMesaj += "Ğ";
            }

            string sifreli = "";

            for (int i = 0; i < temizMesaj.Length; i += m)  //metin m harflik bloklara ayrılır
            {
                char[] blok = new char[m];  //yeni bir dizi tanımlanır.Permütasyon işlemi sonucu şifreli metni tutucak

                for (int j = 0; j < m; j++)    // bu döngü her bir blok içindeki harfleri yeni sıraya göre dizer
                {
                    int hedefIndex = anahtar4[j] - 1;  //anahtar dizisindeki değere göre blok içindeki harfin asıl konumunu belirler
                    blok[j] = temizMesaj[i + hedefIndex]; //belirlenen konumdaki harfi alıp karıştırılmış blok içinde doğru sıraya yerleştirir.
                }

                sifreli += new string(blok); //her blok sırayla sifreliye eklenir
            }

            return sifreli;
        }


        static string alfabe2 = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZĞ";

        static char[,] MatrisYap(string metin) //metindeki her harfi sırayla matrise yerleştirir
        {
            char[,] matris = new char[6, 5];
            int index = 0;
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 5; j++)
                    matris[i, j] = metin[index++];
            return matris;
        }

        
        static (int, int) KonumBul(char[,] matris, char harf)
        {                                       //verilen harfi matris içinde arar ve bulunduğu satır ve sütun indeksini (i, j) olarak döndürür
            for (int i = 0; i < 6; i++)         //harf matriste yoksa -1,1 döner.
                for (int j = 0; j < 5; j++)
                    if (matris[i, j] == harf)
                        return (i, j);
            return (-1, -1); 
        }

        static string DortKareSifrele(string metin)
        {
            
            char[,] solUst = MatrisYap(alfabe2);                          // sol üstte ve sağ altta orijinal alfabe olur
            char[,] sagUst = MatrisYap("KSZFEPİŞLCRBGOAÜYÇHTĞUJDÖMVNIĞ"); // sol alt ve sağ üstte anahtarlar
            char[,] solAlt = MatrisYap("UNJPZRBÜŞEAÇKCFMYGİODTIHSLĞÖVĞ"); 
            char[,] sagAlt = MatrisYap(alfabe2);                          

            metin = metin.ToUpper();                    
            string temiz = "";
            foreach (char c in metin)                  // bu döngü alfabedeki karakterler dışındaki
            {                                          // bütün karakterleri atar
                if (alfabe2.Contains(c))               // boşluk, sayı vb.
                    temiz += c;
            }

            
            if (temiz.Length % 2 != 0)       // Şifrelerken metin ikişer ikişer bölündüğü için
                temiz += 'Ğ';                // Eğer tek basamaklıysa metin sonuna Ğ eklenir hata olmaması için

            string sifreli = "";

            for (int i = 0; i < temiz.Length; i += 2)  // döngü ilk çalıştığında i=0dır h1 metnin 0. indeksidir     
            {                                          // h2 metnin 1. indeksidir. 
                                                       // Döngü her çalıştığında ikişer ikişer artarar tüm indeksler gezilir.
                char h1 = temiz[i];            // h1 ve h2 şifrelenecek harflerdir 
                char h2 = temiz[i + 1];

                var (r1, c1) = KonumBul(solUst, h1);   // h1 harfinin sol üstteki orijinal alfabedeki konumu bulunur.
                var (r2, c2) = KonumBul(sagAlt, h2);   // h2 harfinin sağ alttaki orijinal alfabedeki konumu bulunur.

                char yeni1 = sagUst[r1, c2];    // h1'in satırı + h2’nin sütunundan 1 harf
                char yeni2 = solAlt[r2, c1];    //h2’in satırı + h1’nin sütunundan 1 harf

                sifreli += $"{yeni1}{yeni2}"; 
            }

            return sifreli;
        }


        static string SayiAnahtarliYerDegistirme(string metin, int sutunSayisi)
        {

            metin = metin.ToUpper();


            string temizMetin = "";         // bu döngü alfabedeki karakterler dışındaki
                                           // bütün karakterleri atar
            foreach (char c in metin)       // boşluk, sayı vb.
            {
               if (alfabe.Contains(c))
               {
                        temizMetin += c;
               }
            }


            int toplamHane = (int)Math.Ceiling((double)temizMetin.Length / sutunSayisi) * sutunSayisi;  // Şifreleme düzgün çalışsın diye metin, satır ve sütunlara tam bölünecek hale getirilir.
            temizMetin = temizMetin.PadRight(toplamHane, 'Ğ'); // Eksik kalan yerlere Ğ eklenir

            int satirSayisi = temizMetin.Length / sutunSayisi; //satır sayısı metnin uzunluğunun sütun sayısına bölümüyle hesaplanır
            char[,] tablo = new char[satirSayisi, sutunSayisi]; // metnin satır ve sütun sayıılarından oluşan bir matris tanımlarnı

            int index = 0;
            for (int i = 0; i < satirSayisi; i++)      //sırayla her harf bu matrise yerleştirilir
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    tablo[i, j] = temizMetin[index++];
                }
            }

            string sifreliMetin = "";            // metin şifrelenirken sütun sütun üstten aşağı okunur.
            for (int j = 0; j < sutunSayisi; j++)  // 0. sütundan başlayarak her satır okunur sonra 1. sütun diye devam eder
            {
               for (int i = 0; i < satirSayisi; i++)
               {
                    sifreliMetin += tablo[i, j];
               }
            }

            return sifreliMetin;
        }
        


        public static string RotaSifreleme(string metin7, int satirlar, int sutunlar)
        {
            
            metin7 = metin7.ToUpper();

            
            string temizMetin = "";
            foreach (char c in metin7)      // bu döngü metindeki gereksiz karakterleri atar
            {
                if (alfabe.Contains(c))
                {
                    temizMetin += c;
                }
            }

            int toplamHane = satirlar * sutunlar;        //matristeki satır ve sütun çarpılar
            if (temizMetin.Length < toplamHane)          //eğer metnin uzunluğu daha kısaysa sona Ğ eklenir 
            {
                temizMetin = temizMetin.PadRight(toplamHane, 'Ğ');
            }

            char[,] matrix = new char[satirlar, sutunlar];  //bir matris tanımlanır
            int index = 0;
            for (int i = 0; i < satirlar; i++)           // bu matrise sırayla her harf yazılır
            {
                for (int j = 0; j < sutunlar; j++)
                {
                    matrix[i, j] = temizMetin[index++];
                }
            }

            string sifreli = "";
            int top = 0, bottom = satirlar - 1;
            int left = 0, right = sutunlar - 1;

            while (top <= bottom && left <= right)
            {
                // → Sağa git
                for (int j = left; j <= right; j++)   //left righta doğru karakterleri okur
                    sifreli += matrix[top, j];
                top++;

                // ↓ Aşağı in
                for (int i = top; i <= bottom; i++)    //en sağdaki sütun okunur yani right sütunu
                    sifreli += matrix[i, right];       //toptan başlayarak bottoma kadar okur
                right--;

                // ← Sola git
                if (top <= bottom)                       // bottom satırı sağdan sola okunur
                {                                        // yani righttan lefte doğru
                    for (int j = right; j >= left; j--)
                        sifreli += matrix[bottom, j];
                    bottom--;
                }

                // ↑ Yukarı çık
                if (left <= right)                         //en soldaki left sütunundan yukarı doğru okunur
                {
                    for (int i = bottom; i >= top; i--)
                        sifreli += matrix[i, left];
                    left++;
                }
            }                                            // bu işlem bütün karakterler okunana kadar devam eder

            return sifreli;
        }


        public static string ZigzagSifreleme(string metin8, int key8)
        {
            
            metin8 = metin8.ToUpper();

            string temizMetin = "";
            foreach (char c in metin8)      //bu döngü alfabe dışı karakterleri atar
            {
                if (alfabe.Contains(c))
                {
                    temizMetin += c;
                }
            }

            if (key8 == 1)
            {
                return temizMetin;
            }

            string[] zigzag = new string[key8];   //her satır için string oluşturulur
            for (int i = 0; i < key8; i++)     
            {
                zigzag[i] = "";   //herbiri bir satırı temsil eder
            }

            int currentRow = 0; //harfin hangi satıra yazıldığını gösterir
            bool goingDown = true; //aşağı yukarı satıra ilerlediğimizi gösterir

            foreach (char c in temizMetin)  //her harf tek tek gezilir
            {
                zigzag[currentRow] += c;  //Bu satır, harfi o satıra ekler.

                if (goingDown)   
                {
                    currentRow++;  //currentrow 1 artar yani bir alt satıra iner

                    if (currentRow == key8) //eğer en alt satıra inmişse yön değiştirir
                    {
                        goingDown = false;      //yukarı doğru çıkar
                        currentRow = key8 - 2;  // alt sınırı aşmamak için -2
                    }
                }
                else //yukarı doğru çıkma işlemi burada yapılır
                {
                    currentRow--;  //her seferinde bir azaltılır yani bir basamak yukarı çıkar
                    if (currentRow < 0)
                    {
                        goingDown = true;   //en üst satıra ulaşınca yön değiştirir
                        currentRow = 1;
                    }
                }
            }

            string sifreliMetin8 = "";
            foreach (string rowText in zigzag)  //her satır sırayla gezilir
            {
                sifreliMetin8 += rowText;  //her satırdaki eleman sifreliMetin8'e eklenir.
            }

            return sifreliMetin8;
        }


        public static string VigenereSifreleme(string metin9, string key9)
        {
            
            string sifreliMetin9 = "";
            int keyIndex = 0; //kaçıncı harfin şifrelendiğini takip etmek için
            int alfabeUzunlugu = alfabe.Length;

            metin9 = metin9.ToUpper();
            key9 = key9.ToUpper();

            foreach (char c in metin9)  //metindeki bütün karakterler gezilir
            {
                if (alfabe.Contains(c))  //sadece alfabedeki harfler alınır.
                {
                    int harfIndex = alfabe.IndexOf(c);  //her harfin indeksi bulunur.
                    char keyChar = key9[keyIndex % key9.Length]; //Şifreleme sırasında sıradaki anahtar harfini bulur, anahtarın sonuna gelinirse başa döner.
                    int keyIndexVal = alfabe.IndexOf(keyChar); //Bulunan bu anahtar harfin alfabedeki indeksini belirler.

                    int sifreliHarfIndex = (harfIndex + keyIndexVal) % alfabeUzunlugu; //Mesajdaki harfin ve anahtar harfin indekslerini toplar, alfabenin uzunluğuna göre mod alarak yeni harfin konumunu bulur.
                    sifreliMetin9 += alfabe[sifreliHarfIndex]; // yeni indekse göre metin yazılır

                    keyIndex++;
                }
            }

            return sifreliMetin9;
        }


        public static string HillSifrele(string metin, int[,] keyMatrix, int n)
        {
            // Harfleri büyük yap ve sadece Türkçe alfabe harflerini al
            metin = metin.ToUpper();
            string temizMetin = "";

            foreach (char c in metin)
            {
                if (alfabe.Contains(c))
                {
                    temizMetin += c;
                }
            }

            // Metin uzunluğu matris boyutuna bölünemiyorsa "Ğ" harfiyle tamamla
            while (temizMetin.Length % n != 0)
            {
                temizMetin += 'Ğ';
            }

            string sifreliMetin = "";

            for (int i = 0; i < temizMetin.Length; i += n)  //Metin blok blok n karakterlik parçalar işlenecek. Bu döngü her blok için çalışır
            {
                int[] girisVektor = new int[n];  //Her blok için giriş vektörü (sayısal karşılıklar) oluşturulur.

                // Metindeki harflerin alfabe karşılıklarını al
                for (int j = 0; j < n; j++)
                {
                    girisVektor[j] = alfabe.IndexOf(temizMetin[i + j]);
                }

                // Hill algoritması çarpımı: keyMatrix × girisVektor
                for (int satir = 0; satir < n; satir++)
                {
                    int toplam = 0;
                    for (int col = 0; col < n; col++)
                    {
                        toplam += keyMatrix[satir, col] * girisVektor[col];
                    }

                    toplam %= alfabe.Length;  // mod %29 alınır
                    if (toplam < 0)
                    {
                        toplam += alfabe.Length;  // 0dan küçük indeks elde etmemek için
                    }

                    sifreliMetin += alfabe[toplam]; // toplamın alfabedi harf karşılığı sifreliMetine eklenir
                }
            }

            return sifreliMetin;
        }




        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("**************\n" +
                    "1. Kaydırmalı Şifreleme\n" +  
                    "2. Doğrusal Şifreleme\n" +                
                    "3. Yer değiştirme ile şifreleme\n" +
                    "4. Permütasyon ile şifreleme\n" +
                    "5. 4 kare şifrelme\n" +
                    "6. Yer değiştirme (sayı anahtarlı) şifreleme\n" +
                    "7. Rota şifreleme\n" +
                    "8. Zigzak şifreleme\n" +
                    "9. Vigenere şifreleme\n" +
                    "10. Hill şifreleme\n" +
                    "Çıkış için 0 giriniz\n" +
                    "**************\n"
                );
                Console.Write("Şifreleme Yöntemi Seçiniz: ");

                int yontem = int.Parse(Console.ReadLine());

                
                if (yontem == 0)
                {
                    break; 
                }

                switch (yontem)
                {
                    case 1:

                        Console.Write("Metni girin: ");
                        string input = Console.ReadLine();

                        Console.Write("Kaydırma miktarı: ");
                        int shift = int.Parse(Console.ReadLine());

                        string sifrelimetin1 = KaydırmalıSifreleme(input, shift);

                        Console.WriteLine("Şifreli Metin: " + sifrelimetin1);

                        break;
                    case 2:
                        Console.Write("Şifrelenecek metni girin: ");
                        string metin = Console.ReadLine();

                        Console.Write("a değerini girin: ");
                        int a = int.Parse(Console.ReadLine());

                        Console.Write("b değerini girin: ");
                        int b = int.Parse(Console.ReadLine());

                        string sifreliMetin = DogrusalSifrele(metin, a, b);

                        Console.WriteLine("Şifreli Metin: "+ sifreliMetin);
                        break;
                    case 3:
                        Console.Write("Şifrelenecek metni girin: ");
                        string input3 = Console.ReadLine().ToUpper();

                        string sonuc3 = YerDegistirmeAlfabeIle(input3);
                        Console.WriteLine("Şifreli Metin: " + sonuc3);
                        break;
                    case 4:
                        Console.Write("Mesajı girin: ");
                        string mesaj4 = Console.ReadLine();

                        Console.Write("Anahtar uzunluğunu girin: ");
                        int m = int.Parse(Console.ReadLine());

                        int[] anahtar4 = new int[m];
                        Console.Write("Permütasyon anahtarını girin: ");
                        string[] anahtarStr = Console.ReadLine().Split(' ');

                        for (int i = 0; i < m; i++)
                        {
                            anahtar4[i] = int.Parse(anahtarStr[i]);
                        }

                        string sifreliMesaj = PermutasyonSifrele(mesaj4, anahtar4);

                        Console.WriteLine("Şifreli metin: " + sifreliMesaj);
                        break;
                    case 5:
                        Console.Write("Şifrelenecek metni girin:");
                        string metin5 = Console.ReadLine();
                        string sonuc5 = DortKareSifrele(metin5);
                        Console.WriteLine("Şifreli Metin: "+ sonuc5);
                        break;
                    case 6:
                        Console.Write("Şifrelenecek metni girin: ");
                        string metin6 = Console.ReadLine();
                        Console.Write("Sütun sayısını giriniz: ");
                        int sutunSayisi6 = int.Parse(Console.ReadLine());
                        string sonuc6 = SayiAnahtarliYerDegistirme(metin6, sutunSayisi6);
                        Console.WriteLine("Şifreli Metin: " + sonuc6);
                        break;
                    case 7:
                        Console.Write("Şifrelenecek metni girin: ");
                        string plaintext = Console.ReadLine();

                        Console.Write("Sütun sayısını girin: ");
                        int columns = int.Parse(Console.ReadLine());


                        int rows = (plaintext.Length + columns - 1) / columns;


                        while (plaintext.Length < rows * columns)
                        {
                            plaintext += 'a';
                        }

                        string encryptedText = RotaSifreleme(plaintext, rows, columns);
                        Console.Write("Şifrelenmiş Metin: ");
                        Console.WriteLine(encryptedText);
                        break;
                    case 8:
                        Console.Write("Şifrelenecek metni girin: ");
                        string metin8 = Console.ReadLine();

                        Console.Write("Satır sayısını girin: ");
                        int key8 = int.Parse(Console.ReadLine());

                        string sifrelimetin8 = ZigzagSifreleme(metin8, key8);
                        Console.Write("Şifrelenmiş Metin: ");
                        Console.WriteLine(sifrelimetin8);
                        break;
                    case 9:
                        Console.Write("Şifrelenecek metni girin: ");
                        string metin9 = Console.ReadLine().ToUpper();

                        Console.Write("Anahtar kelimeyi girin: ");
                        string key9 = Console.ReadLine().ToUpper();

                        string sifrelimetin9 = VigenereSifreleme(metin9, key9);
                        Console.Write("Şifrelenmiş Metin:");
                        Console.WriteLine(sifrelimetin9);
                        break;
                    case 10:
                        Console.Write("Metni giriniz: ");
                        string metin10 = Console.ReadLine();

                        Console.Write("Matris boyutunu giriniz (örn: 2, 3, 4): ");
                        int n = int.Parse(Console.ReadLine());
                        
                        int[,] keyMatrix = new int[n, n];
                        Console.Write($"{n}x{n} Anahtar Matrisi değerlerini giriniz: ");

                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write($"[{i},{j}]: ");
                                keyMatrix[i, j] = int.Parse(Console.ReadLine());
                            }
                        }

                        string sifreli = HillSifrele(metin10, keyMatrix, n);
                        Console.WriteLine("Şifreli Metin: " + sifreli);
                        break;
                    default:
                        Console.WriteLine("1 ile 10 arasında seçim yapınız");
                        break;
                }

             

            }
        }
    
    }

}