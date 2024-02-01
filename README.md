# ISAProjekat23


Projekat iz predmeta Internet Softverske Arhitekture za škol.god. 2023/24.

Dino Brdar RA143/2011


Korišćene tehnologije:
Frontend: .NET Blazor + Bootstrap v5.3
Backend: .NET Core
Baza podataka: MySQL

Za pokretanje programa neophodno je imati instaliran Visual Studio (preporučljivo verziju 2022) i MySQL Server i Workbench.

~Branch koji je za pregledanje se zove ```AddAppointment```.~ EDIT: U međuvremenu sam video obaveštenje na formi za prijavu da sve mora biti na jednoj grani, tako da sam rešio problem koji je postojao na ```master``` grani, a AddAppointment branch je uklonjen.

MySQL skripta za dodavanje test vrednosti u bazu će biti naknadno dodata. EDIT: SQL fajl za insert test podataka se nalazi u ```ISAProjekat23.Database/TestDataSQL/test.sql```

Program se pokreće pokretanjem dveju projekata unutar solutiona: ```ISAProjekat2023.Server``` (backend) i ```ISAProjekat2023.Client``` (frontend), a prethodno je neophodno primeniti migraciju komandom ```Update-Database``` unutar Package Manager Console.

Konekcioni string za bazu je ```server=localhost;port=3306;database=ISAProjekat;Uid=root;Pwd=asd123```
