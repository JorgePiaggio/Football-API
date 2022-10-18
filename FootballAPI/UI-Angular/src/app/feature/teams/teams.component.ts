import { Component, OnInit } from '@angular/core';
import { Team } from '../../shared/models/team';
import { TeamService } from '../../shared/services/teamService';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  teams: Team[];

  constructor(private teamService: TeamService) { }

  ngOnInit() {
    this.teamService.getTeams().subscribe(
      data => {
        this.teams = Object.values(data);
      },
      error => {
        console.log(error)
      }
    );
  }

}
