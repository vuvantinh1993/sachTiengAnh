import { CategoryFilmService } from './../../_shared/services/categoryfilm.service';
import { WordFilmService } from './../../_shared/services/wordFilm.service';
import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-words-film',
  templateUrl: './list-words-film.component.html',
  styleUrls: ['./list-words-film.component.scss']
})
export class ListWordsFilmComponent extends BaseListComponent implements OnInit {

  public data: any;
  public dataCate: any[];
  public finishload = false;
  public isView = false;
  constructor(
    private wordFilmService: WordFilmService,
    private categoryFilmService: CategoryFilmService,
    private route: ActivatedRoute,
  ) {
    super();
  }

  ngOnInit() {
    this.getData();
  }

  async getData(page = 1) {
    this.data = null;
    this.listOfData = [];
    this.paging.page = page;
    this.paging.size = 24;

    // where theo du lieu dau vao
    const where = { and: [] };
    // tìm kiếm theo trạng thái
    where.and.push({ categoryfilmid: this.route.snapshot.paramMap.get('id') });

    if (where.and.length > 0) {
      this.paging.where = where;
    } else {
      delete this.paging.where;
    }
    this.isLoading = true;
    const rs = await this.wordFilmService.get(this.paging);
    const rsCate = await this.categoryFilmService.get({ where: { id: this.route.snapshot.paramMap.get('id') } });
    console.log(rsCate, rs);

    this.isLoading = false;
    if (rs.ok && rs.result) {
      this.data = rs.result.data;
      this.dataCate = rsCate.result.data;
      if (rs.result.data.length !== 0) {
        this.isView = true;
      }
    }
    if (this.data) {
      this.listOfData = this.data;
      this.paging = rs.result.paging;
    }
    this.finishload = true;
  }

}
