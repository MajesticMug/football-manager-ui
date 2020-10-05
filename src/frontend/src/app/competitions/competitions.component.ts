import { Observable } from 'rxjs';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Competition, CompetitionService } from '../api/index';

@Component({
  selector: 'app-competitions',
  templateUrl: './competitions.component.html',
  styleUrls: ['./competitions.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CompetitionsComponent implements OnInit {
  competitions$: Observable<Competition[]>;
  displayedColumns: string[] = ['id', 'code', 'name', 'areaName', 'actions'];

  constructor(private competitionService: CompetitionService, private router: Router) {}

  ngOnInit(): void {
    this.competitions$ = this.competitionService.competitionsGet();
  }

  viewTeam(leagueCode: string): void {
    this.router.navigate([`/teams/${leagueCode}`]);
  }
}
