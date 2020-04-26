import { UsersService } from './../services/User.service';
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


  public usernameA = localStorage.getItem('fullName');
  public userimage = localStorage.getItem('userimage');
  public userpoint = localStorage.getItem('userpoint');
  // public userName: Observable<string>;
  constructor(
    private router: Router,
    private userService: UsersService,
  ) { }

  ngOnInit() {
    // this.username = this.userService.getprofile().pipe(map(u => u && u.name));
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/user/login']);
  }

}
