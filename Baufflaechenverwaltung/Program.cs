using System;
using System.Collections.Generic;

namespace Baufflaechenverwaltung
{
    public enum FlaechenStatus { Frei, Reserviert, Bebaut }
    public enum BauvorhabenStatus { AntragEingereicht, Genehmigt, Abgelehnt, InBearbeitung, Abgeschlossen }
    public enum Nutzung { Gewerbe, Landwirtschaft, Forst, Wohnnutzung, Brachflaeche }

    public class Antragsteller
    {
        public string Name { get; set; } = string.Empty;
        public string Kontaktdaten { get; set; } = string.Empty;
        public string Firma { get; set; } = string.Empty;
    }

    public class Bauflaeche
    {
        public string Id { get; set; } = string.Empty;
        public double Groesse { get; set; }
        public string Lage { get; set; } = string.Empty;
        public Nutzung AktuelleNutzung { get; set; }
        public string Bebaubarkeit { get; set; } = string.Empty;
        public string BPlanNummer { get; set; } = string.Empty;
        public decimal Bodenrichtwert { get; set; }
        public string Eigentuemer { get; set; } = string.Empty;
        public FlaechenStatus Status { get; set; } = FlaechenStatus.Frei;

        public void FlaecheReservieren() => Status = FlaechenStatus.Reserviert;

        // Prüfen ob die Fläche Bebaubar ist
        public string BaubarkeitPrüfen(Bauflaeche bauflaeche)
        {
            if(bauflaeche.Bebaubarkeit = 'Ja' || )
        }
        #FIXME 
    }

    public class Grundstueck
    {
        public string FlurstueckNummer { get; set; } = string.Empty;
        public List<Bauflaeche> Bauflaechen { get; set; } = new List<Bauflaeche>();
    }

    public class Bauvorhaben
    {
        public string Titel { get; set; } = string.Empty;
        public Antragsteller Antragsteller { get; set; } = new Antragsteller();
        public string GeplanteNutzung { get; set; } = string.Empty;
        public DateTime Beginn { get; set; }
        public DateTime Fertigstellung { get; set; }
        public BauvorhabenStatus Status { get; set; } = BauvorhabenStatus.AntragEingereicht;
        public List<Bauflaeche> ZugeordneteFlaechen { get; set; } = new List<Bauflaeche>();

        public void StatusAktualisieren(BauvorhabenStatus neuerStatus) => Status = neuerStatus;
    
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            // Demonstration der Funktionalität
            var grundstueck = new Grundstueck { FlurstueckNummer = "0015 00012 001/002" };
            var flaeche = new Bauflaeche 
            {
                Id = "F1", 
                Groesse = 500, 
                Lage = "Nordseite", 
                AktuelleNutzung = Nutzung.Brachflaeche, 
                Bebaubarkeit = "ja", 
                BPlanNummer = "BP-2022-089", 
                Bodenrichtwert = 500m, 
                Eigentuemer = "Max Mustermann"
            };
            grundstueck.Bauflaechen.Add(flaeche);

            var vorhaben = new Bauvorhaben
            {
                Titel = "Neubau Wohnhaus",
                Antragsteller = new Antragsteller { Name = "Erika Musterfrau", Firma = "Bau GmbH" },
                GeplanteNutzung = "Wohngebäude",
                Beginn = DateTime.Now.AddMonths(1),
                Fertigstellung = DateTime.Now.AddYears(1)
            };

            flaeche.FlaecheReservieren();
            vorhaben.ZugeordneteFlaechen.Add(flaeche);
            vorhaben.StatusAktualisieren(BauvorhabenStatus.Genehmigt);

            Console.WriteLine($"Bauvorhaben '{vorhaben.Titel}' für Fläche {flaeche.Id} ist nun {vorhaben.Status}.");
            Console.WriteLine($"Flächenstatus: {flaeche.Status}");
        }
    }
}