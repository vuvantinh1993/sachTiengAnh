import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/_base/components/base-list-component';
import { CategoryFilmService } from 'src/app/_shared/services/categoryfilm.service';
import { ExtensionService } from 'src/app/_base/services/extension.service';
import { ExtentionTableService } from 'src/app/_base/services/extention-table.service';
import { DialogService } from 'src/app/_base/services/dialog.service';
import { NzMessageService } from 'ng-zorro-antd';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-category-film',
  templateUrl: './category-film.component.html',
  styleUrls: ['./category-film.component.scss']
})
export class CategoryFilmComponent extends BaseListComponent implements OnInit {

  public item: any;
  public listStatus: any[];
  public name = 'danh mục phim';
  constructor(
    private categoryfilmservice: CategoryFilmService,
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
        const delObj = await this.categoryfilmservice.delete(item.id);
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
      const rs = await this.categoryfilmservice.delete(id);
      this.ex.logDebug('Delete response', rs);
      if (rs.ok) {
        this.getData(this.paging.page);
        this.message.success('Xóa dữ liệu thành công');
      }
    }
  }

  addData(value: any) {
    if (!!value) {
      this.getData(this.paging.page);
    }
  }

  async getData(page = 1) {
    this.paging.page = page;
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
    const rs = await this.categoryfilmservice.get(this.paging);
    this.isLoading = false;
    if (rs.ok) {
      this.listOfData = rs.result.data;
      this.paging = rs.result.paging;
      console.log('getdata', this.listOfData);
    }
  }
}
