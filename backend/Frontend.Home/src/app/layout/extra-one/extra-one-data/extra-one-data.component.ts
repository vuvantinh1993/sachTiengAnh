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
    console.log(this.item);

    if (this.item) {
      this.myForm.patchValue(this.item);
    }
  }

  creatForm() {
    this.myForm = this.fb.group({
      audioquestion: [null], // Cấp độ
      textquestion: [null], // Tên bộ phim
      audioanswer: [null], // Điểm số cho từng câu hỏi
      textanswer: [null], // Điểm số cho từng câu hỏi
      categoryfilmid: [null], // Điểm số cho từng câu hỏi
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
    console.log('status', rs.result);
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

    this.formData.append('textquestion', this.myForm.get('textquestion').value);
    this.formData.append('textanswer', this.myForm.get('textanswer').value);
    this.formData.append('categoryfilmid', this.myForm.get('categoryfilmid').value);
    this.formData.append('status', this.myForm.value.dataDb.status);


    console.log(this.formData.getAll('status'));
    console.log(this.formData.getAll('textquestion'));
    console.log(this.formData.getAll('textanswer'));
    console.log(this.formData.getAll('audioanswer'));
    console.log(this.formData.getAll('audioquestion'));

    const rs = ((!this.item) ? await this.extraoneService.add(this.formData)
      : await this.extraoneService.edit(this.item.id as number, this.formData));
    if (rs.ok) {
      this.message.success('Lưu thành công');
      if (close) {
        this.handleOk(rs.result);
      }
      this.item = rs.result;
    } else {
      this.formData
      this.message.error('Lỗi! Lưu thất bại');
    }
  }


  upload(event, name: string) {
    if (event.target.files.length > 0) {
      if (name === 'audioanswer') {
        const profile1 = event.target.files[0];
        this.myForm.get('audioanswer').setValue(profile1);
        console.log('aaaasssssss', this.myForm.get('audioanswer').value);

        this.formData.append('audioanswer', this.myForm.get('audioanswer').value);
      }
      if (name === 'audioquestion') {
        const profile2 = event.target.files[0];
        this.myForm.get('audioquestion').setValue(profile2);
        this.formData.append('audioquestion', this.myForm.get('audioquestion').value);
      }
    }
  }








}
