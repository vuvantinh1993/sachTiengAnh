import { ExtensionService } from './../../_base/services/extension.service';
import { ExtentionTableService } from './../../_base/services/extention-table.service';
import { ExtraoneService } from './../../_shared/services/extraone.service';
import { Component, OnInit } from '@angular/core';
import { async } from '@angular/core/testing';
import { Observable, timer } from 'rxjs';
import { take, map } from 'rxjs/operators';
import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { debug } from 'util';

@Component({
  selector: 'app-leanning-words',
  templateUrl: './leanning-words.component.html',
  styleUrls: ['./leanning-words.component.scss']
})
export class LeanningWordsComponent extends BaseListComponent implements OnInit {

  public extran: string;
  public counter = 102;
  public data: any;
  public item: any;
  public listAnswer: any[];
  public answerWrongEn: string;
  public answerWrongVn: string;
  public listStatus: any[] = [
    { id: 0, name: 'Ẩn' },
    { id: 1, name: 'Hiện' }
  ];

  constructor(
    private extraoneService: ExtraoneService,
    public exTableService: ExtentionTableService,
    private ex: ExtensionService, ) {
    super();
  }

  ngOnInit() {
    this.getData();
  }

  countdown() {
    const intervalId = setInterval(() => {
      this.counter = this.counter - 2;
      this.extran = this.counter + '%';
      console.log(this.extran);

      if (this.counter === 0) { clearInterval(intervalId); }
    }, 200);
  }


  async getData(page = 1) {
    this.data = null;
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
      this.data.forEach(x => {
        this.answerWrongEn = x.answerWrongEn.split(' *** ');
        const randomWrongEn = this.answerWrongEn[Math.floor(Math.random() * this.answerWrongEn.length)];
        this.answerWrongVn = x.answerWrongVn.split(' *** ');
        const threeanswerWrongEn = this.getMeRandomElements(this.answerWrongEn, 3); // lấy 3 đáp án sai
        const rs = this.pushValueRight(threeanswerWrongEn, x.textEn);
        console.log(this.answerWrongEn);
      });
      if (this.data) {
        this.listOfData = this.data;
        this.paging = rs.result.paging;
      }
    }
  }

  getMeRandomElements(sourceArray, neededElements) {
    const result = [];
    const check = [];
    let numberRandom = Math.floor(Math.random() * sourceArray.length);
    for (let i = 0; i < neededElements; i++) {
      while (check.includes(numberRandom)) {
        numberRandom = Math.floor(Math.random() * sourceArray.length);
      }
      check.push(numberRandom);
      result.push(sourceArray[numberRandom]);
    }
    console.log('result', result);

    return result;
  }

  pushValueRight(source, stringRight: string) {
    const position = 0;
    const result = [];
    let c = 0;
    const numberRandom = Math.floor(Math.random() * 4);
    result[numberRandom] = stringRight;
    for (let i = 0; i < 4; i++) {
      if (i !== numberRandom) {
        result[i] = source[c];
        c++;
      }
    }

    console.log('mang cam tin', result, numberRandom, stringRight);
    return [result, numberRandom];
  }
}
