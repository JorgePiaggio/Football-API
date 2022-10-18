import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Player } from '../../shared/models/player';
import { PlayerService } from '../../shared/services/playerService';
import { TeamService } from '../../shared/services/teamService';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {

  players: Player[];
  currentTeam: string = "";

  constructor(private playerService: PlayerService,
    private teamService: TeamService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.playerService.getPlayers(this.activatedRoute.snapshot.params['id']).subscribe(
      data => {
        this.players = Object.values(data);
        this.currentTeam = this.players[0].teamName;
      },
      error => {
        console.log(error)
      }
    );
  }


}
