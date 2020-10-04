import { ChangeDetectionStrategy, Component } from '@angular/core';

import { NavService } from '../services/index';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TopBarComponent {
  constructor(public navService: NavService) {}
}
