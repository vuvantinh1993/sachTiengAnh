import { Common } from 'src/app/_shared/extensions/common.service';
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

  public point = this.userService.currentPoint;
  public avatar = this.userService.currentAvatar;
  public fullName = this.userService.currentFullName;
  public namerank = this.userService.currentNamerank;
  public userName: any;
  constructor(
    private router: Router,
    private userService: UsersService
  ) { }

  async ngOnInit() {
    this.userService.getprofile();
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/user/login']);
  }

  isAdmin() {
    return this.userService.roleMatch(['Admin']);
  }

  ishowUserProfile() {
    Common.ChangeIshowUserProfile(0);
  }

}
