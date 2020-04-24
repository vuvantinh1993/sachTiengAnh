import { RankService } from './../../_shared/services/rank.service';
import { FormBuilder } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { DialogService } from './../../_base/services/dialog.service';
import { ExtensionService } from './../../_base/services/extension.service';
import { ExtentionTableService } from './../../_base/services/extention-table.service';
import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { Component, OnInit } from '@angular/core';

@Component({
  templateUrl: './rank.component.html',
  styleUrls: ['./rank.component.scss']
})
export class RankComponent extends BaseListComponent implements OnInit {

  public item: any;
  public listStatus: any[] = [
    { id: 0, name: 'Ẩn' },
    { id: 1, name: 'Hiện' }
  ];
  public name = 'danh mục cấp độ';
  public nameLever: any;
  constructor(
    private rankService: RankService,
    public exTableService: ExtentionTableService,
    private ex: ExtensionService,
    private dl: DialogService,
    private message: NzMessageService,
    private fb: FormBuilder
  ) {
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
        const delObj = await this.rankService.delete(item.id);
        lstDeleting.push(delObj);
      }
      await Promise.all(lstDeleting);
      this.exTableService.unselectAll(this.listOfData);
      this.message.success('Xóa dữ liệu thành công');
      this.getData();
    }
  }

  async deleteDialog(id: number) {
    const result = await this.dl.confirm('<i>Bạn có muốn xóa dữ liệu này không?</i>', '<b>Some descriptions</b>');
    if (result) {
      const rs = await this.rankService.delete(id);
      this.ex.logDebug('Delete response', rs);
      if (rs.ok) {
        this.getData(this.paging.page);
        this.message.success('Xóa dữ liệu thành công');
      }
    }
  }

  async updateStatus(item: any, status: number) {
    const changeVal = 1 - status;
    const rs = await this.rankService.patch(item.id, { dataDb: { status: changeVal } });
    if (rs.ok) {
      item.dataDb.status = changeVal;
    } else {
      this.dl.error('Lỗi hệ thống', 'Dữ liệu của bạn không cập nhật thành công do lỗi hệ thống');
    }
  }

  addData(value: any) {
    if (!!value) {
      this.getData(this.paging.page);
    }
  }

  async getData(page = 1) {
    this.paging.page = page;
    this.paging.size = 15;
    const form = this.myForm.value;
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
    // set where
    if (where.and.length > 0) {
      this.paging.where = where;
    } else {
      delete this.paging.where;
    }
    this.isLoading = true;
    const rs = await this.rankService.get(this.paging);
    this.isLoading = false;
    if (rs.ok) {
      this.listOfData = rs.result.data;
      this.paging = rs.result.paging;
      console.log('getdata', this.listOfData);
    }
  }

  closeDataModal(value: any) {
    if (!!value) {
      this.getData(this.paging.page);
    }
    super.closeDataModal(value);
  }
}
