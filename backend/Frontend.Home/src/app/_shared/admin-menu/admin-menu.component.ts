import { Component, OnInit, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-admin-menu',
  templateUrl: './admin-menu.component.html',
  styleUrls: ['./admin-menu.component.scss']
})
export class AdminMenuComponent implements OnInit, AfterViewInit {
  ngAfterViewInit(): void {
    console.log('afterview menu');
  }

  constructor() { }

  ngOnInit() {
  }

}
