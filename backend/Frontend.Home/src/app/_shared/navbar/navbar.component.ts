import { UsersService } from './../services/user.service';
import { Router } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
// import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  public avatar = localStorage.getItem('avatar') === 'undefined' ? null : localStorage.getItem('avatar');
  public userpoint = localStorage.getItem('userpoint');
  public fullName = localStorage.getItem('fullName');
  public point = localStorage.getItem('point');
  public namerank = localStorage.getItem('namerank');
  public userName: any;
  constructor(
    private router: Router,
    private userservice: UsersService
  ) { }

  async ngOnInit() {
    console.log('usernameAaaaa', localStorage.getItem('fullName'));
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/user/login']);
  }

  isAdmin() {
    return this.userservice.roleMatch(['Admin']);
  }

}
