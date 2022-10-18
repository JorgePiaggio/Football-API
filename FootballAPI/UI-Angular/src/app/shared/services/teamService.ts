import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Team } from '../models/team';

const httpOption = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
}
const apiUrl: string = "https://localhost:44327/api/teams/"

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  constructor(private http: HttpClient) { }

  loadTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(apiUrl + "getRandomTeams");
  }

  getTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(apiUrl);
  }

  getTeam(id: number): Observable<Team> {
    return this.http.get<Team>(apiUrl + id);
  }

}
