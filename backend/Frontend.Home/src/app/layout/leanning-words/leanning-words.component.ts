import { FormBuilder } from '@angular/forms';
import { UserLeanningService } from './../../_shared/services/UserLeanning.service';
import { DialogService } from './../../_base/services/dialog.service';
import { AESService } from './../../_base/services/aes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ExtensionService } from './../../_base/services/extension.service';
import { ExtentionTableService } from './../../_base/services/extention-table.service';
import { ExtraoneService } from './../../_shared/services/extraone.service';
import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { NzMessageService } from 'ng-zorro-antd';
// import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { Common } from 'src/app/_shared/extensions/common.service';


@Component({
  selector: 'app-leanning-words',
  templateUrl: './leanning-words.component.html',
  styleUrls: ['./leanning-words.component.scss']
})
export class LeanningWordsComponent extends BaseListComponent implements OnInit {
  public tinh = 1;
  public idFilmComponent: any;
  public myTimer: any;
  public extran: string;
  public totalSentenceRight = 0;
  public SentenceIsTrue = true;
  public counter = 100;
  public data: any;
  public datalist: any[];
  public listAnswer: any[];
  public answerWrongEn: string;
  public answerWrongVn: string;
  public wordNumber = 0;
  public totalWord: number;
  public sttWordLenning: number;
  public sttleaned: number;
  public idfilmComponent: number;
  public isshow = false;
  public loadxongchohoctiep = false;
  private stypelean: string;
  urlSafe: SafeResourceUrl;
  public intervalId = null;
  public lengthlistword: number; // là tổng số các câu trong 1 lượt học
  constructor(
    private extraoneService: ExtraoneService,
    private route: ActivatedRoute,
    public sanitizer: DomSanitizer,
    public exTableService: ExtentionTableService,
    private userLeanningService: UserLeanningService,
    private message: NzMessageService,
    public ex: ExtensionService,
    private aesservice: AESService,
    private dl: DialogService,
    public router: Router) {
    super();
  }

  ngOnInit() {
    this.changeSpeedVideo(1);
    setTimeout(() => {
      this.changeSpeedVideo(2);
    }, 1000);
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
    this.datalist = [];
    this.listOfData = [];
    this.paging.page = page;

    // where theo du lieu dau vao
    const where = { and: [] };
    if (where.and.length > 0) {
      this.paging.where = where;
    } else {
      delete this.paging.where;
    }
    Common.ChangeidFilm(+this.route.snapshot.paramMap.get('idfilm'));
    Common.currentIdFilm.subscribe(e => {
      this.idfilmComponent = e;
    });
    this.stypelean = this.route.snapshot.paramMap.get('style');
    if (this.stypelean === 'old') {
      this.paging.size = 4;
    }
    const rs = await this.extraoneService.getWords(this.stypelean, this.idfilmComponent, this.paging);
    if (rs.ok && rs.result) {
      this.data = rs.result.data;
      if ((this.data.data.length !== 0)) {
        if (this.data.sttWord !== -3) {
          localStorage.setItem('sttWordLenning', this.data.sttWord); // lưu dữ liệu từ đang học của bộ phim lên localstagare
        }
        this.sttWordLenning = this.data.sttWord;
        this.speedValueVideo = this.data.speedVideo;

        // lấy số từ đã hoc
        this.sttleaned = this.sttWordLenning > 1 ? this.sttWordLenning - 1 : 0; // hiện từ đã học html
        this.totalWord = this.data.data[0].totalWord;
        this.data = this.data.data;
        this.datalist = this.tron10Cau(this.sttWordLenning); // dùng để biến sour lấy về thành 10 câu rồi trộn 10 câu
        this.lengthlistword = this.datalist.length; // lấy tổng số câu hỏi
        setTimeout(() => {
          this.setupvideo();
        }, 1);

      } else {
        const result = await this.dl.alert(`${this.stypelean === 'old'
          ? 'Không có từ cần học lại, tiếp tục học từ mới'
          : 'Xin chúc mừng, bạn đã hoàn thành bộ phim này quay về trang chủ'}`, ' ');
        if (this.stypelean === 'old') {
          this.router.navigate(['/leanning-words', 'new', this.idfilmComponent]);
        } else {
          this.router.navigate(['/']);
        }
      }
    }
  }

  // dùng để trộn các câu theo lịch trình
  // nếu sttWord == -2 là ko thể lấy được film
  // nếu sttWord == -3 là học từ đã quên
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
        }
        if (key === '4') {
          const list = this.laySoCauTheoTu(value, 1, 0);
          listda = listda.concat(list);
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
        }
        if (key === '4') {
          const list = this.laySoCauTheoTu(value, 1, 0);
          listda = listda.concat(list);
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
        }
      }
    } else if (sttWord === -3) {
      for (const [key, value] of Object.entries(this.data)) {
        if (key === '0') {
          const list = this.laySoCauTheoTu(value, 1, 2);
          listda = list;
        }
        if (key === '1') {
          const list = this.laySoCauTheoTu(value, 1, 2);
          listda = listda.concat(list);
        }
        if (key === '2') {
          const list = this.laySoCauTheoTu(value, 1, 2);
          listda = listda.concat(list);
        }
        if (key === '3') {
          const list = this.laySoCauTheoTu(value, 1, 2);
          listda = listda.concat(list);
        }
      }
    }
    listda = this.tronMang(listda);
    return listda;
  }

  /// Chuyển câu số x thành n câu đúng (trong đó có n câu tiếng Anh, y câu tiếng việt)
  /// trả về mảng câu theo ý muốn
  laySoCauTheoTu(sour: any, numberEn: number, numberVn: number) {
    const listdata = [];
    this.answerWrongEn = sour.answerWrongEn.split(' *** ');
    this.answerWrongVn = sour.answerWrongVn.split(' *** ');
    for (let i = 0; i < numberEn; i++) {
      const listanswerEn = this.getAnswer(this.answerWrongEn, sour.textEn, sour.urlaudio, true);
      listanswerEn.texttip = sour.textVn;
      listdata.push(listanswerEn);
    }
    for (let i = 0; i < numberVn; i++) {
      const listanswerVn = this.getAnswer(this.answerWrongVn, sour.textVn, sour.urlaudio, false);
      listanswerVn.texttip = sour.textEn;
      listdata.push(listanswerVn);
    }
    return listdata;
  }


  // input mảng dữ liệu sai và 1 sting đúng
  // return mảng 4 phần tử và vị trí nhần tử đúng
  getAnswer(sourceArray, stringRight: string, urlaudio: string, textshow: boolean) {
    const randomInFour = Math.floor(Math.random() * 4);
    const result = [];
    const checkInFour = [];
    const checkInSource = [];
    const texttip = '';
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
    return { result, key, texttip, textshow };
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

  async kiemtraketqua(target, key, check1, check2) {
    // kiểm tra thẻ dom load xong mới cho thao tác tiếp tránh trường hợp click nhiều nhần 1 câu
    if (this.loadxongchohoctiep === true) {
      if (+target.value === key) {
        console.log('trả lời đúng');
        this.loadxongchohoctiep = false;
        clearInterval(this.intervalId);
        setTimeout(() => {
          this.counter = 100;
          this.isshow = false;
          this.countdown();
        }, 1000);

        target.checked = false;
        if (this.SentenceIsTrue) {
          this.totalSentenceRight++;
        }
        this.SentenceIsTrue = true;
        setTimeout(async () => {
          if (this.wordNumber === (this.lengthlistword - 1)) {
            // kết thúc số câu trong 1 lượt hoc, mã hóa dữ liệu dông điểm đưa lên server
            const chuoimahoacongdiem = this.MaHoaChuoiCongDiem(this.totalSentenceRight)

            const rs = await this.userLeanningService.updateWordlened(chuoimahoacongdiem);
            if (rs.ok) {
              if (this.sttWordLenning !== -3) {
                localStorage.setItem('sttWordLenning', (+localStorage.getItem('sttWordLenning') + 1).toString());
              }
              this.router.navigate(['/finish-cours', this.idfilmComponent, rs.result.totalPointRight]);
            } else {
              this.message.error('Lỗi! Lưu thất bại', { nzDuration: 40000 });
              setTimeout(() => {
                rs.errors.error.updateWordlened.forEach(ele => {
                  this.message.error(ele, { nzDuration: 50000 });
                });
              }, 300);
            }
          } else {
            console.log('tinh');
            this.wordNumber++;
            this.setupvideo();
          }
        }, 1000);
      } else {
        this.SentenceIsTrue = false;
        target.checked = false;
      }
      this.AnimationCheck(check1);
      this.AnimationCheck(check2);
    }
  }

  AnimationCheck(check: string) {
    const element1 = document.getElementById(check);
    if (element1 != null) {
      element1.classList.remove('fas');
      // tslint:disable-next-line: no-unused-expression
      element1.offsetWidth;
      element1.classList.add('fas');
    }
  }

  MaHoaChuoiCongDiem(totalSentenceRight) {
    // tao chuoi ma hoa khi cong diem
    const congchuoi = this.idfilmComponent.toString() + ':' + (this.sttWordLenning) + ':' + totalSentenceRight + ':' + this.speedValueVideo;
    const chuoimahoa = this.aesservice.encrypt(congchuoi);

    let data = {};
    // kiểm tra stt=3 nghĩa là từu đó học lại
    // kiểm tra tiếp có mấy từ học lại rồi gọi lên api truyền nó lên
    if (this.sttWordLenning === -3) {
      if (this.data.length === 1) {
        data = { chuoimahoa, stt1: this.data[0].iteam.stt, check1: this.data[0].iteam.check, classic1: this.data[0].iteam.classic };
      } else if (this.data.length === 2) {
        data = {
          chuoimahoa, stt1: this.data[0].iteam.stt, check1: this.data[0].iteam.check, classic1: this.data[0].iteam.classic,
          stt2: this.data[1].iteam.stt, check2: this.data[1].iteam.check, classic2: this.data[1].iteam.classic
        };
      } else if (this.data.length === 3) {
        data = {
          chuoimahoa, stt1: this.data[0].iteam.stt, check1: this.data[0].iteam.check, classic1: this.data[0].iteam.classic,
          stt2: this.data[1].iteam.stt, check2: this.data[1].iteam.check, classic2: this.data[1].iteam.classic,
          stt3: this.data[2].iteam.stt, check3: this.data[2].iteam.check, classic3: this.data[2].iteam.classic
        };
      } else {
        data = {
          chuoimahoa, stt1: this.data[0].iteam.stt, check1: this.data[0].iteam.check, classic1: this.data[0].iteam.classic,
          stt2: this.data[1].iteam.stt, check2: this.data[1].iteam.check, classic2: this.data[1].iteam.classic,
          stt3: this.data[2].iteam.stt, check3: this.data[2].iteam.check, classic3: this.data[2].iteam.classic,
          stt4: this.data[3].iteam.stt, check4: this.data[3].iteam.check, classic4: this.data[3].iteam.classic
        };
      }
    } else {
      data = { chuoimahoa };
    }
    return data;
  }




  async daloadxong() {
    this.loadxongchohoctiep = true;
  }

  setupvideo() {
    this.hidenplay();
    const vid = (document.getElementById('myVideo') as HTMLMediaElement);
    vid.defaultPlaybackRate = this.speedValueVideo;
    vid.autoplay = true;
    vid.load();
  }

  hidenplay() {
    const imgPlay = (document.getElementById('imgplay') as HTMLElement);
    imgPlay.hidden = true;
  }
  reloadvideo() {
    this.hidenplay();
    const vid = (document.getElementById('myVideo') as HTMLMediaElement);
    // console.log('this.speedvalue', this.speedvalue);
    vid.currentTime = 0;
    vid.play();
  }

  videoketthuc() {
    const imgPlay = (document.getElementById('imgplay') as HTMLElement);
    imgPlay.hidden = false;
  }

  changeSpeedVideo(event) {
    console.log(event);
    clearTimeout(this.myTimer);
    this.myTimer = setTimeout(() => {
      this.speedValueVideo = event;
      this.setupvideo();
      console.log('TÍNH');
    }, 2000);
  }


  OpenTooltips(event) {
    const tooltipSpan = document.getElementById('tooltip-span');
    tooltipSpan.style.top = (event.clientY - 30) + 'px';
    tooltipSpan.style.left = (event.clientX + 10) + 'px';
  }
}
