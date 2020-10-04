import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { NavLink } from '../models/index';

@Injectable()
export class NavService {
  // State variables are hidden behind Observables to prevent outsiders from changing them
  public get sidenavExpanded$(): Observable<boolean> {
    return this.sidenavExpandedVal$.asObservable();
  }
  public get activeLink$(): Observable<NavLink> {
    return this.activeLinkVal$.asObservable();
  }

  private sidenavExpandedVal$ = new BehaviorSubject<boolean>(true);
  private activeLinkVal$ = new BehaviorSubject<NavLink>(this.getNavLinks()[0]);

  toggleSidenav(): void {
    this.sidenavExpandedVal$.next(!this.sidenavExpandedVal$.getValue());
  }

  setActiveLink(activeLink: NavLink): void {
    this.activeLinkVal$.next(activeLink);
  }

  getNavLinks(): NavLink[] {
    return [
      {
        name: 'Football Manager',
        route: '.',
      },
      {
        name: 'Root Ascendant',
        route: 'root-ascendant',
      },
    ];
  }
}
