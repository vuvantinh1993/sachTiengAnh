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


  public usernameA: string;
  public userimage = localStorage.getItem('userimage');
  public userpoint = localStorage.getItem('userpoint');
  public userName: any;
  constructor(
    private router: Router,
    private userService: UsersService,
  ) { }

  async ngOnInit() {
    // this.userService.getprofile();
    console.log('usernameAaaaa', localStorage.getItem('fullName'));
    this.usernameA = localStorage.getItem('fullName');

    // this.userService.getprofile2().subscribe(data => {
    //   this.userName = data;
    //   console.log('dayladata', data);
    // });
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/user/login']);
  }

}
