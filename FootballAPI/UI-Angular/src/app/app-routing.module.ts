import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutComponent } from './feature/about/about.component';
import { CompetitionsComponent } from './feature/competitions/competitions.component';
import { HomeComponent } from './feature/home-component/home-component.component';
import { PlayersComponent } from './feature/players/players.component';
import { TeamsComponent } from './feature/teams/teams.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'competitions',
    component: CompetitionsComponent
  },
  {
    path: 'teams',
    component: TeamsComponent
  },
  {
    path: 'players/:id',
    component: PlayersComponent
  },
  {
    path: 'about',
    component: AboutComponent
  },
  {
    path: '**',
    redirectTo: 'home' 
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
