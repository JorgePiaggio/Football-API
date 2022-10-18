import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './feature/home-component/home-component.component';
import { NavbarComponent } from './feature/navbar/navbar.component';
import { TeamsComponent } from './feature/teams/teams.component';
import { CompetitionsComponent } from './feature/competitions/competitions.component';
import { AboutComponent } from './feature/about/about.component';
import { PlayersComponent } from './feature/players/players.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    TeamsComponent,
    CompetitionsComponent,
    AboutComponent,
    PlayersComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
