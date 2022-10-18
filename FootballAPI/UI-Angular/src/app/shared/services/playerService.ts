import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Player } from '../models/player';

const httpOption = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
}
const apiUrl: string = "https://localhost:44327/api/players/teamplayers"

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  constructor(private http: HttpClient) { }

  getPlayers(teamId: number): Observable<Player[]> {
    return this.http.get<Player[]>(apiUrl + "?id=" + teamId);
  }

}
