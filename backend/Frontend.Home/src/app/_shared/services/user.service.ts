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
  private pointSource = new BehaviorSubject(0);
  currentPoint = this.pointSource.asObservable();
  private fullNameSource = new BehaviorSubject('Tên người dùng');
  currentFullName = this.fullNameSource.asObservable();
  private userNameSource = new BehaviorSubject('UserName người dùng');
  currentUserName = this.userNameSource.asObservable();
  private emailSource = new BehaviorSubject('Email người dùng');
  currentEmail = this.emailSource.asObservable();
  private addressSource = new BehaviorSubject('Địa chỉ người dùng');
  currentAddress = this.addressSource.asObservable();
  private avatarSource = new BehaviorSubject
    ('https://cdns.iconmonstr.com/wp-content/assets/preview/2018/240/iconmonstr-user-circle-thin.png');
  currentAvatar = this.avatarSource.asObservable();
  private namerankSource = new BehaviorSubject('Rank người dùng');
  currentNamerank = this.namerankSource.asObservable();
  private starSource = new BehaviorSubject(1);
  currentStar = this.starSource.asObservable();
  private pointLeverNextSource = new BehaviorSubject(1);
  currentPointLeverNext = this.pointLeverNextSource.asObservable();


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

  public login(body: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/login`, body);
    // return this.bindDataExtensionService.bindResponseApi(api);
  }

  public getprofile(): Observable<any> {
    this.http.get<any>(`${this.baseUrl}/GetProfile`).subscribe(ress => {
      this.ChangeFullName(ress.fullName);
      this.ChangeEmail(ress.email);
      this.ChangeUserName(ress.userName);
      this.ChangeAddress(ress.address);
      this.ChangeAvatar(ress.avatar);
      this.ChangeNamerank(ress.namerank);
      this.ChangePoint(ress.point);
      this.ChangeStar(ress.star);
      this.ChangePointLeverNext(ress.pointLeverNext);
      // return 'ok';
    }, err => {
      console.log('err', err);
      // return 'notOk';
    }
    );
    return null;
  }

  ChangePoint(point: number) {
    this.pointSource.next(point);
  }
  ChangeFullName(fullName: string) {
    this.fullNameSource.next(fullName);
  }
  ChangeUserName(userName: string) {
    this.userNameSource.next(userName);
  }
  ChangeEmail(email: string) {
    this.emailSource.next(email);
  }
  ChangeStar(star: number) {
    this.starSource.next(star);
  }
  ChangeAddress(address: string) {
    address === undefined
      ? this.addressSource.next('Địa chỉ người dùng')
      : this.addressSource.next(address);
  }
  ChangeAvatar(avatar: string) {
    avatar === undefined ? this.avatarSource
      .next('https://cdns.iconmonstr.com/wp-content/assets/preview/2018/240/iconmonstr-user-circle-thin.png')
      : this.avatarSource.next(avatar);
  }
  ChangeNamerank(namerank: string) {
    this.namerankSource.next(namerank);
  }
  ChangePointLeverNext(pointLeverNext: number) {
    this.pointLeverNextSource.next(pointLeverNext);
  }

  roleMatch(allowedRoles): boolean {
    let isMatch = false;
    if (localStorage.getItem('token')) {
      const payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
      const userRole = payLoad.role;
      allowedRoles.forEach(element => {
        if (userRole === element) {

          isMatch = true;
          return false;
        }
      });
    }
    return isMatch;
  }
}
