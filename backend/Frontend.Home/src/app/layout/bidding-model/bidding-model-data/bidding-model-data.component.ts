import { Component, OnInit } from '@angular/core';
import { BaseDataComponent } from 'src/app/_base/components/base-data-component';
import { FormBuilder } from '@angular/forms';
import { GlobalValidate } from 'src/app/_base/class/global-validate';
import { ExtensionService } from 'src/app/_base/services/extension.service';
import { NzMessageService } from 'ng-zorro-antd/message';
import { BiddingModelService } from 'src/app/_shared/services/bidding-model.service';

@Component({
  selector: 'app-bidding-model-data',
  templateUrl: './bidding-model-data.component.html',
  styleUrls: ['./bidding-model-data.component.scss']
})
export class BiddingModelDataComponent extends BaseDataComponent implements OnInit {

  constructor(
    fb: FormBuilder,
    private ex: ExtensionService,
    private sv: BiddingModelService,
    private message: NzMessageService
  ) {
    super(fb);
  }

  async ngOnInit() {
    this.createForm({
      data: this.fb.group({
        binddingModelName: [null, [
          GlobalValidate.required({ error: 'Không được để trống' }),
          GlobalValidate.space({ error: 'Không được để khoảng trắng' }),
          GlobalValidate.regularExpression('[^\\p{L}]', { error: 'Hãy sử dụng một ngôn ngữ nào đó' }),
          GlobalValidate.regularNotExpression('[!@#$%^&*(),.?":{}|<>/\\\\]', { error: 'Không được nhập ký tự đặc biệt' })
        ]],
        binddingModelIndex: [null],
        note: [null],
      }),
      dataDb: this.fb.group({
        status: [true],
      })
    });
    if (this.isView) {
      this.myForm.disable();
    }
    if (this.id) {
      const rs = await this.sv.findOneById(this.id);
      console.log('rs', rs);
      this.ex.logDebug('Edit item', rs);
      if (rs.ok) {
        this.myForm.patchValue(rs.result);
      }
    }
  }

  async submitForm(close: boolean = true) {
    super.submitForm();
    if (this.myForm.invalid) { return; }
    const body: any = this.myForm.value;
    console.log(body);
    body.dataDb.status = body.dataDb.status ? 1 : 0;
    this.isLoading = true;
    let result: any;

    const rs = this.id ? await this.sv.edit(this.id as number, body) : await this.sv.add(body);
    this.isLoading = false;
    if (rs.ok) {
      result = rs.result;
      this.message.success('Lưu thành công');
      close ? this.handleOk(result) : this.resetForm(result);
    } else {
      this.message.error('Lỗi! Lưu thất bại ');
      return;
    }
  }

  resetForm(data: any) {
    this.handleAdd(data);
    this.id = null;
    this.myForm.reset();
  }

  successMessage(type: string, text: string): void {
    this.message.create(type, text);
  }

  errorMessage(type: string, text: string): void {
    this.message.create(type, text);
  }

}