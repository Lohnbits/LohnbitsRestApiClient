# Lohnbits API

Dieses Projekt dient als Dokumentation und Hilfestellung um mit der Lohnbits API zu kommunizieren. Neben der in diesem Dokument bereitgestellten Dokumentation und der 
[OpenApi-Spezifikation](https://github.com/Lohnbits/LohnbitsRestApiClient/blob/master/OpenApi/LohnbitsOpenApi.json), enthält dieses Repository noch eine .NET Konsolenapplikation, 
welche die Verwendung der Lohnbits API demonstriert.

## Inhalt
* [Schnellstart](#schnellstart)
* [Authentifizierung](#authentifizierung)
	* [Benutzername, Passwort, Einmalkennwort](#benutzername-passwort-einmalkennwort)
	* [Benutzername, Passwort, AES-Key](#benutzername-passwort-aes-key)
* [Einmalpasswort generieren](#einmalpasswort-generieren)
* [Endpunkte](#endpunkte)

## Schnellstart
Sofern nicht installiert, installiere bitte [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) um die Demo-App verwenden zu können.

Klone das Repository
```bash
git clone https://github.com/Lohnbits/LohnbitsRestApiClient.git
```

Ersetze die Platzhalter in CredentialProvider.cs mit deinen Zugangsdaten
```C#
private const string Username = "<Lohnbits-Benutzername hier eintragen>";
private const string Password = "<Lohnbits-Password hier eintragen>";
private const string AesKey = "<Lohnbits-AES-Key hier eintragen>";
```

Führe die Demo-App in der Konsole aus
```bash
dotnet run
```


## Authentifizierung
Um mit die einzelnen Funktionen der Lohnbits API verwenden zu können, benötigt man zuerst einen JWT welcher vom Server nach einer erfolgreichen Authentifizierung zur Verfügung
gestellt wird. Die Verwendung des JWT erfolgt nach dem Bearer-Schema und wird wie im folgenden Beispiel verwendet.
```
Authorization: Bearer <lohnbits-access-token>
```

Für die Authentifizierung stehen 2 Vorgänge zur Wahl. 
* Benutzername, Passwort, Einmalpasswort
* Benutzername, Passwort, AES-Key

Beider Verfahren werden in den folgenden Abschnitten näher erklärt.

### Benutzername, Passwort Einmalkennwort
Bei diesem Verfahren werden neben dem Benutzernamen und dem Passwort noch ein zweiter Faktor in Form eines 30 Sekunden gültigen Einmalkennworts abgefragt. Hierzu muss der erhaltene
Lohnbits-QR-Code in einer frei wählbaren Authenticator App (z.B. Google Authenticator, Microsoft Authenticator, etc.) eingescannt werden. Die daraufhin generierten Einmalkennwörter
kann danach für dieses Authentifizierungsverfahren verwendet werden.

```C#
var loginRequest = new LoginOtpRequest(credentials.Username, credentials.Password, totp);
var loginResult = WebApiBase.RequestPost<LoginOtpResult>("loginOtp", "", loginRequest);
var token = loginResult?.Token ?? "";
```

### Benutzername, Passwort, AES-Key
Dieses Verfahren nutzt neben dem Benutzernamen und Passwort einen AES-Key. Dieser Key wird benötigt um den verschlüsselten JWT, welcher nach einer erfolgreichen
Authentifizierung zurückgeliefert wird, zu entschlüsseln. Daher ist es wichtig, diesen Key nur Systemen zu speichern, welche diesen sicher aufbewahremn können.

```C#
var aesKeyBytes = Convert.FromBase64String(credentials.AesKey!);

// Anmeldung bei LOHNBITS mit Benutzername, Passwort und Erhalt des verschlüsselten Bearer Tokens
var loginRequest = new LoginEncryptedRequest(credentials.Username, credentials.Password);
var loginResult = WebApiBase.RequestPost<LoginEncryptedResult>("loginEncrypted", loginRequest);
var encryptedBearerToken = loginResult?.EncryptedToken ?? "";
var token = ModelHelper.DecryptStringAES(encryptedBearerToken, aesKeyBytes);
```

[ModelHelper.cs](https://github.com/Lohnbits/LohnbitsRestApiClient/blob/master/Model/ModelHelper.cs) demonstriert mit welchem Verfahren der JWT mithilfe des AES-Keys entschlüsselt werden kann.

## Einmalpasswort generieren
Bei den Einmalpasswörtern handelt es sich um Time-Base One-Time Password oder kurz TOTP [RFC 6238](https://datatracker.ietf.org/doc/html/rfc6238). 
Sollte der Bedarf bestehen, diese Passwörter eigentständig zu generieren, muss der Alorithmus wie er IETF-Dokument beschrieben ist implementiert werden.
Wir empfehlen die Verwendung von etablierten und gepflegten Bibliotheken für diesen Vorgang. Die folgende Liste enthält einige bekannte Bibliotheken für 
unterschiedliche Umgebungen.
* .NET - [Otp.NET](https://github.com/kspearrin/Otp.NET)
* JAVA - [java-totp](https://github.com/samdjstevens/java-totp)
* JavaScript/TypeScript - [totp-generator](https://github.com/bellstrand/totp-generator)
* Python - [PyOTP](https://github.com/pyauth/pyotp)
* PHP - [TwoFactorAuth](https://github.com/RobThree/TwoFactorAuth)

## Endpunkte
Die Dokumentation der einzelnen Endpunkte kann in der [OpenApi-Spezifikation](https://github.com/Lohnbits/LohnbitsRestApiClient/blob/master/OpenApi/LohnbitsOpenApi.json) 
nachgelesen werden.

Folgende Beispiele werden in der Demo-App gezeigt.
* Autentifizierung mit beiden Verfahren
* Die Erstellung und Bearbeitung einer Monatsdatenerfassung
* Auswertungen erstellen
* Mitarbeiterabwesenheiten abfragen
* Dokument in die Personalakte hochladen
* Dokument in den Posteingang hochladen

_Hinweis: Einige Endpunkte verwenden **POST** obwohl diese zur Abfrage von Daten verwendet werden. Diese Endpunkte verwenden einen Http Request Body und um eventuelle Warnungen 
einiger Tools, Frameworks etc. zu verhinden, haben wir die Entscheidung getroffen für diese Endpunkte ebenfalls **POST** anstatt **GET** zu verwenden._ 
