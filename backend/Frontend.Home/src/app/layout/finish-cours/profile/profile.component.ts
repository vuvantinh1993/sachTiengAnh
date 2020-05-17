import { UsersService } from './../../../_shared/services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { GlobalValidate } from 'src/app/_base/class/global-validate';
import { BaseDataComponent } from 'src/app/_base/components/base-data-component';
import { FormBuilder } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { RankService } from 'src/app/_shared/services/rank.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent extends BaseDataComponent implements OnInit {
  public avatar = this.userService.currentAvatar;
  public fullName = this.userService.currentFullName;
  public namerank = this.userService.currentNamerank;
  public address = this.userService.currentAddress;

  public totalPointRight = +this.route.snapshot.paramMap.get('point');
  public num: number;
  public intervalId = null;
  public show: number;
  public pointNeedForNextLever: number;
  public processing: number;
  public startYeelow: any;
  public startnon: any;

  constructor(
    fb: FormBuilder,
    private route: ActivatedRoute,
    public userService: UsersService,

  ) { super(fb); }

  ngOnInit() {
    // lấy thông tin tìa khoản và add dữ liệu vao biến
    this.userService.getprofile();
    this.userService.currentStar.subscribe(ress => {
      this.startYeelow = Array(ress).fill(4);
      this.startnon = Array(5 - ress).fill(4);
    }, err => {
      console.log('err', err);
    });

    this.userService.currentPointLeverNext.subscribe(ress1 => {
      this.userService.currentpointStage.subscribe(ress2 => {
        this.userService.currentPoint.subscribe(ress3 => {
          this.num = +this.totalPointRight;
          this.show = +ress3 - this.num;
          this.pointNeedForNextLever = ress1 - ress3;
          this.processing = Math.round((this.pointNeedForNextLever / (ress1 - ress2)) * 100);
        });
      });
    });

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

  OpenTooltips(event) {
    const tooltipSpan = document.getElementById('tooltip-span');
    tooltipSpan.style.top = (event.clientY - 30) + 'px';
    tooltipSpan.style.left = (event.clientX + 10) + 'px';
  }
}
