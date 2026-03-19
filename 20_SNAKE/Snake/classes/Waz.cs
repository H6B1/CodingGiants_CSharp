using Raylib_cs;
using System.Numerics;

namespace GraSnake
{
    public class Waz
    {
        private List<Vector2> cialo;
        private Vector2 kierunek;
        private int rozmiarSiatki;
        private int szerokoscEkranu;
        private int wysokoscEkranu;
        private bool rosnij;

        public Waz(int rozmiarSiatki, int szerokoscEkranu, int wysokoscEkranu)
        {
            this.rozmiarSiatki = rozmiarSiatki;
            this.szerokoscEkranu = szerokoscEkranu;
            this.wysokoscEkranu = wysokoscEkranu;
            
            cialo = new List<Vector2>();
            cialo.Add(new Vector2(szerokoscEkranu / 2, wysokoscEkranu / 2));
            kierunek = new Vector2(1, 0);
            rosnij = false;
        }

        public void Poruszaj()
        {
            Vector2 glowa = cialo[0];
            Vector2 nowaGlowa = new Vector2(
                glowa.X + kierunek.X * rozmiarSiatki,
                glowa.Y + kierunek.Y * rozmiarSiatki);

            if (rosnij)
            {
                cialo.Insert(0, nowaGlowa);
                rosnij = false;
            }
            else
            {
                for (int i = cialo.Count - 1; i > 0; i--)
                {
                    cialo[i] = cialo[i - 1];
                }
                cialo[0] = nowaGlowa;
            }

            // Owiniecie wokol krawedzi ekranu
            Vector2 zaktualizowanaGlowa = cialo[0];
            if (zaktualizowanaGlowa.X >= szerokoscEkranu)
                zaktualizowanaGlowa.X = 0;

            if (zaktualizowanaGlowa.X < 0)
                zaktualizowanaGlowa.X = szerokoscEkranu - rozmiarSiatki;

            if (zaktualizowanaGlowa.Y >= wysokoscEkranu)
                zaktualizowanaGlowa.Y = 0;

            if (zaktualizowanaGlowa.Y < 0)
                zaktualizowanaGlowa.Y = wysokoscEkranu - rozmiarSiatki;


            cialo[0] = zaktualizowanaGlowa;
        }
        
        public bool SprawdzKolizje(Vector2 pozycja)
        {
            foreach (var segment in cialo)
            {
                if (segment.X == pozycja.X && segment.Y == pozycja.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool SprawdzKolizjeZeSoba()
        {
            Vector2 glowa = cialo[0];
            for (int i = 1; i < cialo.Count; i++)
            {
                if (cialo[i].X == glowa.X && cialo[i].Y == glowa.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void Rosnij()
        {
            rosnij = true;
        }

        public void ZmienKierunek(Vector2 nowyKierunek)
        {
            // Zapobieganie odwroceniu sie waza
            if ((kierunek.X + nowyKierunek.X != 0) || (kierunek.Y + nowyKierunek.Y != 0))
            {
                kierunek = nowyKierunek;
            }
        }

        public void Rysuj()
        {

            Raylib.DrawRectangle((int)cialo[0].X, (int)cialo[0].Y, rozmiarSiatki, rozmiarSiatki, Color.White);

            for (int i = 1; i < cialo.Count(); i++)
            {
                Raylib.DrawRectangle((int)cialo[i].X, (int)cialo[i].Y, rozmiarSiatki, rozmiarSiatki, Color.Green);
            }
            
        }
    }
}

