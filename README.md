# ISAProjekat23


<h3>Projekat iz predmeta Internet Softverske Arhitekture za škol.god. 2023/24.</h3>

<h4>Dino Brdar RA143/2011</h4>
<br><br>

<b>Korišćene tehnologije</b>
<br>Frontend: .NET Blazor + Bootstrap v5.3
<br>Backend: .NET Core
<br>Baza podataka: MySQL
<br><br>

Za pokretanje programa neophodno je imati instaliran Visual Studio (preporučljivo verziju 2022) i MySQL Server i Workbench.

~Branch koji je za pregledanje se zove ```AddAppointment```.~ EDIT: U međuvremenu sam video obaveštenje na formi za prijavu da sve mora biti na jednoj grani, tako da sam rešio problem koji je postojao na ```master``` grani, a ```AddAppointment``` branch je uklonjen.

~MySQL skripta za dodavanje test vrednosti u bazu će biti naknadno dodata.~ EDIT: SQL fajl za insert test podataka se nalazi u ```ISAProjekat23.Database/TestDataSQL/test.sql```
<br><br>

<strong>NAPOMENA</strong>: Par komitova koji su se desili nakon 31.1. su bili iz sledećih razloga:
1. Slučajno paste-ovan sadržaj ```AddAppointment``` brancha u ```master```, pa je došlo do dosta grešaka koje sam otkrio tek sutradan. Samo sam obrisao ponovo uradio clean paste i to je rešilo problem.
2. Slučajno komitovane stare migracije, što je pravilo problem pri ažuriranju baze. Samo sam obrisao stare da stavim nove.
3. Dodat SQL fajl sa test podacima i ažuriran README.md fajl.

Naglašavam da cilj nijednog od komitova nakon 31.1. nije bio radi dodatnih funkcionalnosti, već samo radi ispravke greške nastale pri spajanju grana i slanja pogrešnih migracionih fajlova za bazu.
<br><br>

Program se pokreće pokretanjem dveju projekata unutar solutiona: ```ISAProjekat2023.Server``` (backend) i ```ISAProjekat2023.Client``` (frontend), a prethodno je neophodno primeniti migraciju komandom ```Update-Database``` unutar Package Manager Console.

Konekcioni string za bazu je ```server=localhost;port=3306;database=ISAProjekat;Uid=root;Pwd=asd123```

