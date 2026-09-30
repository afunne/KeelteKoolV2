# KeelteKoolV2

Keelekooli rakendus (ASP.NET Core MVC, .NET 10) aine **Tarkvarasüsteemide testimine** jaoks.

## Projektid

| Projekt | Sisu |
|---|---|
| `KeelteKoolV2` | MVC veebirakendus: kontrollerid, vaated, ViewModelid |
| `KeelteKoolV2.Core` | Domain mudelid, DTO-d, teenuste liidesed |
| `KeelteKoolV2.Data` | `KeelteKoolV2Context` (EF Core + Identity) ja migratsioonid |
| `KeelteKoolV2.ApplicationServices` | Teenuste implementatsioonid (`EmailingServices`, `LanguageCoursesServices`) |
| `KeelteKoolV2.xUnitTesting` | xUnit testid, `TestBase` (DI + InMemory andmebaas) |

## Harud

- `main` – projekti põhi (lahendus + paketid)
- `ahead` – arendus: Identity, kontod, emailid, keelekursuste moodul ja testid

## Käivitamine

```powershell
# andmebaas (LocalDB)
dotnet ef database update --project KeelteKoolV2.Data --startup-project KeelteKoolV2

# emaili seaded (ei lähe gitti)
dotnet user-secrets set "EmailHost" "smtp.gmail.com" --project KeelteKoolV2
dotnet user-secrets set "EmailUserName" "sinu.email@gmail.com" --project KeelteKoolV2
dotnet user-secrets set "EmailPassword" "rakenduse-parool" --project KeelteKoolV2

# rakendus
dotnet run --project KeelteKoolV2

# testid
dotnet test
```

## Testid

`LanguageCoursesServicesTests.Should_AddNewCourse_WhenResultIsReturned` **ebaõnnestub praegu meelega**
(TDD – punane samm): `LanguageCoursesServices.Create` tagastab veel `null`. Järgmine samm on
`Create` meetodi sisu kirjutamine, et test läheks roheliseks.
