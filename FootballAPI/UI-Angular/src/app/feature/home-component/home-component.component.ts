import { Component, OnInit } from '@angular/core';
import { CompetitionService } from '../../shared/services/competitionService';
import { TeamService } from '../../shared/services/teamService';

@Component({
  selector: 'app-home-component',
  templateUrl: './home-component.component.html',
  styleUrls: ['./home-component.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private competitionService: CompetitionService, private teamService: TeamService) { }

  ngOnInit() {
    this.competitionService.loadCompetitions().subscribe(
      data => {
        this.teamService.loadTeams().subscribe();
      }
    );
  }

}
