import { ExtensionService } from './../../_base/services/extension.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { WordFilmService } from 'src/app/_shared/services/wordFilm.service';
import { UsersService } from 'src/app/_shared/services/user.service';
import { Common } from 'src/app/_shared/extensions/common.service';

@Component({
  selector: 'app-finish-cours',
  templateUrl: './finish-cours.component.html',
  styleUrls: ['./finish-cours.component.scss']
})
export class FinishCoursComponent extends BaseListComponent implements OnInit {

  public isShowProfileUser = Common.currentOpenComponentViewFinish;
  public data: any;
  public datalist: any[];
  public sttWordLenningComponent: number;
  public idfilmComponent = +this.route.snapshot.paramMap.get('idfilm');
  constructor(
    private route: ActivatedRoute,
    private wordFilmService: WordFilmService,
    public ex: ExtensionService,
    private router: Router,
    public userService: UsersService,
  ) {
    super();
  }

  async ngOnInit() {

    Common.ChangeIshowUserProfile(+this.route.snapshot.paramMap.get('idfilm'));
    this.getData();
  }



  async getData(page = null) {
    this.data = null;
    this.datalist = [null];
    this.listOfData = [];

    this.sttWordLenningComponent = +localStorage.getItem('sttWordLenning') - 1;
    // Common.currentSttWord.subscribe(e => {
    //   this.sttWordLenningComponent = e - 1;
    // })
    if (!page) {
      this.paging.page = (Math.floor((this.sttWordLenningComponent - 1) / 12) + 1) > 1
        ? (Math.floor((this.sttWordLenningComponent - 1) / 12) + 1) : 1;
    } else {
      this.paging.page = page;
    }
    this.paging.size = 12;
    // where theo du lieu dau vao
    const where = { and: [] };
    where.and.push({ categoryfilmid: this.idfilmComponent });

    console.log('where', where);


    if (where.and.length > 0) {
      this.paging.where = where;
    } else {
      delete this.paging.where;
    }
    const rs = await this.wordFilmService.get(this.paging);
    if (rs.ok && rs.result && (rs.result.data.length !== 0)) {
      this.data = rs.result.data;
      // lấy số từ đã hoc

    }
    if (this.data) {
      this.listOfData = this.data;
      this.paging = rs.result.paging;
    }
  }

  checkclass(i: number) {
    if (i >= this.sttWordLenningComponent + 1) {
      return 'contentb';
    } else {
      return 'contenta';
    }
  }

  che(i: number) {
    if (i > this.sttWordLenningComponent) {
      return 'che2';
    } else if (i === this.sttWordLenningComponent) {
      return 'che1';
    } else {
      return '';
    }
  }
}
