import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.less']
})
export class FooterComponent implements OnInit {

  fullDate: Date = new Date();
  year: number = 0;

  constructor() { }

  ngOnInit(): void {
    this.year = this.fullDate.getFullYear();
  }

}
