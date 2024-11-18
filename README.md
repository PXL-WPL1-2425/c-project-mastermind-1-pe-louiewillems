[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/ymni-nXt)
# Mastermind - PE 1


De eerste versie van het spel is gevalideerd door de spelcommissie en we hebben een GO gekregen om naar productie te brengen. Hiervoor moeten nog enkele kleine aanpassingen gebeuren.

- Het is nu niet echt mogelijk om het spel echt te spelen, want er is telkens maar 1 poging mogelijk. Dit gaan we uitbreiden zodat de speler meerdere pogingen heeft om de code te raden. Toon dit in de Windows titel in de vorm van "Poging x", waarbij x je huidige poging is.
- Momenteel wordt de gegenereerde code in de windows titel getoond, maar dit kan niet zo blijven. Voorzie daarom een TextBox waarin je deze code toont. De TextBox mag enkel in debug-mode getoond worden (CTRL-F12).
- Daarnaast moet je een timer voorzien die start van 1 en stopt bij 10. De timer start voor de eerste keer wanneer de code gegenereerd is, daarna telkens wanneer de speler een poging heeft gedaan (op de "Check code" knop heeft geklikt). De speler heeft dus 10 seconden tijd om een code in te geven. Wanneer dit niet binnen de tijd gebeurd verliest de speler automatisch een beurt.

Gebruik de namen die voorzien zijn in de functionele vereisten, maar **zorg ervoor dat je de naming conventions hierop toepast**!

### Functionele vereisten

| ID | Onderwerp | Beschrijving |
| :--- | :--- | :--- |
| Mastermind-PE1-01 | Pogingen | Zorg ervoor dat de speler meerdere pogingen kan doen om de code te kraken. Toon "Poging x" in de Windows titel. Voorzie een variabele *attempts* hiervoor. |
| Mastermind-PE1-02 | Debug-mode | Voorzie een TextBox waarin de gegenereerde code getoond wordt. Deze TextBox is enkel zichtbaar in debug-mode. De speler kan in debug-mode gaan door op CTRL-F12 te drukken. Maak een method *toggledebug* hiervoor aan. |
| Mastermind-PE1-03 | Timer start | Start de timer telkens opnieuw vanaf 1 wanneer de speler een poging heeft gedaan (op de "Check code" knop heeft geklikt) OF de eerste keer wanneer een code is gegenereerd. Gebruik de methode *startcountdown* hiervoor. |
| Mastermind-PE1-04 | Timer stop | De timer stopt na 10 seconden. Wanneer de speler **niet** binnen de tijd op de knop "Check code" klikt verliest hij zijn beurt. Gebruik de methode *stopcountdown* hiervoor. |
| Mastermind-PE1-05 | XML documentatie | Voorzie zinvolle XML summary documentatie voor de volgende onderdelen in je project: toggledebug, startcountdown en stopcountdown. |

**Veel succes!!**
