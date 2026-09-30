using System.ComponentModel.DataAnnotations;

namespace KeelteKoolV2.Models.LanguageCourses
{
    //ViewModel on vajalik kasutajale info kuvamiseks ja sealt edasi kontrollerile andmiseks.
    //ViewModel erineb DTO-objektist selle poolest, et kõik kasutajale mittevajalikud andmed
    //on sealt eemaldatud. Valikulised andmed, mida hiljem kasutajale näidatakse, jäävad alles.
    //See eraldatus tagab ka selle, et kasutaja ei saa pahatahtlikult soovimatutele andmetele ligi.
    public class LanguageCourseViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Nimetus { get; set; } = string.Empty;

        [Required]
        public string Keel { get; set; } = string.Empty;

        public string? Tase { get; set; }
        public string? Kirjeldus { get; set; }
    }
}
