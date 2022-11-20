import { Component, OnInit } from '@angular/core';
import { Serie } from 'src/app/models/serie';
import { SeriesService } from 'src/app/services/series.service';
import { Plantilla } from 'src/app/models/plantilla';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
})
export class MenuComponent implements OnInit {
  public series!: Serie[];
  public user!: any;

  constructor(
    private seriesService: SeriesService,
    private authService: AuthService
  ) {}

  loadSeries(): void {
    this.seriesService.getSeries().subscribe((res) => (this.series = res));
  }

  logout(): void {
    this.authService.logout();
    this.authService.checkUser().then((user) => {
      if (user) this.user = user;
    });
  }

  ngOnInit(): void {
    this.loadSeries();
    this.authService.checkUser().then((user) => {
      if (user) this.user = user;
    });
  }
}
