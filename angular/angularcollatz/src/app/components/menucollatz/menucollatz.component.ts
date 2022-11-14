import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menucollatz',
  templateUrl: './menucollatz.component.html',
  styleUrls: ['./menucollatz.component.css'],
})
export class MenucollatzComponent implements OnInit {
  public numbers: Array<number>;

  constructor() {
    this.numbers = [];
  }

  ngOnInit(): void {
    for (let i = 0; i < 10; i++) {
      this.numbers.push(Math.floor(Math.random() * 100));
    }
  }
}
