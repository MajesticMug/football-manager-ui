import { Observable, Subject } from 'rxjs';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { takeUntil, filter, map, switchMap } from 'rxjs/operators';

import { Player, PlayersService } from '../api/index';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PlayersComponent implements OnInit {
  players$: Observable<Player[]>;

  displayedColumns: string[] = [
    'id',
    'code',
    'name',
    'position',
    'dateOfBirth',
    'countryOfBirth',
    'nationality',
  ];

  private componentDestroyed$ = new Subject<void>();

  constructor(private route: ActivatedRoute, private playerService: PlayersService) { }

  ngOnInit(): void {
    this.players$ = this.route.paramMap
      .pipe(
        takeUntil(this.componentDestroyed$),
        filter((params) => params.has('teamCode')),
        map((params) => params.get('teamCode')),
        switchMap(teamCode => this.playerService.playersTeamCodeGet(teamCode))
      );
  }
}
