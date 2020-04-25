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
    console.log('ngOnInit layout');
    App.initBeforeLoad();
    window.addEventListener('load', () => {
      console.log('load layout');
      App.initAfterLoad();
    });
    this.userService.getprofile();
    // this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
  }

  ngAfterViewInit() {
    console.log('ngAfterViewInit layout');
    App.initCore();
  }

  // async getfindOneById() {
  //   this.userService.getprofile().subscribe(
  //     res => {
  //       console.log('res', res);
  //       this.userinfora = res;
  //       localStorage.setItem('fullName', res.fullName);
  //       localStorage.setItem('email', res.email);
  //     },
  //     err => {
  //       console.log('err', err);
  //     }
  //   );
  //   // if (rs.ok) {
  //   //   this.userinfora = rs.result;
  //   //   localStorage.setItem('usernameA', rs.result.name);
  //   //   localStorage.setItem('userpoint', rs.result.point);
  //   //   localStorage.setItem('userimage', rs.result.image);
  //   //   localStorage.setItem('useraddress', rs.result.address);
  //   // }
  // }
}
