import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { UsersService } from './../_shared/services/user.service';
import { User } from 'oidc-client';
import { Component, OnInit, AfterViewInit } from '@angular/core';
declare var App;

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
  providers: []
})

export class LayoutComponent implements OnInit, AfterViewInit {

  public userName: Observable<string>;
  public userinfora: any;
  constructor(
    private userService: UsersService,
  ) { }

  ngOnInit() {
    App.initBeforeLoad();
    window.addEventListener('load', () => {
      App.initAfterLoad();
    });
  }

  ngAfterViewInit() {
    App.initCore();
  }


}
