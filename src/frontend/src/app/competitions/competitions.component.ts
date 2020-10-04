import { Observable } from 'rxjs';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

import { Competition, CompetitionService } from '../api/index';

@Component({
  selector: 'app-competitions',
  templateUrl: './competitions.component.html',
  styleUrls: ['./competitions.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CompetitionsComponent implements OnInit {

  testCompetitions$: Observable<Competition[]>;

  constructor(private competitionService: CompetitionService) { }

  ngOnInit(): void {
    this.testCompetitions$ = this.competitionService.competitionsGet();
  }

}
