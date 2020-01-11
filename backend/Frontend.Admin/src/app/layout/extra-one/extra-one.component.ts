import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { Component, OnInit } from '@angular/core';
import { ExtraoneService } from 'src/app/_shared/services/extraone.service';
import { DialogService } from 'src/app/_base/services/dialog.service';
import { NzMessageService } from 'ng-zorro-antd';
import { ExtentionTableService } from 'src/app/_base/services/extention-table.service';

@Component({
  selector: 'app-extra-one',
  templateUrl: './extra-one.component.html',
  styleUrls: ['./extra-one.component.scss']
})
export class ExtraOneComponent extends BaseListComponent implements OnInit {

  public data: any;
  public item: any;
  constructor(
    private extraoneService: ExtraoneService,
    private dl: DialogService,
    private message: NzMessageService,
    public exTableService: ExtentionTableService) {
    super();
  }

  ngOnInit() {
    this.getData();
  }

  openModal(item = null, isView = false) {
    this.item = item;
    this.id = item ? item.id : null;
    this.isView = isView;
    this.isShowModalData = true;
  }

  async  getData(page = 1) {
    this.data = null;
    this.listOfData = [];
    this.paging.page = page;
    // wwhere theo du lieu dau vao
    const where = { and: [] };
    if (where.and.length > 0) {
      this.paging.where = where;
    } else {
      return;
    }
    this.isLoading = true;
    const rs = await this.extraoneService.get(this.paging);
    this.isLoading = false;
    if (rs.ok) {
      console.log('Get tai lieu', rs.result.data);
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
      console.log(id);
      const rs = await this.extraoneService.delete(id);
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
