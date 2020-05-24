import { trigger, transition, query, stagger, style, animate } from '@angular/animations';
import { Component, OnInit, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
  animations: [
    trigger('menuAnimation', [
      transition('* => *', [
        query('div', style({ transform: 'translateX(-50%)', opacity: 0 })),
        query('div',
          stagger('0ms', [
            animate('1000ms', style({ transform: 'translateX(0)', opacity: 1 }))
          ]))
      ])
    ])
  ]
})
export class MenuComponent implements OnInit, AfterViewInit {
  ngAfterViewInit(): void {
  }

  constructor() { }

  ngOnInit() {
  }

}
