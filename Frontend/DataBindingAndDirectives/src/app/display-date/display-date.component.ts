import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-display-date',
  templateUrl: './display-date.component.html',
  styleUrls: ['./display-date.component.css']
})
export class DisplayDateComponent implements OnInit {
  para = 'Hello World!';
  showPara = true;
  actionNumbers: Date[] = [];
  onShowHidePara() {
    this.showPara = !this.showPara;
    this.actionNumbers.push(new Date());
  }
  constructor() { }

  ngOnInit(): void {
  }

}
