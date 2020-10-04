import { AfterViewInit, HostListener, OnInit } from '@angular/core';
import {
  Component,
  ViewChild,
  OnDestroy,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
} from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { NavLink } from '../models/index';
import { NavService } from '../services/index';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SidebarComponent implements OnInit, AfterViewInit, OnDestroy {
  navLinks: NavLink[] = [];
  activeLink$: Observable<NavLink>;

  @ViewChild(MatSidenav) sideNav: MatSidenav;

  private componentDestroyed$ = new Subject<void>();

  constructor(private navService: NavService, private cd: ChangeDetectorRef) {
    this.navLinks = navService.getNavLinks();

    this.activeLink$ = navService.activeLink$;
  }

  ngOnInit(): void {
    // Hook the sideNav expanded state with the navService state
    this.navService.sidenavExpanded$
      .pipe(takeUntil(this.componentDestroyed$))
      .subscribe((sidenavOpen) => {
        this.sideNav?.toggle(sidenavOpen);
        this.cd.markForCheck();
      });
  }

  setActiveLink(clickedLink: NavLink): void {
    this.navService.setActiveLink(clickedLink);
  }

  ngAfterViewInit(): void {
    this.sideNav.toggle(true);
  }

  // Auto close SideNav on smaller screens
  @HostListener('window:resize', ['$event'])
  onResize(event): void {
    if (event.target.innerWidth <= 800) {
      this.sideNav.close();
    } else {
      this.sideNav.open();
    }
  }

  ngOnDestroy(): void {
    // Unsubscribe from the observables to prevent memory leaks
    this.componentDestroyed$.next();
    this.componentDestroyed$.complete();
  }
}
