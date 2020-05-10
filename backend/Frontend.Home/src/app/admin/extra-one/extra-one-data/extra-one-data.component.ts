import { CategoryFilmService } from './../../../_shared/services/categoryfilm.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';
import { GlobalValidate } from 'src/app/_base/class/global-validate';
import { BaseDataComponent } from 'src/app/_base/components/base-data-component';
import { ExtraoneService } from 'src/app/_shared/services/extraone.service';
import { NzMessageService } from 'ng-zorro-antd';
import { HttpRequest, HttpClient, HttpEventType } from '@angular/common/http';
import { PagingModel } from 'src/app/_base/models/response-model';
import { debug } from 'util';

@Component({
  selector: 'app-extra-one-data',
  templateUrl: './extra-one-data.component.html',
  styleUrls: ['./extra-one-data.component.scss']
})
export class ExtraOneDataComponent extends BaseDataComponent implements OnInit {

  @Input() item: any;
  public openTab = 1;
  public name = 'Extra-One';
  public selectedFile: File = null;
  public listLever: any[] = [];
  messages: string[] = [];
  public formData = new FormData();
  public listfilm: any[] = [];

  constructor(
    public fb: FormBuilder,
    private extraoneService: ExtraoneService,
    private categoryFilmService: CategoryFilmService,
    private message: NzMessageService,
  ) { super(fb); }

  ngOnInit() {
    this.creatForm();
    this.getlistfilm();
    if (this.item) {
      this.myForm.patchValue(this.item);
    }
  }

  creatForm() {
    this.myForm = this.fb.group({
      audio: [null], // Điểm số cho từng câu hỏi
      textVn: [null], // Điểm số cho từng câu hỏi
      textEn: [null], // Điểm số cho từng câu hỏi
      categoryfilmid: [null], // Điểm số cho từng câu hỏi
      fullName: [null],
      dataDb: this.fb.group({
        status: [{ value: true }],
      })
    });
    if (this.isView) { this.myForm.disable(); }
  }

  async getlistfilm() {
    const params: PagingModel = {
      page: 1,
      size: 100
    };
    const rs = await this.categoryFilmService.get(params);
    if (rs.ok) {
      this.listfilm = rs.result.data.map(x => {
        return {
          id: x.id,
          name: x.name
        };
      });
    }
  }

  async submit(close: boolean) {
    super.submitForm();
    if (this.myForm.invalid) { return; }
    this.myForm.value.dataDb.status = this.myForm.value.dataDb.status ? 1 : 0;

    this.formData.append('textVn', this.myForm.get('textVn').value);
    this.formData.append('textEn', this.myForm.get('textEn').value);
    this.formData.append('status', this.myForm.value.dataDb.status);
    this.formData.append('fullName', this.myForm.get('fullName').value);
    const rs = ((!this.item) ? await this.extraoneService.add(this.formData)
      : await this.extraoneService.edit(this.item.id as number, this.formData));
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


  upload(event) {
    if (event.target.files.length > 0) {
      const profile1 = event.target.files[0];
      this.myForm.get('audio').setValue(profile1);
      this.formData.append('audio', this.myForm.get('audio').value);
      const text = this.myForm.get('audio').value.name;
      let textEn = text.substring(text.indexOf('.') + 1, text.indexOf('-') - 1);
      let textVn = text.substring(text.indexOf('-') + 2, text.length - 4);
      const checkQuest = textVn[textVn.length - 1];
      if (checkQuest === '`') {
        textEn = textEn + '?';
        textVn = textVn.substring(0, textVn.length - 1) + '?';
      }
      this.myForm.controls.textVn.setValue(textVn);
      this.myForm.controls.textEn.setValue(textEn);

      // chỉnh sửa đường dẫn cho url
      let fullName = textEn.replace(/[\.\!\s\,\-\+\?\`]+/gi, '_'); // nếu có tất cả kí tự trên thì thay bằng '_'
      fullName = fullName.replace(/_$/gi, ''); // nếu giá trị cuối là '_' thì xóa
      fullName = fullName.replace(/[\']/gi, ''); // neew chuỗi xuất hiện dấu "'" thì xóa
      this.myForm.controls.fullName.setValue(fullName);
    }
  }

}
