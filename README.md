# Labb2-ITHS

Labb 2 – Objektorienterad programmering
Uppgift
Uppgiften är att skapa ett program som simulerar ett kök där det går att
använda, lägga till och lista köksapparater.
[1-17], [19] och [21-23] = Övergripande krav
[18] och [20] = Absoluta krav
Skapa ett program som:
Huvudmeny
- Skriver ut en huvudmeny innehållande ett antal val (1. Använd
köksapparat 2. Lägg till köksapparat 3. Lista köksapparater 4. Ta bort
köksapparat 5. Avsluta). [1]
- Låter användaren ange ett val i huvudmenyn och läser in valet. [2]
Val 1. Använd köksapparat
- Skriver ut en undermeny. [3]
- Låter användaren ange ett val i undermenyn för att välja köksapparat
och läser in valet. [4]
- Skriver ut ett meddelande om att köksapparaten är trasig om den är
trasig. Annars ska ett meddelande skrivas ut om att köksapparaten
används. [5]
- Går tillbaka till huvudmenyn. [6]
Val 2. Lägg till köksapparat
- Låter användaren mata in typ, märke och skick (t.ex. ”Våffeljärn”,
”Electrolux”, ”j”). [7] Om användaren matar in ett litet j betyder det att
köksapparaten fungerar. Annars om användaren matar in ett litet n
betyder det att köksapparaten är trasig. [8]
- Lagrar köksapparaten i en lista och skriver ut ett meddelande om att
köksapparaten har lagts till. [9]
- Går tillbaka till huvudmenyn. [10]
Val 3. Lista köksapparater
- Skriver ut en lista över alla köksapparater (inklusive alla som har lagts
till). I listan ska typ, märke och skick skrivas ut. [11]
- Går tillbaka till huvudmenyn. [12]
Val 4. Ta bort köksapparat
- Skriver ut en numrerad lista över alla köksapparater. [13]
- Låter användaren ange vilken köksapparat som ska tas bort och läser in
valet. [14]
- Tar bort köksapparat från listan över lagrade köksapparater och skriver
ut ett meddelande om att köksapparaten har tagits bort. [15]
- Går tillbaka till huvudmenyn. [16]
Val 5
- Avslutar huvudmenyn. [17]
Övrigt:
- När programmet startar ska det finnas ett antal köksapparater lagrade i
en lista redo att användas. [18]
- Programmet ska felhantera all inmatning. [19]