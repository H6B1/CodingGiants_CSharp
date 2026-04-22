using Microsoft.EntityFrameworkCore;
public class Program
{
    public static async Task Main(string[] args)
    {


        using (var kontekst = new KontekstGry())
        {
            kontekst.Database.EnsureDeleted();
            kontekst.Database.EnsureCreated();

            // CREATE: Dodanie nowego wydawcy i gry do bazy danych
            var nowyWydawca = new Wydawca
            {
                Nazwa = "Nintendo"
            };

            var nowaGra = new GraVideo
            {
                Tytul = "The Legend of Zelda",
                Gatunek = "Przygodowa",
                RokWydania = 1986,
                Wydawca = nowyWydawca,
            };

            await kontekst.Wydawcy.AddAsync(nowyWydawca);
            await kontekst.GryVideo.AddAsync(nowaGra);
            await kontekst.SaveChangesAsync();
            Console.WriteLine("Dodano nowego wydawcę i grę: The Legend of Zelda");

            // READ: Odczytanie wszystkich gier z filtrowaniem i sortowaniem
            var gry = await kontekst.GryVideo
                .Include(g => g.Wydawca)
                .Where(g => g.RokWydania > 1980)
                .OrderBy(g => g.Tytul)
                .ToListAsync();

            Console.WriteLine("Wszystkie gry wydane po 1980 roku:");

            foreach (var gra in gry)
            {
                Console.WriteLine($"Tytuł: {gra.Tytul}, Gatunek: {gra.Gatunek}, Rok: {gra.RokWydania}, Wydawca: {gra.Wydawca.Nazwa}");
            }

            // UPDATE: Aktualizacja istniejącej gry
            var graDoAktualizacji = await kontekst.GryVideo.FirstAsync();
            graDoAktualizacji.Gatunek = "Akcja-Przygoda";
            await kontekst.SaveChangesAsync();
            Console.WriteLine("Zaktualizowano gatunek pierwszej gry na Akcja-Przygoda");


            // DELETE: Usunięcie gry z bazy danych
            var graDoUsuniecia = await kontekst.GryVideo.FirstAsync();
            kontekst.GryVideo.Remove(graDoUsuniecia);
            await kontekst.SaveChangesAsync();
            Console.WriteLine("Usunięto pierwszą grę z kolekcji");
        }
    }
}