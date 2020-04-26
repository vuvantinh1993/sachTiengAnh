import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent extends BaseListComponent implements OnInit {

  constructor() { super(); }

  ngOnInit() {
  }

}
