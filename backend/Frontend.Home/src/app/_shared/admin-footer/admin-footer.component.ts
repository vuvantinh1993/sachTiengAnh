import { Component, OnInit, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-admin-footer',
  templateUrl: './admin-footer.component.html',
  styleUrls: ['./admin-footer.component.scss']
})
export class AdminFooterComponent implements OnInit, AfterViewInit {
  ngAfterViewInit(): void {
    console.log('afterviewInit admin-footer');
  }

  constructor() { }

  ngOnInit() {
  }

}
