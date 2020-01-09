import { Component, OnInit, AfterViewInit } from '@angular/core';
declare var App;

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
  providers: []
})

export class LayoutComponent implements OnInit, AfterViewInit {

  constructor() { }

  ngOnInit() {
    console.log('ngOnInit layout');
    App.initBeforeLoad();
    window.addEventListener('load', () => {
      console.log('load layout');
      App.initAfterLoad();
    });
  }

  ngAfterViewInit() {
    console.log('ngAfterViewInit layout');
    App.initCore();
  }

}
