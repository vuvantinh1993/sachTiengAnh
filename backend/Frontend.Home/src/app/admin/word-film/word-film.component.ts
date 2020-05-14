import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { Component, OnInit } from '@angular/core';
import { WordFilmService } from 'src/app/_shared/services/wordFilm.service';
import { DialogService } from 'src/app/_base/services/dialog.service';
import { NzMessageService } from 'ng-zorro-antd';
import { ExtentionTableService } from 'src/app/_base/services/extention-table.service';
import { FormBuilder } from '@angular/forms';
import { ExtensionService } from 'src/app/_base/services/extension.service';
import { debug } from 'util';

@Component({
  selector: 'app-word-film',
  templateUrl: './word-film.component.html',
  styleUrls: ['./word-film.component.scss']
})
export class WordFilmComponent extends BaseListComponent implements OnInit {

  public data: any;
  public item: any;
  public listStatus: any[] = [
    { id: 0, name: 'Ẩn' },
    { id: 1, name: 'Hiện' }
  ];
  constructor(
    private wordFilmService: WordFilmService,
    private dl: DialogService,
    private message: NzMessageService,
    public exTableService: ExtentionTableService,
    private fb: FormBuilder,
    private ex: ExtensionService, ) {
    super();
  }

  async ngOnInit() {
    this.creatForm();
    await this.getData();
  }

  creatForm() {
    this.myForm = this.fb.group({
      searchText: [''],
      searchStatus: [null]
    });
  }


  openModal(item = null, isView = false) {
    this.item = item;
    this.id = item ? item.id : null;
    this.isView = isView;
    this.isShowModalData = true;
  }

  async deleteChoices() {
    const result = await this.dl.confirm('Bạn có muốn xóa những dữ liệu này không?', 'Some descriptions');
    if (result) {
      const lstSelected = this.exTableService.getitemSelected(this.listOfData);
      const lstDeleting = [];
      for (const item of lstSelected) {
        const delObj = await this.wordFilmService.delete(item.id);
        lstDeleting.push(delObj);
      }
      await Promise.all(lstDeleting);
      this.exTableService.unselectAll(this.listOfData);
      this.message.success('Xóa dữ liệu thành công');
      this.getData();
    }
  }

  async updateStatus(item: any, status: number) {
    const changeVal = 1 - status;
    const rs = await this.wordFilmService.patch(item.id, { dataDb: { status: changeVal } });
    if (rs.ok) {
      item.dataDb.status = changeVal;
    } else {
      this.dl.error('Lỗi hệ thống', 'Dữ liệu của bạn không cập nhật thành công do lỗi hệ thống');
    }
  }

  async deleteDialog(id: number) {
    const result = await this.dl.confirm('<i>Bạn có muốn xóa dữ liệu này không?</i>', '<b>Some descriptions</b>');
    if (result) {
      const rs = await this.wordFilmService.delete(id);
      this.ex.logDebug('Delete response', rs);
      if (rs.ok) {
        this.getData(this.paging.page);
        this.message.success('Xóa dữ liệu thành công');
      }
    }
  }

  async getData(page = 1) {
    this.data = null;
    this.listOfData = [];
    const form = this.myForm.value;
    this.paging.page = page;
    this.paging.size = 10;

    // where theo du lieu dau vao
    const where = { and: [] };
    // tìm kiếm theo trạng thái
    if (form.searchStatus) {
      where.and.push({ statusId: +form.searchStatus });
    }
    // tìm kiếm theo tên
    if (form.searchText) {
      where.and.push({
        or: [
          { contractName: { like: this.ex.BoDau(form.searchText) } },
          { 'proj.projName': { like: this.ex.BoDau(form.searchText) } }
        ]
      });
      this.myForm.controls.searchText.patchValue(this.ex.SubSpace(form.searchText));
    }
    if (where.and.length > 0) {
      this.paging.where = where;
    } else {
      delete this.paging.where;
    }
    this.isLoading = true;
    const rs = await this.wordFilmService.get(this.paging);
    this.isLoading = false;
    if (rs.ok && rs.result) {
      this.data = rs.result.data;
      if (this.data) {
        this.listOfData = this.data;
        this.paging = rs.result.paging;
      }
    }

  }

  async deleteItem(id: number) {
    const result = await this.dl.confirm('<i>Bạn có muốn xóa dữ liệu này không?</i>', '<b>Some descriptions</b>');
    if (result) {
      const rs = await this.wordFilmService.delete(id);
      if (rs.ok) {
        this.getData(this.paging.page);
        this.message.success('Xóa dữ liệu thành công');
      }
    }
  }

  closeDataModal(value: any) {
    if (!!value) {
      this.getData(this.paging.page);
    }
    super.closeDataModal(value);
  }

  addData(value: any) {
    if (!!value) {
      this.getData(this.paging.page);
    }
  }

  isDisable() {
    if (this.isView) {
      return true;
    } else {
      return false;
    }
  }

}
