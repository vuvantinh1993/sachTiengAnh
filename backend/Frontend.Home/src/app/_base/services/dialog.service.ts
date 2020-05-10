import { Injectable, TemplateRef } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd';
@Injectable({
  providedIn: 'root'
})
export class DialogService {

  constructor(private modalService: NzModalService
  ) { }

  public confirm(title: string, content: string) {
    return new Promise<boolean>((resolve, reject) => {
      this.modalService.confirm({
        nzTitle: title,
        nzContent: content,
        nzOnOk: () => resolve(true),
        nzOnCancel: () => resolve(false)
      });
    });
  }

  public alert(title: string, content: string) {
    return new Promise<boolean>((resolve, reject) => {
      this.modalService.success({
        nzTitle: title,
        nzContent: content,
        nzOnOk: () => resolve(true)
      });
    });
  }

  public error(title: string, content: string) {
    return new Promise<boolean>((resolve, reject) => {
      this.modalService.error({
        nzTitle: title,
        nzContent: content,
        nzOnOk: () => resolve(true)
      });
    });
  }
}
