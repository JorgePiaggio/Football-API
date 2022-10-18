import { Component, OnInit } from '@angular/core';
import { Competition } from '../../shared/models/competition';
import { CompetitionService } from '../../shared/services/competitionService';

@Component({
  selector: 'app-competitions',
  templateUrl: './competitions.component.html',
  styleUrls: ['./competitions.component.css']
})
export class CompetitionsComponent implements OnInit {

  competitions: Competition[];
  constructor(private competitionService: CompetitionService) { }

  ngOnInit() {
    this.competitionService.getTeams().subscribe(
      data => {
        this.competitions = Object.values(data);
      },
      error => {
        console.log(error) }
     );
  }

}
