import { FormModule } from './../../_base/modules/form/form.module';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { TipsRoutes } from './tips.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TipsComponent } from './tips.component';


@NgModule({
  declarations: [TipsComponent],
  imports: [
    CommonModule,
    TipsRoutes,
    FormModule,
    NgZorroAntdModule,
    TipsRoutes
  ]
})
export class TipsModule { }
