# Consumables V2  
  
In deze applicatie gaan we "Consumables" bijhouden.    
Consumables kunnen     
 * ofwel drank zijn (Beverage)  
 * ofwel eten zijn (Food)  

Zowel drank als eten hebben een aantal gemeenschappelijke eigenschappen : id, omschrijving, verpakking, prijs per verpakking  
Bij drank houden we eveneens bij of het alcoholisch is.  
Bij voeding houden we een gezondheidslabel bij.  

<img src="/assets/demo.gif">
  
## Class Library    
 * Maak een class library aan met de naam Pra.Consumables.Core
 * Maak 3 mapjes aan binnen je class library :  
   * Entities  
   * Enums  
   * Services   
 * Binnen Enums maak je de enumeratie **HealthLabel** aan met de waarden : A, B, C, D en E    
 * Binnen Entities maak je 3 klassen aan :  
   * **Consumable**   
     Dit zal straks de basisklasse zijn voor **Beverage** en **Food**.  
     Deze klasse heeft de volgende eigenschappen :  
     * **Id** : type = Guid, readonly (enkel vanuit de constructor kan hier een waarde aan toegekend worden)  
     * **Discription** : type = string, null of lege waarden worden vervangen door "onbekend"  
     * **Unit** : type = string  
     * **PricePerUnit** : type decimal, waarden die kleiner zijn dan 0 worden omgezet naar 0
     
     De klasse heeft 1 constructor die omschrijving, prijs per eenheid, eenheid en id ontvangt.  Eenheid is optioneel en krijgt de standaardwaarde null.  Id is optioneel en krijgt de standaardwaarde null.  
     Indien id de waarde null heeft, dan zorg je er voor dat in de constructor hier een GUID waarde aan gegeven wordt.
     
     De klasse overschrijft tenslotte de ToString methode en toont bv het volgende "Ei : €0.5/stuk"

   * **Food**  
     Deze klasse erft over van Consumable.  
     Er is 1 bijkomende eigenschap :  
     * **HealthLabel** : type enumeratie HealthLabel   
        
     Je zorgt voor een aangepaste constructor die de nodige waarden aan de basisklasse doorgeeft en de eigenschap HealthLabel kan vullen.   
    
     Bij de ToString methode gebruik je het resultaat van de basisklasse maar voegt daar op een volgende lijn en na een insprong (\n\t) nog eens het gezondheidslabel aan toe.  
     
   * **Beverage**  
     Deze klasse erft eveneens over van Consumable.  
     Er is 1 bijkomende eigenschap :  
     * **IsAlcoholic** : type bool  
  
     Je zorgt voor een aangepaste constructor die de nodige waarden aan de basisklasse doorgeeft en de eigenschap IsAlcoholic kan vullen.   
     Opgepast : de constructor ontvangt het argument unit niet.  Bij een beverage is een unit altijd "cl."    
  
     Bij de ToString methode gebruik je het resultaat van de basisklasse maar je laat het voorafgaan door een sterretje, bv "* Whiskey : €4/cl."
       
 * Binnen Services maak je 1 klasse aan :  **ConsumableService**  
   Deze klasse beschikt over 1 eigenschap : **Consumables**.  Dit is een readonly collectie en geeft een gesorteerd overzicht (op description) van al onze consumables.   
   De klasse heeft een argumentloze constroctur die bij instantiering testgegevens aanmaakt voor ons.   
   Enkele testgegevens :  
    * Appel, 0.15, A, stuk  
    * Ei, 0.3, C, stuk  
    * Boter, 16, C, kg  
    * Pils, 0.1, bevat alcohol  
    * Whiskey, 3, bevat alcohol  
    * Water, 0.08, bevat geen alcohol  
  
   Daarnaast bevat deze klasse ook nog over 2 methoden (**Delete** en **Insert**) die respectievelijk een Consumable verwijderen of toevoegen aan de collectie.

## WPF

In je WPF zijn alle controls en event-handlers reeds aanwezig.    
Bestudeer wat je gekregen hebt aandachtig.    
De bedoeling mag duidelijk zijn :   
 * Bij opstart verschijnen de reeds aanwezige consumables in de lijst.   
 * Klik je op een consumable, dan verschijnen aan de rechterkant de detailgegevens.  Opgepast : Food wordt iets anders afgebeeld dan Beverage.  Je moet dus te weten komen welk soort van consumable je selecteerde in de lijst!   
 * Wanneer je klikt op btnNewFood die je er voor te zorgen dat je een nieuw food-object kunt aanmaken.  Klik je op btnNewBeverage, dan zorg je er uiteraard voor dat een nieuw beverage-object kan aangemaakt worden.    
 * Wanneer je klikt op btnEdit dan moet je er voor zorgen dat ofwel het geselecteerde food-object, ofwel het geselecteerde beverage-object kan aangepast worden.    
 * Wanneer je op btnDelete klikt, dan moet je de geselecteerde consumable verwijderen uit de collectie.  
 * Wanneer je op btnSave klikt, dan dien je uiteraard te weten waarmee je bezig bent.  Gaat het om een nieuwe consumable of ga je een bestaande wijzigen?    
   Als je een nieuwe consumable aanmaakt ga je uiteraard ook nog moeten weten of het over Food of Beverage gaat ...    
