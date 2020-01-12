import { FormModule } from './../../_base/modules/form/form.module';
import { ExtraoneRoutes } from './extra-one.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExtraOneComponent } from './extra-one.component';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { ExtraOneDataComponent } from './extra-one-data/extra-one-data.component';
import { NzUploadModule } from 'ng-zorro-antd/upload';

@NgModule({
  declarations: [ExtraOneComponent, ExtraOneDataComponent],
  imports: [
    CommonModule,
    ExtraoneRoutes,
    NgZorroAntdModule,
    FormModule,
    NzUploadModule
  ],
  exports: [ExtraOneComponent]
})
export class ExtraOneModule { }
