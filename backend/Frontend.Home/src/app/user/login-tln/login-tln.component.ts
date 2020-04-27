import { UsersService } from './../../_shared/services/user.service';
import { NzMessageService } from 'ng-zorro-antd';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login-tln',
  templateUrl: './login-tln.component.html',
  styleUrls: ['./login-tln.component.scss']
})
export class LoginTLNComponent implements OnInit {
  formModel = {
    UserName: '',
    Password: ''
  }
  constructor(
    // private service: UserService, private router: Router, private toastr: ToastrService
    private message: NzMessageService,
    private router: Router,
    public userService: UsersService,
  ) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null) {
      this.router.navigate(['/home']);
    }
  }

  onSubmit(form: NgForm) {
    this.userService.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.userService.getprofile().subscribe(
          ress => {
            console.log('res', ress);
            localStorage.setItem('fullName', ress.fullName);
            localStorage.setItem('email', ress.email);
            this.router.navigate(['/home']);
            this.message.success('Đăng nhập thành công', { nzDuration: 5000 });
          },
          err => {
            console.log('err', err);
          }
        );
        // console.log(localStorage);

      },
      err => {
        if (err.status === 400) {
          this.message.error('Tài khoản hoặc mật khẩu không đúng', { nzDuration: 5000 });
        } else {
          console.log(err);
        }
      }
    );

  }

}
