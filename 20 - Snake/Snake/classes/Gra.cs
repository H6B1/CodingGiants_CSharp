using Raylib_cs;
using System.Numerics;

namespace GraSnake
{
    public class Gra
    {
        private Waz waz;
        private Jedzenie jedzenie;

        private bool czyKoniecGry;
        private int szerokoscEkranu;
        private int wysokoscEkranu;
        private int rozmiarSiatki;
        private int punkty = 0;
        private int szybkosc = 10;

        public void Inicjalizuj()
        {
            szerokoscEkranu = 800;
            wysokoscEkranu = 640;
            rozmiarSiatki = 40;
            czyKoniecGry = false;

            Raylib.InitWindow(szerokoscEkranu, wysokoscEkranu, "Gra Waz");
            Raylib.SetTargetFPS(szybkosc);

            waz = new Waz(rozmiarSiatki, szerokoscEkranu, wysokoscEkranu);
            jedzenie = new Jedzenie(rozmiarSiatki, szerokoscEkranu, wysokoscEkranu);
        }

        public void Aktualizuj()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Up))
                waz.ZmienKierunek(new Vector2(0, -1));
            if (Raylib.IsKeyPressed(KeyboardKey.Down))
                waz.ZmienKierunek(new Vector2(0, 1));
            if (Raylib.IsKeyPressed(KeyboardKey.Left))
                waz.ZmienKierunek(new Vector2(-1, 0));
            if (Raylib.IsKeyPressed(KeyboardKey.Right))
                waz.ZmienKierunek(new Vector2(1, 0));


            if (waz.SprawdzKolizje(jedzenie.getPozycja()))
            {
                // change on objects
                waz.Rosnij();
                jedzenie.GenerujNowaPozycje();

                // changes on gameplay
                punkty++;
                szybkosc = Math.Min(szybkosc++, 60);
                Raylib.SetTargetFPS(szybkosc);
            }

            waz.Poruszaj();

            if (waz.SprawdzKolizjeZeSoba())
            {
                czyKoniecGry = true;
            }
        }

        public void Rysuj()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.Black);

            waz.Rysuj();
            jedzenie.Rysuj();

            Raylib.DrawText(punkty.ToString().PadLeft(2, '0'), 20, 20, 40, Raylib_cs.Color.White);

            if (czyKoniecGry)
            {
                Raylib.DrawText("Koniec Gry", szerokoscEkranu / 2 - 180, wysokoscEkranu / 2 - 70, 70, Raylib_cs.Color.Red);
                Raylib.DrawText("Nacisnij Enter aby zaczac ponownie", szerokoscEkranu / 2 - 270, wysokoscEkranu / 2 + 20, 30, Raylib_cs.Color.White);
            }

            Raylib.EndDrawing();
        }
        public void Uruchom()
        {
            Inicjalizuj();

            while (!Raylib.WindowShouldClose())
            {
                Aktualizuj();
                Rysuj();
            }

            Raylib.CloseWindow();
        }
        public void UruchomPonownie()
        {
            punkty = 0;
            szybkosc = 10;
            waz = new Waz(rozmiarSiatki, szerokoscEkranu, wysokoscEkranu);
            jedzenie = new Jedzenie(rozmiarSiatki, szerokoscEkranu, wysokoscEkranu);
            czyKoniecGry = false;

            Raylib.SetTargetFPS(szybkosc);
        }
    }
}