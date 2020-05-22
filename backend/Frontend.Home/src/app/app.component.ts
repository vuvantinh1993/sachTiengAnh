import { Component, OnInit, } from '@angular/core';
import { BaseListComponent } from './_base/components/base-list-component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent extends BaseListComponent implements OnInit {
  ngOnInit() {
  }
}
