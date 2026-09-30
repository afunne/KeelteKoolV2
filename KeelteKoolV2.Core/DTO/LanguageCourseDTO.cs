namespace KeelteKoolV2.Core.DTO
{
    //Andmevahendusobjekt (DTO). See ei pea vastama andmebaasi nõuetele - selle eesmärk on
    //andmete üleandmine frontendi kontrolleri ja backendi teenuse vahel. Osad väljad võivad
    //olla valikulised (märgitud "?" märgiga), kuna service või kontroller saab vajadusel
    //ise midagi muuta või juurde lisada, millele lõppkasutajal ligipääsu olla ei tohiks.
    public class LanguageCourseDTO
    {
        public Guid? Id { get; set; }
        public string Nimetus { get; set; } = string.Empty;
        public string Keel { get; set; } = string.Empty;
        public string? Tase { get; set; }
        public string? Kirjeldus { get; set; }

        //Vajalikud andmeväljad, mida muudavad ainult kontroller ja/või service
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
