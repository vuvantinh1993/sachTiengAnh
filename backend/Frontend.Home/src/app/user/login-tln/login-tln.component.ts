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
  };
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
            localStorage.setItem('fullName', ress.fullName);
            localStorage.setItem('email', ress.email);
            localStorage.setItem('userName', ress.userName);
            localStorage.setItem('address', ress.address);
            localStorage.setItem('avatar', ress.avatar);
            localStorage.setItem('point', ress.point);
            localStorage.setItem('namerank', ress.namerank);
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
          err.error.forEach(element => {
            this.message.error(element, { nzDuration: 5000 });
          });
        } else {
          console.log(err);
        }
      }
    );

  }

}
