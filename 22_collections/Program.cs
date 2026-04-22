class Program
{
    public static void Main()
    {
        // Tworzenie słownika
        Dictionary<int, string> giganci = new Dictionary<int, string>();
        // Dodawanie elementów do słownika
        giganci.Add(1, "Ola");
        giganci.Add(2, "Piotr");
        giganci.Add(3, "Hanna");
        // Wyświetlanie elementów słownika
        foreach (var gigant in giganci)
        {
            //Console.WriteLine($"ID: {gigant.Key}, Imie: {gigant.Value}");
        }

        int key = 1;
        if (giganci.ContainsKey(key))
        {
            string imie = giganci[key];
            Console.WriteLine($"Istnieje gigant z ID: {key} o imieniu: {imie}");
        }

        giganci[2] = "Martyna";

        int klucz = 1;
        if (giganci.ContainsKey(klucz))
        {
            string imie = giganci[klucz];
            Console.WriteLine($"Istnieje gigant z ID: {klucz} o imieniu: {imie}");
        }
    }
}


// public class Osoba
// {
//     private int Wiek {public get;}
//     private string Imie {public get;public set;}

//     public string ToString()
//     {
//         return $"Imie: {Imie}, wiek: {Wiek}";
//     }

//     public Osoba (int age, string name)
//     {
//         Wiek = age;
//         Imie = name;
//     }

// }















// public class Pracownik : Osoba
// {
//     private string Pozycja {get; set;}

// }












// public class Osoba
// {
//     private string Imie {get; set;}
//     private int Wiek {get;}

//     public Osoba (string imie, int wiek)
//     {

//     }
// }