import { MatButtonModule } from '@angular/material/button';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/index';
import { SharedModule } from './shared/index';
import { CompetitionsComponent } from './competitions/index';
import { TeamsComponent } from './teams/index';
import { PlayersComponent } from './players/index';
import { ImportLeagueComponent } from './import-league/index';


@NgModule({
  declarations: [
    AppComponent,
    CompetitionsComponent,
    TeamsComponent,
    PlayersComponent,
    ImportLeagueComponent,
  ],
  imports: [
    BrowserModule,
    CoreModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatFormFieldModule,
    MatProgressSpinnerModule,
    MatButtonModule,
    MatTableModule,
    MatSelectModule,
    MatSnackBarModule,
    SharedModule,
    AppRoutingModule, /* Keep last */
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
