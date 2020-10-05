import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CompetitionsComponent } from './competitions/index';
import { ImportLeagueComponent } from './import-league/index';
import { PlayersComponent } from './players/index';
import { TeamsComponent } from './teams/index';

const routes: Routes = [
  {
    path: '',
    component: CompetitionsComponent
  },
  {
    path: 'teams',
    component: TeamsComponent
  },
  {
    path: 'teams/:leagueCode',
    component: TeamsComponent
  },
  {
    path: 'players/:teamCode',
    component: PlayersComponent
  },
  {
    path: 'import-league',
    component: ImportLeagueComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
