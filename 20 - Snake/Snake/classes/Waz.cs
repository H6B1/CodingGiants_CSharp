using Raylib_cs;

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
            cialo.Add(new Vector2(szerokoscEkranu / 2, wysokoscEkranu /
            2));
            kierunek = new Vector2(1, 0);
            rosnij = false;
        }
    }
}