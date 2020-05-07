import { Router } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
// import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-admin-navbar',
  templateUrl: './admin-navbar.component.html',
  styleUrls: ['./admin-navbar.component.scss']
})
export class AdminNavbarComponent implements OnInit {
  public userName: Observable<string>;
  constructor(
    private router: Router,
  ) { }

  ngOnInit() {
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/user/login']);
  }

}
