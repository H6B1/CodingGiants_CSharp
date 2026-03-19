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
        // ruch węża kontrolowany przez timer niezależny od klatkażu
        private float szybkosc = 10f;                // ruchów na sekundę
        private float moveTimer = 0f;
        private float moveInterval => 1f / szybkosc;

        public void Inicjalizuj()
        {
            szerokoscEkranu = 800;
            wysokoscEkranu = 640;
            rozmiarSiatki = 40;
            czyKoniecGry = false;

            Raylib.InitWindow(szerokoscEkranu, wysokoscEkranu, "Gra Waz");
            // utrzymujemy stały wysokie klatkaże, ruch węża sterowany timerem
            Raylib.SetTargetFPS(60);
            moveTimer = 0f;

            waz = new Waz(rozmiarSiatki, szerokoscEkranu, wysokoscEkranu);
            jedzenie = new Jedzenie(rozmiarSiatki, szerokoscEkranu, wysokoscEkranu);
        }
        public void Aktualizuj()
        {
            // jeżeli gra zakończona, zatrzymujemy ruch i czekamy na Enter
            if (czyKoniecGry)
            {
                if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                {
                    UruchomPonownie();
                }
                return;
            }

            // kierunek można zmienić w każdej klatce niezależnie od ruchu
            if (Raylib.IsKeyPressed(KeyboardKey.Up))
                waz.ZmienKierunek(new Vector2(0, -1));
            if (Raylib.IsKeyPressed(KeyboardKey.Down))
                waz.ZmienKierunek(new Vector2(0, 1));
            if (Raylib.IsKeyPressed(KeyboardKey.Left))
                waz.ZmienKierunek(new Vector2(-1, 0));
            if (Raylib.IsKeyPressed(KeyboardKey.Right))
                waz.ZmienKierunek(new Vector2(1, 0));

            // ruch węża co pewien odstęp czasu (bardziej płynne)
            moveTimer += Raylib.GetFrameTime();
            if (moveTimer >= moveInterval)
            {
                moveTimer -= moveInterval;
                waz.Poruszaj();

                // sprawdzamy kolizje dopiero po przesunięciu
                if (waz.SprawdzKolizje(jedzenie.Pozycja))
                {
                    waz.Rosnij();
                    jedzenie.GenerujNowaPozycje();

                    // aktualizacja wyników i prędkości ruchu
                    punkty++;
                    szybkosc = Math.Min(szybkosc + 1f, 60f);
                }

                if (waz.SprawdzKolizjeZeSoba())
                {
                    czyKoniecGry = true;
                }
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
            szybkosc = 10f;
            moveTimer = 0f;
            waz = new Waz(rozmiarSiatki, szerokoscEkranu, wysokoscEkranu);
            jedzenie = new Jedzenie(rozmiarSiatki, szerokoscEkranu, wysokoscEkranu);
            czyKoniecGry = false;

            // celowo FPS stałe, ruch kontrolowany timerem
            Raylib.SetTargetFPS(60);
        }
    }
}