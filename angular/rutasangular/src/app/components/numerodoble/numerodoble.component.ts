import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';

@Component({
  selector: 'app-numerodoble',
  templateUrl: './numerodoble.component.html',
  styleUrls: ['./numerodoble.component.css'],
})
export class NumerodobleComponent implements OnInit {
  public num!: number;
  public doble!: number;

  constructor(private route: ActivatedRoute, private router: Router) {}

  redirect(num: number) {
    this.router.navigate(['numerodoble', num]);
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      // Parseamos a número
      this.num = +params.get('num')!;
      this.doble = this.num * 2;
    });
  }
}
