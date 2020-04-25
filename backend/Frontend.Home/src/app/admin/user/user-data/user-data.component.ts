import { AdminUserService } from './../../../_shared/services/admin-user.service';
import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { BaseDataComponent } from 'src/app/_base/components/base-data-component';
import { GlobalValidate } from 'src/app/_base/class/global-validate';

@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.scss']
})
export class UserDataComponent extends BaseDataComponent implements OnInit {

  @Input() item: any;
  public listLever: any[] = [
    { id: 1, name: 'Easy' },
    { id: 2, name: 'Medium' },
    { id: 3, name: 'Hard' },
    { id: 4, name: 'Very Hard' }
  ];
  public openTab = 1;

  constructor(
    fb: FormBuilder,
    private userService: AdminUserService,
    private message: NzMessageService,

  ) { super(fb); }

  ngOnInit() {
    this.creatForm();
    if (this.item) {
      this.myForm.patchValue(this.item);
    }
  }


  creatForm() {
    this.myForm = this.fb.group({
      name: [null, GlobalValidate.required({ error: 'Không được để trống' })],
      email: [null, GlobalValidate.required({ error: 'Không được để trống' })],
      phone: [null, GlobalValidate.required({ error: 'Không được để trống' })],
      password: [null, GlobalValidate.required({ error: 'Không được để trống' })], // pass
      listfrendid: [null], // Danh sách bạn bè
      dataDb: this.fb.group({
        status: [{ value: true }],
      })
    });
    if (this.isView) { this.myForm.disable(); }
  }


  async submit(close: boolean) {
    super.submitForm();
    if (this.myForm.invalid) { return; }
    this.myForm.value.dataDb.status = this.myForm.value.dataDb.status ? 1 : 0;
    const rs = ((!this.item) ? await this.userService.add(this.myForm.value)
      : await this.userService.edit(this.item.id as number, this.myForm.value));
    if (rs.ok) {
      this.message.success('Lưu thành công');
      if (close) {
        this.handleOk(rs.result);
      }
      this.item = rs.result;
    } else {
      this.message.error('Lỗi! Lưu thất bại');
    }
  }


}
