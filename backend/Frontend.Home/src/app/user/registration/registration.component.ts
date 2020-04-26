import { GlobalValidate } from './../../_base/class/global-validate';
import { UsersService } from './../../_shared/services/User.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';
import { FormBuilder, FormControl } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { BaseDataComponent } from 'src/app/_base/components/base-data-component';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent extends BaseDataComponent implements OnInit {

  constructor(
    fb: FormBuilder,
    private message: NzMessageService,
    private router: Router,
    public userservice: UsersService) { super(fb); }

  ngOnInit() {
    this.creatForm();
  }

  creatForm() {
    this.myForm = this.fb.group({
      UserName: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Tên bộ phim
      Email: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Tên bộ phim
      FullName: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Điểm số cho từng câu hỏi
      Password: [null, [GlobalValidate.required({ error: 'Không được để trống' }),
      GlobalValidate.MinLength(6, { error: 'Mật khẩu lớn hơn 6 kí tự' })]], // Điểm số cho từng câu hỏi
      ConfirmPassword: [null, [GlobalValidate.required({ error: 'Không được để trống' }),
      this.comparePassword]], // Điểm số cho từng câu hỏi
    });
    if (this.isView) { this.myForm.disable(); }
  }

  async onSubmit() {
    super.submitForm();
    if (this.myForm.invalid) { return; }
    const rs = await this.userservice.register(this.myForm.value);
    if (rs.ok) {
      this.message.success('Đăng kí thành công', { nzDuration: 10000 });
      this.router.navigate(['user/login']);
    } else {
      this.message.error('Lỗi! Lưu thất bại');
    }
    // this.service.register().subscribe(
    //   (res: any) => {
    //     if (res.succeeded) {
    //       this.service.formModel.reset();
    //       this.toastr.success('New user created!', 'Registration successful.');
    //     } else {
    //       res.errors.forEach(element => {
    //         switch (element.code) {
    //           case 'DuplicateUserName':
    //             this.toastr.error('Username is already taken', 'Registration failed.');
    //             break;

    //           default:
    //             this.toastr.error(element.description, 'Registration failed.');
    //             break;
    //         }
    //       });
    //     }
    //   },
    //   err => {
    //     console.log(err);
    //   }
    // );
  }

  validDate() {
    Promise.resolve().then(() => this.myForm.controls.Password.updateValueAndValidity());
    Promise.resolve().then(() => this.myForm.controls.ConfirmPassword.updateValueAndValidity());
  }

  comparePassword = (control: FormControl) => {
    if (!this.myForm) { return null; }
    if (this.myForm.controls.ConfirmPassword.value) {
      if (this.myForm.controls.ConfirmPassword.value !== this.myForm.controls.Password.value) {
        return { error: 'Nhập giống trường password' };
      } else {
        return null;
      }
    } else {
      return null;
    }
  }

}
