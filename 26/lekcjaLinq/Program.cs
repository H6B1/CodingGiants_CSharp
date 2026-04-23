public class Student
{
    public string Imie { get; set; }
    public int Wiek { get; set; }
    public float Srednia { get; set; }
}
public class Program
{
    public static void Main()
    {
        var studenci = new List<Student>
        {
            new Student { Imie = "Anna", Wiek = 20, Srednia = 4.65f },
            new Student { Imie = "Zbysiu", Wiek = 22, Srednia = 5.12f },
            new Student { Imie = "Marta", Wiek = 19, Srednia = 4.87f },
            new Student { Imie = "Karolina", Wiek = 23, Srednia = 3.89f }
        };

        
    }
}


// -- DATA -- 
// Imie = "Anna", Wiek = 20, Srednia = 4.65f
// Imie = "Zbysiu", Wiek = 22, Srednia = 5.12f
// Imie = "Marta", Wiek = 19, Srednia = 4.87f
// Imie = "Karolina", Wiek = 23, Srednia = 3.89f