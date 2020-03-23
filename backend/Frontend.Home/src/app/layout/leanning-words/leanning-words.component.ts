import { ExtensionService } from './../../_base/services/extension.service';
import { ExtentionTableService } from './../../_base/services/extention-table.service';
import { ExtraoneService } from './../../_shared/services/extraone.service';
import { Component, OnInit } from '@angular/core';
import { async } from '@angular/core/testing';
import { Observable, timer } from 'rxjs';
import { take, map } from 'rxjs/operators';
import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { debug } from 'util';

@Component({
  selector: 'app-leanning-words',
  templateUrl: './leanning-words.component.html',
  styleUrls: ['./leanning-words.component.scss']
})
export class LeanningWordsComponent extends BaseListComponent implements OnInit {

  public extran: string;
  public finishload = false;
  public totalSentenceRight = 0;
  public SentenceIsTrue = true;
  public counter = 100;
  public data: any;
  public datalist: any[];
  public item: any;
  public listAnswer: any[];
  public answerWrongEn: string;
  public answerWrongVn: string;
  public wordNumber = 0;
  public listStatus: any[] = [
    { id: 0, name: 'Ẩn' },
    { id: 1, name: 'Hiện' }
  ];
  urlSafe: SafeResourceUrl;
  public abs: number = -1;
  public intervalId = null;
  constructor(
    private extraoneService: ExtraoneService,
    public sanitizer: DomSanitizer,
    public exTableService: ExtentionTableService,
    private ex: ExtensionService, ) {
    super();
  }

  ngOnInit() {
    this.getData();
    this.countdown();
  }

  countdown() {
    this.intervalId = setInterval(() => {
      this.extran = this.counter + '%';
      this.counter = this.counter - 0.1;
      if (this.counter === 0) { clearInterval(this.intervalId); }
    }, 10);
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
    const rs = await this.extraoneService.get(this.paging);
    console.log('Get tai lieu', rs.result);
    this.isLoading = false;
    if (rs.ok && rs.result) {
      this.data = rs.result.data;
      let i = 0;
      this.data.forEach(x => {
        this.answerWrongEn = x.answerWrongEn.split(' *** ');
        this.answerWrongVn = x.answerWrongVn.split(' *** ');
        const listanswerVn = this.getAnswer(this.answerWrongVn, x.textVn);
        const listanswerEn = this.getAnswer(this.answerWrongEn, x.textEn);
        const urlaudio = this.sanitizer.bypassSecurityTrustResourceUrl(x.urlaudio);
        this.datalist[i] = { listanswerVn, listanswerEn, urlaudio };
        i++;
      });
    }
    console.log('this.listOfData', this.datalist);
    console.log(this.datalist[0].listanswerVn.result[0]);


    if (this.data) {
      this.listOfData = this.data;
      this.paging = rs.result.paging;
    }
    this.finishload = true;
  }

  // input mảng dữ liệu sai và 1 sting đúng
  // return mảng 4 phần tử và vị trí nhần tử đúng
  getAnswer(sourceArray, stringRight: string) {
    const randomInFour = Math.floor(Math.random() * 4);
    const result = [];
    const checkInFour = [];
    const checkInSource = [];
    checkInFour.push(randomInFour);
    result[randomInFour] = stringRight; // lấy ngẫu nhiên 1 số trong 4 số và push string đúng vào
    const key = randomInFour;
    for (let i = 0; i < 4; i++) {
      if (!checkInFour.includes(i)) {
        let randomInSource = Math.floor(Math.random() * sourceArray.length);
        while (checkInSource.includes(randomInSource)) {
          randomInSource = Math.floor(Math.random() * sourceArray.length);
        }
        checkInSource.push(randomInSource);
        checkInFour.push(randomInFour);
        result[i] = sourceArray[randomInSource];
      }
    }
    return { result, key };
  }

  kiemtraketqua(target, key) {
    this.abs = target.value;
    console.log(target);
    if (+target.value === key) {
      console.log('giá trị đúng');
      clearInterval(this.intervalId);
      setTimeout(() => {
        this.counter = 100;
        this.countdown();
      }, 1000);
      target.checked = false;
      if (this.SentenceIsTrue) {
        this.totalSentenceRight++;
      }
      this.SentenceIsTrue = true;
      console.log(this.totalSentenceRight);
      setTimeout(() => { this.wordNumber++ }, 1000);
    } else {
      this.SentenceIsTrue = false;

      console.log('giá trị sai');
    }
    setTimeout(() => { this.abs = -1 }, 1000);
  }

  isCheck(num, key) {
    let check = '';
    if (num === key) {
      console.log('giá trị đúng');
      check = 'fa-check  text-success';
    } else {
      check = 'fa-times  text-danger';
    }
    return check;
  }
}
