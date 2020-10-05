import { ChangeDetectionStrategy, Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BehaviorSubject } from 'rxjs';
import { finalize } from 'rxjs/operators';

import { DataImportsService } from '../api/index';

@Component({
  selector: 'app-import-league',
  templateUrl: './import-league.component.html',
  styleUrls: ['./import-league.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ImportLeagueComponent {
  leagueCodeControl = new FormControl(null, Validators.required);

  loading$ = new BehaviorSubject<boolean>(false);

  constructor(private dataImportsService: DataImportsService, private snackBar: MatSnackBar) {}

  importLeague(): void {
    this.loading$.next(true);

    this.dataImportsService
      .importLeagueLeagueCodePost(this.leagueCodeControl.value)
      .pipe(finalize(() => this.loading$.next(false)))
      .subscribe(
        () => this.snackBar.open('League Imported!', 'Close'),
        (response) => {this.snackBar.open(response?.error?.Message || 'Error Importing League', 'Close')}
      );
  }
}
