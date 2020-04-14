import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { ExtraoneService } from 'src/app/_shared/services/extraone.service';

@Component({
  selector: 'app-finish-cours',
  templateUrl: './finish-cours.component.html',
  styleUrls: ['./finish-cours.component.scss']
})
export class FinishCoursComponent extends BaseListComponent implements OnInit {


  public usernameA = localStorage.getItem('usernameA');
  public userimage = localStorage.getItem('userimage');
  public userpoint = localStorage.getItem('userpoint');
  public useraddress = localStorage.getItem('useraddress');


  public finishload = false;
  public data: any;
  public datalist: any[];
  public idfilm = +this.route.snapshot.paramMap.get('idfilm');
  public sttword: number;
  public intervalId = null;
  public num = 78;
  public show = +this.userpoint;
  constructor(
    private route: ActivatedRoute,
    private extraoneService: ExtraoneService,
  ) {
    super();
  }

  ngOnInit() {
    this.getData();
    setTimeout(() => {
      this.countdown();
    }, 900);
  }

  countdown() {
    this.intervalId = setInterval(() => {
      this.num = this.num - 1;
      this.show = this.show + 1;
      if (this.num === 0) { clearInterval(this.intervalId); }
    }, 1);
  }

  async getData(page = null) {
    console.log(page);

    this.data = null;
    this.datalist = [null];
    this.listOfData = [];

    this.sttword = +this.route.snapshot.paramMap.get('sttword');
    if (!page) {
      this.paging.page = Math.floor(this.sttword / 12) + 1;
    } else {
      this.paging.page = page;
    }
    this.paging.size = 12;
    // where theo du lieu dau vao
    const where = { and: [] };
    where.and.push({ categoryfilmid: this.idfilm });
    if (where.and.length > 0) {
      this.paging.where = where;
    } else {
      delete this.paging.where;
    }
    // tslint:disable-next-line: max-line-length
    console.log(this.paging);

    const rs = await this.extraoneService.get(this.paging);
    console.log('Get tai lieu', rs.result);
    if (rs.ok && rs.result && (rs.result.data.length !== 0)) {
      this.data = rs.result.data;
      // lấy số từ đã hoc
      console.log('this.data', this.data);
    }
    if (this.data) {
      this.listOfData = this.data;
      this.paging = rs.result.paging;
      this.finishload = true;
    }
  }

  checkclass(i: number) {
    if (i >= this.sttword) {
      return 'contentb';
    } else {
      return 'contenta';
    }
  }

  che(i: number) {
    if (i > this.sttword - 1) {
      return 'che2';
    } else if (i === this.sttword - 1) {
      return 'che1';
    } else {
      return '';
    }
  }
}
