import { UsersService } from './../_shared/services/user.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private userservice: UsersService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if ((localStorage.getItem('token') != null) && (localStorage.getItem('token').match(/\./g).length === 2)) {
      const roles = next.data.permittedRoles as Array<string>;
      if (roles) {
        if (this.userservice.roleMatch(roles)) {
          return true;
        } else {
          this.router.navigate(['/home']);
        }
      }
      return true;
    } else {
      localStorage.clear();
      this.router.navigate(['/user/login']);
      return false;
    }
  }

}
