import { Injectable } from '@angular/core';
import { BaseCrudService } from '../../_base/services/base-crud.service';
import { HttpClient } from '@angular/common/http';
import { BindDataExtensionService } from '../extensions/bind-data-extension.service';
@Injectable({
  providedIn: 'root'
})
export class WordFilmService extends BaseCrudService<any> {
  baseUrl: string;

  constructor(
    http: HttpClient,
    bindDataExtensionService: BindDataExtensionService
  ) {
    super(http, bindDataExtensionService);
    this.baseUrl = 'WordFilm';
  }

  public addFeedBackWord(body: any) {
    const api = this.http.post<any>(`${this.baseUrl}/AddFeedBackWord`, body);
    return this.bindDataExtensionService.bindResponseApi(api);
  }
}
