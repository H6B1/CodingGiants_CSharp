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
        }

        public void Rysuj()
        {
            Raylib.DrawRectangle((int)Pozycja.X, (int)Pozycja.Y, rozmiarSiatki, rozmiarSiatki, Color.Purple);
        }
    }
}