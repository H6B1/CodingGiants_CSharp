using Raylib_cs;
using System.Numerics;

namespace GraSnake
{
    public class Jedzenie
    {
        public Vector2 Pozycja { get; private set; }

        private int rozmiarSiatki;
        private int szerokoscEkranu;
        private int wysokoscEkranu;


        public void GenerujNowaPozycje()
        {
            Random random = new Random();

            int x = random.Next(0, szerokoscEkranu / rozmiarSiatki) * rozmiarSiatki;
            int y = random.Next(0, wysokoscEkranu / rozmiarSiatki) * rozmiarSiatki;
            Pozycja = new Vector2(x, y);
        }


    }
}