using Raylib_cs;
using System.Numerics;

namespace GraSnake
{
    public class Jedzenie
    {
        public Vector2 Pozycja {get; private set;}
        private int rozmiarSiatki;
        private int szerokoscEkranu;
        private int wysokoscEkranu;

        // dodatkowe atrybuty jedzenia
        private Color kolor;
        private FoodShape ksztalt;

        private enum FoodShape { Circle, Square, Triangle }

        public Jedzenie(int rozmiarSiatki, int szerokoscEkranu, int wysokoscEkranu)
        {
            this.rozmiarSiatki = rozmiarSiatki;
            this.szerokoscEkranu = szerokoscEkranu;
            this.wysokoscEkranu = wysokoscEkranu;

            GenerujNowaPozycje();
        }

        public void GenerujNowaPozycje()
        {
            Random random = new Random();

            Pozycja = new Vector2(
                random.Next(0, szerokoscEkranu / rozmiarSiatki) * rozmiarSiatki,
                random.Next(0, wysokoscEkranu / rozmiarSiatki) * rozmiarSiatki
                );

            // losowy kolor
            // wymuszamy użycie konstruktora z bajtami
            kolor = new Color(
                (byte)random.Next(50, 256),
                (byte)random.Next(50, 256),
                (byte)random.Next(50, 256),
                (byte)255);

            // losowy kształt
            ksztalt = (FoodShape)random.Next(0, 3);
        }

        public void Rysuj()
        {
            switch (ksztalt)
            {
                case FoodShape.Circle:
                    Raylib.DrawCircle((int)Pozycja.X + rozmiarSiatki/2, (int)Pozycja.Y + rozmiarSiatki/2, rozmiarSiatki/2, kolor);
                    break;
                case FoodShape.Square:
                    Raylib.DrawRectangle((int)Pozycja.X, (int)Pozycja.Y, rozmiarSiatki, rozmiarSiatki, kolor);
                    break;
                case FoodShape.Triangle:
                    Vector2 p1 = new Vector2(Pozycja.X + rozmiarSiatki/2, Pozycja.Y);
                    Vector2 p2 = new Vector2(Pozycja.X, Pozycja.Y + rozmiarSiatki);
                    Vector2 p3 = new Vector2(Pozycja.X + rozmiarSiatki, Pozycja.Y + rozmiarSiatki);
                    Raylib.DrawTriangle(p1, p2, p3, kolor);
                    break;
            }
        }
    }
}