import { ActivatedRoute, Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';
import { UserService } from './../../../_shared/services/User.service';
import { GlobalValidate } from './../../../_base/class/global-validate';
import { FormBuilder } from '@angular/forms';
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
    public userservice: UserService) { super(fb); }

  ngOnInit() {
    this.creatForm();
  }

  creatForm() {
    this.myForm = this.fb.group({
      UserName: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Tên bộ phim
      Email: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Tên bộ phim
      FullName: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Điểm số cho từng câu hỏi
      Password: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Điểm số cho từng câu hỏi
      ConfirmPassword: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Điểm số cho từng câu hỏi
    });
    if (this.isView) { this.myForm.disable(); }
  }

  async onSubmit() {
    super.submitForm();
    if (this.myForm.invalid) { return; }
    const rs = await this.userservice.register(this.myForm.value);
    if (rs.ok) {
      this.message.success('Đăng kí thành công', { nzDuration: 10000 });
      this.router.navigate(['login']);
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

}
