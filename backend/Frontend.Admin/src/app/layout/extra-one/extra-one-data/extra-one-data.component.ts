import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';
import { GlobalValidate } from 'src/app/_base/class/global-validate';
import { BaseDataComponent } from 'src/app/_base/components/base-data-component';
import { ExtraoneService } from 'src/app/_shared/services/extraone.service';
import { NzMessageService } from 'ng-zorro-antd';

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
  theFile: any = null;
  messages: string[] = [];
  theFiles: any[] = [];
  public MAX_SIZE = 1048576000;

  constructor(
    public fb: FormBuilder,
    private extraoneService: ExtraoneService,
    private message: NzMessageService,

  ) { super(fb); }

  ngOnInit() {
    this.creatForm();
  }

  creatForm() {
    this.myForm = this.fb.group({
      audioquestion: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Cấp độ
      textquestion: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Tên bộ phim
      audioanswer: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Điểm số cho từng câu hỏi
      textanswer: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Điểm số cho từng câu hỏi
      categoryfilmid: [null, GlobalValidate.required({ error: 'Không được để trống' })], // Điểm số cho từng câu hỏi
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
    const rs = ((!this.item) ? await this.extraoneService.add(this.myForm.value)
      : await this.extraoneService.edit(this.item.id as number, this.myForm.value));
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

  onFileChange(event) {
    this.theFile = null;
    if (event.target.files && event.target.files.length > 0) {
      // Don't allow file sizes over 1MB
      if (event.target.files[0].size < this.MAX_SIZE) {
        // Set theFile property
        this.theFile = event.target.files[0];
        this.theFiles.push(this.theFile);
      } else { // Display error message
        this.messages.push('File: ' + event.target.files[0].name + ' is too large to upload.');
      }
    }
    this.onupload();
  }

  onupload() {
    // const fd = new FormData();
    // fd.append('name', this.selectedFile, this.selectedFile.name);
    // const rs = await this.extraoneService.add(fd);
    // console.log(rs);
    // tslint:disable-next-line: prefer-for-of
    for (let index = 0; index < this.theFiles.length; index++) {
      this.readAndUploadFile(this.theFiles[index]);
    }

  }

  private readAndUploadFile(theFile: any) {
    // Set File Information
    // this.file.fileName = theFile.name;
    // this.file.fileSize = theFile.size;
    // this.file.fileType = theFile.type;
    // this.file.lastModifiedTime = theFile.lastModified;
    // this.file.lastModifiedDate = theFile.lastModifiedDate;

    // Use FileReader() object to get file to upload
    // NOTE: FileReader only works with newer browsers
    const reader = new FileReader();
    console.log('tinh', reader.result);

    // Setup onload event for reader
    reader.onload = () => {
      // Store base64 encoded representation of file
      // this.file.fileAsBase64 = reader.result.toString();
      this.myForm.patchValue({ audioanswer: reader.result.toString() }); // pass về base 64 rồi import
      console.log('tinh', this.myForm.controls.audioanswer.value);

      // // POST to server
      // this.uploadService.uploadFile(this.file)
      //   .subscribe(resp => { this.messages.push("Upload complete"); });
    };

    // Read the file
    reader.readAsDataURL(theFile);
  }



}
