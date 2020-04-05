import { UserService } from './../../_shared/services/user.service';
import { ActivatedRoute } from '@angular/router';
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
import { NzMessageService } from 'ng-zorro-antd';

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
  public sttWordLenning: number;
  public idfilm: number;
  public listStatus: any[] = [
    { id: 0, name: 'Ẩn' },
    { id: 1, name: 'Hiện' }
  ];
  urlSafe: SafeResourceUrl;
  public abs: number = -1;
  public intervalId = null;
  constructor(
    private extraoneService: ExtraoneService,
    private route: ActivatedRoute,
    public sanitizer: DomSanitizer,
    public exTableService: ExtentionTableService,
    private userService: UserService,
    private message: NzMessageService,
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
    const datalist2 = null;
    this.listOfData = [];
    this.paging.page = page;

    // where theo du lieu dau vao
    const where = { and: [] };
    if (where.and.length > 0) {
      this.paging.where = where;
    } else {
      delete this.paging.where;
    }
    this.isLoading = true;
    this.idfilm = +this.route.snapshot.paramMap.get('idfilm');
    const rs = await this.extraoneService.getWords(this.idfilm);
    console.log('Get tai lieu', rs.result);
    this.isLoading = false;
    if (rs.ok && rs.result && (rs.result.data.length !== 0)) {
      this.data = rs.result.data;
      this.sttWordLenning = this.data.sttWord;
      this.data = this.data.data;
      console.log('this.data', this.data);
      this.datalist = this.tron10Cau(this.sttWordLenning); // dùng để biến sour lấy về thành 10 câu rồi trộn 10 câu
    }
    if (this.data) {
      this.finishload = true;
    }
  }

  // dùng để trộn các câu theo lịch trình
  tron10Cau(sttWord) {
    let listda = [];

    if (sttWord > 2) {
      for (const [key, value] of Object.entries(this.data)) {
        if (key === '0') {
          const list = this.laySoCauTheoTu(value, 0, 3);
          listda = list;
        }
        if (key === '1') {
          const list = this.laySoCauTheoTu(value, 0, 2);
          listda = listda.concat(list);
        }
        if (key === '2') {
          const list = this.laySoCauTheoTu(value, 2, 0);
          listda = listda.concat(list);
        }
        if (key === '3') {
          const list = this.laySoCauTheoTu(value, 2, 0);
          listda = listda.concat(list);
        }
        if (key === '4') {
          const list = this.laySoCauTheoTu(value, 1, 0);
          listda = listda.concat(list);
          console.log('listda', listda);
        }
      }
    } else if (sttWord === 2) {
      for (const [key, value] of Object.entries(this.data)) {
        if (key === '0') {
          const list = this.laySoCauTheoTu(value, 0, 3);
          listda = list;
        }
        if (key === '1') {
          const list = this.laySoCauTheoTu(value, 0, 2);
          listda = listda.concat(list);
        }
        if (key === '2') {
          const list = this.laySoCauTheoTu(value, 1, 1);
          listda = listda.concat(list);
        }
        if (key === '3') {
          const list = this.laySoCauTheoTu(value, 2, 0);
          listda = listda.concat(list);
        }
        if (key === '4') {
          const list = this.laySoCauTheoTu(value, 1, 0);
          listda = listda.concat(list);
          console.log('listda', listda);
        }
      }
    } else if (sttWord === 1) {
      for (const [key, value] of Object.entries(this.data)) {
        if (key === '0') {
          const list = this.laySoCauTheoTu(value, 0, 3);
          listda = list;
        }
        if (key === '1') {
          const list = this.laySoCauTheoTu(value, 0, 2);
          listda = listda.concat(list);
        }
        if (key === '2') {
          const list = this.laySoCauTheoTu(value, 2, 0);
          listda = listda.concat(list);
        }
        if (key === '3') {
          const list = this.laySoCauTheoTu(value, 2, 0);
          listda = listda.concat(list);
          console.log('tinh', listda);
        }
        if (key === '4') {
          const list = this.laySoCauTheoTu(value, 1, 0);
          listda = listda.concat(list);
          console.log('listda', listda);
        }
      }
    } else if (sttWord === 0) {
      for (const [key, value] of Object.entries(this.data)) {
        if (key === '0') {
          const list = this.laySoCauTheoTu(value, 1, 2);
          listda = list;
        }
        if (key === '1') {
          const list = this.laySoCauTheoTu(value, 3, 0);
          listda = listda.concat(list);
        }
        if (key === '2') {
          const list = this.laySoCauTheoTu(value, 2, 0);
          listda = listda.concat(list);
        }
        if (key === '3') {
          const list = this.laySoCauTheoTu(value, 1, 0);
          listda = listda.concat(list);
          console.log('tinh', listda);
        }
        if (key === '4') {
          const list = this.laySoCauTheoTu(value, 1, 0);
          listda = listda.concat(list);
          console.log('listda', listda);
        }
      }
    } else if (sttWord === -1) {
      for (const [key, value] of Object.entries(this.data)) {
        if (key === '0') {
          const list = this.laySoCauTheoTu(value, 4, 0);
          listda = list;
        }
        if (key === '1') {
          const list = this.laySoCauTheoTu(value, 3, 0);
          listda = listda.concat(list);
        }
        if (key === '2') {
          const list = this.laySoCauTheoTu(value, 2, 0);
          listda = listda.concat(list);
        }
        if (key === '3') {
          const list = this.laySoCauTheoTu(value, 1, 0);
          listda = listda.concat(list);
          console.log('tinh', listda);
        }
      }
    }
    console.log('listda', listda);
    listda = this.tronMang(listda);
    console.log('listda', this.tronMang(listda));
    return listda;
  }

  /// Chuyển câu số x thành n câu đúng (trong đó có n câu tiếng Anh, y câu tiếng việt)
  /// trả về mảng câu theo ý muốn
  laySoCauTheoTu(sour: any, numberEn: number, numberVn: number) {
    const listdata = [];
    this.answerWrongEn = sour.answerWrongEn.split(' *** ');
    this.answerWrongVn = sour.answerWrongVn.split(' *** ');
    for (let i = 0; i < numberEn; i++) {
      const listanswerEn = this.getAnswer(this.answerWrongEn, sour.textEn, sour.urlaudio);
      listdata.push(listanswerEn);
    }
    for (let i = 0; i < numberVn; i++) {
      const listanswerVn = this.getAnswer(this.answerWrongVn, sour.textVn, sour.urlaudio);
      listdata.push(listanswerVn);
    }
    return listdata;
  }


  // input mảng dữ liệu sai và 1 sting đúng
  // return mảng 4 phần tử và vị trí nhần tử đúng
  getAnswer(sourceArray, stringRight: string, urlaudio: string) {
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
    result[5] = this.sanitizer.bypassSecurityTrustResourceUrl(urlaudio);
    return { result, key };
  }

  // trộn 1 mảng bất kì
  tronMang(arr: any[]) {
    const arrReturn = [];
    const leng = arr.length;
    const check = [];
    for (let i = 0; i < leng; i++) {
      let random = Math.floor(Math.random() * leng);
      while (check.includes(random)) {
        random = Math.floor(Math.random() * leng);
      }
      check.push(random);
      arrReturn.push(arr[random]);
    }
    return arrReturn;
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
      setTimeout(async () => {
        if (this.wordNumber === 9) {
          // nếu hoàn thành 10 câu thì sẽ update dữ liệu
          const rs = await this.userService.updateWordlened(this.idfilm, this.sttWordLenning, this.totalSentenceRight);
          console.log('tinhrs', rs);
          if (rs.ok) {
            this.message.success('Lưu thành công, chuyển bài mới');
            this.wordNumber = 0;
            this.finishload = false;
            this.getData();
          } else {
            this.message.error('Lỗi! Lưu thất bại');
          }
        } else {
          this.wordNumber++;
        }
      }, 1000);
    } else {
      this.SentenceIsTrue = false;

      console.log('giá trị sai');
    }
    setTimeout(() => { this.abs = -1; }, 1000);
  }

  isCheck(num, key) {
    let check = '';
    if (num === key) {
      check = 'fa-check  text-success';
    } else {
      check = 'fa-times  text-danger';
    }
    return check;
  }

  vidEnded(event) {
    console.log('video ket thuc', event);
  }
}
