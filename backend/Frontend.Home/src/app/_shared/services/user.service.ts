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
    this.baseUrl = 'User';
  }

  public updateWordlened(idfilm: number, sttWord: number, totalSentenceRight: number) {
    const api = this.http.get<any>(`${this.baseUrl}/updateWordlened/${idfilm}/${sttWord}/${totalSentenceRight}`);
    return this.bindDataExtensionService.bindResponseApi(api);
  }
}
