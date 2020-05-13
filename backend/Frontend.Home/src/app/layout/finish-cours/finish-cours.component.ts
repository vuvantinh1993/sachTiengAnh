import { ExtensionService } from './../../_base/services/extension.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { ExtraoneService } from 'src/app/_shared/services/extraone.service';
import { UsersService } from 'src/app/_shared/services/user.service';
import { Common } from 'src/app/_shared/extensions/common.service';

@Component({
  selector: 'app-finish-cours',
  templateUrl: './finish-cours.component.html',
  styleUrls: ['./finish-cours.component.scss']
})
export class FinishCoursComponent extends BaseListComponent implements OnInit {


  public avatar = this.userService.currentAvatar;
  public fullName = this.userService.currentFullName;
  public namerank = this.userService.currentNamerank;
  public address = this.userService.currentAddress;

  public a = +this.route.snapshot.paramMap.get('idfilm');

  public startYeelow: any;
  public startnon: any;
  public pointNeedForNextLever: number;

  public finishload = Common.currentOpenComponentViewFinish;
  public data: any;
  public datalist: any[];
  public sttWordLenningComponent: number;
  public idfilmComponent: any;
  // public idfilmComponent = +this.route.snapshot.paramMap.get('idfilm');
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
    // lấy thông tin tìa khoản và add dữ liệu vao biến
    this.userService.getprofile();
    this.userService.currentStar.subscribe(ress => {
      this.startYeelow = Array(ress).fill(4);
      this.startnon = Array(5 - ress).fill(4);
    }, err => {
      console.log('err', err);
    });

    this.userService.currentPointLeverNext.subscribe(ress => {
      this.userService.currentPoint.subscribe(ress2 => {
        this.num = +this.totalPointRight;
        this.show = +ress2 - this.num;
        this.pointNeedForNextLever = ress - ress2;
      });
    });

    Common.ChangeidFilm(+this.route.snapshot.paramMap.get('idfilm'));
    this.getData();
    setTimeout(() => {
      if (this.num !== 0) {
        this.countdown();
        const widthpoint = document.getElementById('point').offsetWidth;
        document.getElementById('point').style.left = `calc(50% - ${widthpoint / 2}px)`;
      }
    }, 900);
  }

  countdown() {
    this.intervalId = setInterval(() => {
      this.num = this.num - 1;
      this.show = this.show + 1;
      if (this.num <= 0) { clearInterval(this.intervalId); }
    }, 1);
  }

  async getData(page = null) {
    this.data = null;
    this.datalist = [null];
    this.listOfData = [];

    Common.currentSttWord.subscribe(e => {
      this.sttWordLenningComponent = e - 1;
    })
    if (!page) {
      this.paging.page = (Math.floor((this.sttWordLenningComponent - 1) / 12) + 1) > 1 ? (Math.floor((this.sttWordLenningComponent - 1) / 12) + 1) : 1;
    } else {
      this.paging.page = page;
    }
    this.paging.size = 12;
    // where theo du lieu dau vao
    const where = { and: [] };
    where.and.push({ categoryfilmid: this.idfilmComponent });
    if (where.and.length > 0) {
      this.paging.where = where;
    } else {
      delete this.paging.where;
    }
    const rs = await this.extraoneService.get(this.paging);
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

  OpenTooltips(event) {
    const tooltipSpan = document.getElementById('tooltip-span');
    tooltipSpan.style.top = (event.clientY - 30) + 'px';
    tooltipSpan.style.left = (event.clientX + 10) + 'px';
  }
}
