import { CategoryFilmService } from './../../_shared/services/categoryfilm.service';
import { Component, OnInit, PipeTransform } from '@angular/core';
import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { Pipe } from '@angular/core';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent extends BaseListComponent implements OnInit {
  public data: any;
  Arr = Array;
  public datalist: any[];
  public finishload = false;
  constructor(
    private categoryFilmService: CategoryFilmService,

  ) { super(); }

  ngOnInit() {
    this.getData();
  }

  async getData(page = 1) {
    this.data = null;
    this.datalist = [null];
    this.listOfData = [];
    this.paging.page = page;

    // where theo du lieu dau vao
    const where = { and: [] };
    // tìm kiếm theo trạng thái

    if (where.and.length > 0) {
      this.paging.where = where;
    } else {
      delete this.paging.where;
    }
    this.isLoading = true;
    const rs = await this.categoryFilmService.get(this.paging);
    this.isLoading = false;
    if (rs.ok && rs.result) {
      this.data = rs.result.data;
    }
    if (this.data) {
      this.listOfData = this.data;
      this.paging = rs.result.paging;
    }
    this.finishload = true;
  }

}
