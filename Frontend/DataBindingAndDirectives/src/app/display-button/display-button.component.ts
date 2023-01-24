import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-display-button',
  templateUrl: './display-button.component.html',
  styleUrls: ['./display-button.component.css'],
})
export class DisplayButtonComponent implements OnInit {
  para = 'Hello World!';
  showPara = true;
  actionNumbers: number[] = [];
  onShowHidePara() {
    this.showPara = !this.showPara;
    this.actionNumbers.push(this.actionNumbers.length + 1);
  }
  constructor() {}
  ngOnInit(): void {}
}
