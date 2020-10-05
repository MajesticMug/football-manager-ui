import { filter, map, share, switchMap, takeUntil, tap } from 'rxjs/operators';
import { Observable, ReplaySubject, Subject } from 'rxjs';
import {
  ChangeDetectionStrategy,
  Component,
  OnDestroy,
  OnInit,
} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl } from '@angular/forms';

import {
  Competition,
  CompetitionService,
  Team,
  TeamsService,
} from '../api/index';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TeamsComponent implements OnInit, OnDestroy {
  teams$: Observable<Team[]>;

  competitions$: Observable<Competition[]>;

  selectedLeagueCode = new FormControl();
  selectedLeagueCodeValue$ = new ReplaySubject<string>();

  displayedColumns: string[] = [
    'id',
    'code',
    'name',
    'shortName',
    'tla',
    'email',
    'areaName',
    'actions',
  ];

  private componentDestroyed$ = new Subject<void>();

  constructor(
    private teamService: TeamsService,
    private competitionService: CompetitionService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    // Competition list for league code selector
    this.competitions$ = this.competitionService.competitionsGet();

    // Hook teams observable to selectedLeagueCode
    this.selectedLeagueCode.valueChanges
      .pipe(takeUntil(this.componentDestroyed$))
      .subscribe((leagueCode) =>
        this.selectedLeagueCodeValue$.next(leagueCode)
      );

    this.teams$ = this.selectedLeagueCodeValue$.pipe(
      switchMap((leagueCode) => this.teamService.teamsLeagueCodeGet(leagueCode))
    );

    // If we have leagueCode as a parameter, set the selectedLeagueCode value
    this.route.paramMap
      .pipe(
        takeUntil(this.componentDestroyed$),
        filter((params) => params.has('leagueCode')),
        map((params) => params.get('leagueCode'))
      )
      .subscribe((leagueCode) => this.selectedLeagueCode.setValue(leagueCode));
  }

  viewPlayers(teamCode: string): void {
    this.router.navigate([`/players/${teamCode}`]);
  }

  ngOnDestroy(): void {
    this.componentDestroyed$.next();
    this.componentDestroyed$.complete();
  }
}
