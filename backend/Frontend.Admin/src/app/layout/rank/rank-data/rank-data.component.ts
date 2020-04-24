import { RankService } from './../../../_shared/services/rank.service';
import { Component, OnInit, Input } from '@angular/core';
import { GlobalValidate } from 'src/app/_base/class/global-validate';
import { BaseDataComponent } from 'src/app/_base/components/base-data-component';
import { FormBuilder } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-rank-data',
  templateUrl: './rank-data.component.html',
  styleUrls: ['./rank-data.component.scss']
})
export class RankDataComponent extends BaseDataComponent implements OnInit {

  @Input() item: any;
  public listLever: any[] = [
    { id: 1, name: '1 Sao' },
    { id: 2, name: '2 Sao' },
    { id: 3, name: '3 Sao' },
    { id: 4, name: '4 Sao' },
    { id: 5, name: '5 Sao' }
  ];
  public openTab = 1;

  constructor(
    fb: FormBuilder,
    private rankService: RankService,
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
      name: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Tên bộ phim
      star: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Tên bộ phim
      pointStage: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Điểm số cho từng câu hỏi
      dataDb: this.fb.group({
        status: [{ value: 1 }],
      })
    });
    if (this.isView) { this.myForm.disable(); }
  }


  async submit(close: boolean) {
    super.submitForm();
    if (this.myForm.invalid) { return; }
    this.myForm.value.dataDb.status = this.myForm.value.dataDb.status ? 1 : 0;
    const rs = ((!this.item) ? await this.rankService.add(this.myForm.value)
      : await this.rankService.edit(this.item.id as number, this.myForm.value));
    if (rs.ok) {
      this.message.success('Lưu thành công');
      if (close) {
        this.handleOk(rs.result);
      }
      this.item = null;
    } else {
      this.message.error('Lỗi! Lưu thất bại');
    }
  }


}
