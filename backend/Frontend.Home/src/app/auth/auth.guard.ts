import { UsersService } from './../_shared/services/User.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { debug } from 'util';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private userservice: UsersService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (localStorage.getItem('token') != null) {
      console.log('daylatoken');
      const roles = next.data.permittedRoles as Array<string>;
      if (roles) {
        if (this.userservice.roleMatch(roles)) {
          return true;
        } else {
          this.router.navigate(['/forbidden']);
        }
      }
      return true;
    } else {
      this.router.navigate(['/user/login']);
      return false;
    }
  }

}
