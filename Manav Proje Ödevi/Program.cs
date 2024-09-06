namespace Manav_Proje_Ödevi
{
    internal class Program
    {
       
            class Urun
        {
            public string Ad { get; set; }
            public double Kilo { get; set; }

            public Urun(string ad, double kilo)
            {
                Ad = ad;
                Kilo = kilo;
            }
        }

        static void Main(string[] args)
        {
            // Manavın ürünleri
            List<Urun> meyveler = new List<Urun>
            {
                new Urun("Elma", 100.0),
                new Urun("Armut", 80.0),
                new Urun("Muz", 90.0),
                new Urun("Kiraz", 50.0),
                new Urun("Üzüm", 70.0)
            };

            while (true)
            {
                Console.WriteLine("Meyve mi Sebze mi?");
                string secim = Console.ReadLine()?.ToLower();

                if (secim == "meyve")
                {
                    // Meyveleri listele
                    Console.WriteLine("Meyveler:");
                    for (int i = 0; i < meyveler.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {meyveler[i].Ad} ({meyveler[i].Kilo} kg)");
                    }

                    // Meyve seçimi
                    Console.Write("Seçiminizi yapın (1-5): ");
                    int meyveSecimi;
                    if (int.TryParse(Console.ReadLine(), out meyveSecimi) && meyveSecimi >= 1 && meyveSecimi <= meyveler.Count)
                    {
                        Urun secilenMeyve = meyveler[meyveSecimi - 1];

                        // Kilo giriş
                        Console.Write("Kaç kilo almak istersiniz? ");
                        double kilo;
                        if (double.TryParse(Console.ReadLine(), out kilo) && kilo > 0)
                        {
                            if (kilo <= secilenMeyve.Kilo)
                            {
                                secilenMeyve.Kilo -= kilo;
                                Console.WriteLine($"{kilo} kg {secilenMeyve.Ad} satın aldınız.");

                                // Ürün bittiğinde listeden kaldırma
                                if (secilenMeyve.Kilo <= 0)
                                {
                                    meyveler.Remove(secilenMeyve);
                                    Console.WriteLine($"{secilenMeyve.Ad} ürünleri tükendi.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Üzgünüm, yeterli kilo mevcut değil.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz kilo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim.");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim, lütfen 'Meyve' girin.");
                }

                // Başka bir arzunuz var mı?
                Console.Write("Başka bir arzunuz var mı? (Evet/Hayır): ");
                string devam = Console.ReadLine()?.ToLower();

                if (devam == "hayır")
                {
                    Console.WriteLine("İyi günler!");
                    Environment.Exit(0);
                    break;
                }
                
            }
        }
    }
}
