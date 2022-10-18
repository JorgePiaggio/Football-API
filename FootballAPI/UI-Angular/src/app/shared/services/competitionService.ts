import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Competition } from '../models/competition';

const httpOption = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
}
const apiUrl: string = "https://localhost:44327/api/competitions/"

@Injectable({
  providedIn: 'root'
})
export class CompetitionService {

  constructor(private http: HttpClient) { }

  loadCompetitions(): Observable<Competition[]> {
    return this.http.get<Competition[]>("https://localhost:44327/api/competitions/getapi");
  }

  getTeams(): Observable<Competition[]> {
    return this.http.get<Competition[]>(apiUrl);
  }

  getTeam(id: number) {
    return this.http.get<Competition>(apiUrl + id);
  }

}
