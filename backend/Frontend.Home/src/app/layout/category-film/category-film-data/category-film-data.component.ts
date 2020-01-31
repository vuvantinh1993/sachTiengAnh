import { CategoryFilmService } from './../../../_shared/services/categoryfilm.service';
import { Component, OnInit, Input } from '@angular/core';
import { GlobalValidate } from 'src/app/_base/class/global-validate';
import { BaseDataComponent } from 'src/app/_base/components/base-data-component';
import { FormBuilder } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-category-film-data',
  templateUrl: './category-film-data.component.html',
  styleUrls: ['./category-film-data.component.scss']
})
export class CategoryFilmDataComponent extends BaseDataComponent implements OnInit {

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
    private categoryFilmService: CategoryFilmService,
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
      level: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Cấp độ
      name: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Tên bộ phim
      pointword: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Điểm số cho từng câu hỏi
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
    const rs = ((!this.item) ? await this.categoryFilmService.add(this.myForm.value)
      : await this.categoryFilmService.edit(this.item.id as number, this.myForm.value));
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
