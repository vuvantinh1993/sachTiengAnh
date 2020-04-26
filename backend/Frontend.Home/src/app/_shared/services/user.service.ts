import { Injectable } from '@angular/core';
import { BaseCrudService } from '../../_base/services/base-crud.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BindDataExtensionService } from '../extensions/bind-data-extension.service';
import { BehaviorSubject, concat, from, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService extends BaseCrudService<any> {
  baseUrl: string;
  public userinfo: any;
  private userSubject: BehaviorSubject<IUser | null> = new BehaviorSubject(null);

  constructor(
    http: HttpClient,
    bindDataExtensionService: BindDataExtensionService
  ) {
    super(http, bindDataExtensionService);
    this.baseUrl = 'ApplicationUser';
  }

  public register(body: any) {
    const api = this.http.post<any>(`${this.baseUrl}/register`, body);
    return this.bindDataExtensionService.bindResponseApi(api);
  }

  public login(body: any) {
    return this.http.post<any>(`${this.baseUrl}/login`, body);
    // return this.bindDataExtensionService.bindResponseApi(api);
  }

  public async getprofile() {
    console.log('token', localStorage.getItem('token'));
    this.http.get<any>(`${this.baseUrl}/GetProfile`).subscribe(
      res => {
        console.log('res', res);
        localStorage.setItem('fullName', res.fullName);
        localStorage.setItem('email', res.email);
      },
      err => {
        console.log('err', err);
      }
    );
  }

  public getprofile2(): Observable<IUser | null> {
    return this.http.get<any>(`${this.baseUrl}/GetProfile`);
  }

  roleMatch(allowedRoles): boolean {
    let isMatch = false;
    const payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
    const userRole = payLoad.role;
    allowedRoles.forEach(element => {
      if (userRole === element) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }
}


export interface IUser {
  sub: string;
  name: string;
  given_name: string;
  family_name: string;
  email: string;
  email_verified: boolean;
  phone_number: string;
  phone_number_verified: boolean;
  two_factor_enabled: boolean;
}
