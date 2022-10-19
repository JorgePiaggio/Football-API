<h1>Football API</h1>

<h5>How To</h5>

1) Clone project</br>

2) Generate local SQL Server DB</br>
In Visual Studio Tools -> NuGet Package Manager -> Package Manager Console</br>
<code>PM> Update-Database</code>

3) Run BackEnd</br>
Add your token from <a href="https://www.football-data.org/">Football-Data</a> to ApiService class</br>
In Visual Studio, run project 'FootballAPI'</br>

4) Run FrontEnd</br>
Open cmd, navigate to project folder, and run the following commands</br>
<code>..\FootballAPI\UI-Angular\src> npm install</code></br>
<code>..\FootballAPI\UI-Angular\src> ng serve</code>

5) Access the app in your navigator</br>
Go to: localhost:4200
