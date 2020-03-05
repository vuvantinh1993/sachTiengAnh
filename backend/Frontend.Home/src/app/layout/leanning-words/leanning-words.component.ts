import { Component, OnInit } from '@angular/core';
import { async } from '@angular/core/testing';
import { Observable, timer } from 'rxjs';
import { take, map } from 'rxjs/operators';

@Component({
  selector: 'app-leanning-words',
  templateUrl: './leanning-words.component.html',
  styleUrls: ['./leanning-words.component.scss']
})
export class LeanningWordsComponent implements OnInit {

  public extran: string;
  public counter = 102;

  constructor() {

  }

  ngOnInit() {
    this.countdown();
  }

  countdown() {
    const intervalId = setInterval(() => {
      this.counter = this.counter - 2;
      this.extran = this.counter + '%';
      console.log(this.extran);

      if (this.counter === 0) { clearInterval(intervalId); }
    }, 200);
  }
}
