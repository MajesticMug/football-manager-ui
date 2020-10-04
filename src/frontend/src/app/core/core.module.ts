import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';

import { BASE_PATH } from '../api/index';
import { environment } from './../../environments/environment';
import {
  FooterComponent,
  NavComponent,
  SidebarComponent,
  TopBarComponent,
  NavService,
} from './components/index';

@NgModule({
  declarations: [
    NavComponent,
    SidebarComponent,
    TopBarComponent,
    FooterComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MatButtonModule,
    MatIconModule,
    MatToolbarModule,
    MatListModule,
    MatSidenavModule,
    RouterModule,
  ],
  exports: [NavComponent],
  providers: [
    NavService,
    { provide: BASE_PATH, useValue: environment.footballApiBasePath },
  ],
})
export class CoreModule {}
