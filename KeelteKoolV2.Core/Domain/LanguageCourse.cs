namespace KeelteKoolV2.Core.Domain
{
    //Domain kaustas olev mudel näitab täpset andmekuju, millena kursuse andmeid andmebaasis
    //hoitakse. Siin võib samuti olla valikulisi välju, kuid tüüpiliselt on neid vähem,
    //sest andmebaas hoiab tihtipeale ainult vajalikke andmeid.
    public class LanguageCourse
    {
        public Guid Id { get; set; }
        public string Nimetus { get; set; } = string.Empty;
        public string Keel { get; set; } = string.Empty;
        public string Tase { get; set; } = string.Empty;
        public string Kirjeldus { get; set; } = string.Empty;

        //Vajalikud andmeväljad, mida muudavad ainult kontroller ja/või service
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
