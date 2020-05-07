import { ExtensionService } from './../../_base/services/extension.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { ExtraoneService } from 'src/app/_shared/services/extraone.service';
import { UsersService } from 'src/app/_shared/services/user.service';

@Component({
  selector: 'app-finish-cours',
  templateUrl: './finish-cours.component.html',
  styleUrls: ['./finish-cours.component.scss']
})
export class FinishCoursComponent extends BaseListComponent implements OnInit {


  public avatar: string;
  public fullName: string;
  public point: string;
  public namerank: string;
  public address: string;
  public star: number;

  public startYeelow: any;
  public startnon: any;

  public finishload = false;
  public data: any;
  public datalist: any[];
  public sttWordLenning: number;
  public idfilm = +this.route.snapshot.paramMap.get('idfilm');
  public totalPointRight = +this.route.snapshot.paramMap.get('point');
  public intervalId = null;
  public num: number;
  public show: number;
  constructor(
    private route: ActivatedRoute,
    private extraoneService: ExtraoneService,
    public ex: ExtensionService,
    private router: Router,
    public userService: UsersService,
  ) {
    super();
  }

  async ngOnInit() {
    await this.getprofile();
    this.getData();
    setTimeout(() => {
      if (this.num !== 0) {
        this.countdown();
        const widthpoint = document.getElementById('point').offsetWidth;
        document.getElementById('point').style.left = `calc(50% - ${widthpoint / 2}px)`;
      }
    }, 900);
  }

  getprofile() {
    this.userService.getprofile().subscribe(
      ress => {
        console.log('res', ress);
        localStorage.setItem('fullName', ress.fullName);
        localStorage.setItem('email', ress.email);
        localStorage.setItem('userName', ress.userName);
        localStorage.setItem('address', ress.address);
        localStorage.setItem('avatar', ress.avatar);
        localStorage.setItem('point', ress.point);
        localStorage.setItem('namerank', ress.namerank);
        localStorage.setItem('star', ress.star);
        this.avatar = localStorage.getItem('avatar');
        this.fullName = localStorage.getItem('fullName');
        this.point = localStorage.getItem('point');
        this.namerank = localStorage.getItem('namerank');
        this.address = localStorage.getItem('address');
        this.star = +localStorage.getItem('star');
        this.startYeelow = Array(this.star).fill(4);
        this.startnon = Array(5 - this.star).fill(4);

        this.num = +this.totalPointRight;
        this.show = +this.point - this.num;
      },
      err => {
        console.log('err', err);
      }
    );
  }

  countdown() {
    this.intervalId = setInterval(() => {
      this.num = this.num - 1;
      this.show = this.show + 1;
      if (this.num <= 0) { clearInterval(this.intervalId); }
    }, 1);
  }

  async getData(page = null) {
    console.log(page);

    this.data = null;
    this.datalist = [null];
    this.listOfData = [];

    this.sttWordLenning = +localStorage.getItem('sttWordLenning') - 1;
    console.log('this.sttWordLenning', this.sttWordLenning);

    if (!page) {
      this.paging.page = (Math.floor((this.sttWordLenning - 1) / 12) + 1) > 1 ? (Math.floor((this.sttWordLenning - 1) / 12) + 1) : 1;
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
    if (i >= this.sttWordLenning + 1) {
      return 'contentb';
    } else {
      return 'contenta';
    }
  }

  che(i: number) {
    if (i > this.sttWordLenning) {
      return 'che2';
    } else if (i === this.sttWordLenning) {
      return 'che1';
    } else {
      return '';
    }
  }
}
