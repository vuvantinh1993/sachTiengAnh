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

  public numberdown = 10;

  counter$: Observable<number>;
  count = 60;

  constructor() {
    this.counter$ = timer(0, 1000).pipe(
      take(this.count),
      map(() => --this.count)
    );
  }

  ngOnInit() {
    this.countdown();
  }

  countdown() {
    for (let i = this.numberdown; i > 0; i--) {
      console.log('đâsdasda');
      setTimeout(() => {
        let a = this.count;
        console.log('this.numver', a);
      }, 2000);
    }
  }
}
