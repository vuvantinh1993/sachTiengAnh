import { Injectable } from '@angular/core';
import { BaseCrudService } from '../../_base/services/base-crud.service';
import { HttpClient } from '@angular/common/http';
import { BindDataExtensionService } from '../extensions/bind-data-extension.service';
@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseCrudService<any> {
  baseUrl: string;

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

}
