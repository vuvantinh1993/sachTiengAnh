import { map } from 'rxjs/operators';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Observable } from 'rxjs';
import { UserService } from './../_shared/services/user.service';
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
    private userService: UserService,
    private authorizeService: AuthorizeService
  ) { }

  ngOnInit() {
    console.log('ngOnInit layout');
    App.initBeforeLoad();
    window.addEventListener('load', () => {
      console.log('load layout');
      App.initAfterLoad();
    });
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.getfindOneById();
  }

  ngAfterViewInit() {
    console.log('ngAfterViewInit layout');
    App.initCore();
  }

  async getfindOneById() {
    const rs = await this.userService.findOneById(100014);
    if (rs.ok) {
      this.userinfora = rs.result;
      localStorage.setItem('usernameA', rs.result.name);
      localStorage.setItem('userpoint', rs.result.point);
      localStorage.setItem('userimage', rs.result.image);
      localStorage.setItem('useraddress', rs.result.address);
    }
  }
}
