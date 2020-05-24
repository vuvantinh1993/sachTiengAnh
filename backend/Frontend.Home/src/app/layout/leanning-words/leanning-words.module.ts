import { FormModule } from './../../_base/modules/form/form.module';
import { LeanningWordsComponent } from './leanning-words.component';
import { LeanningWordsRouters } from './leanning-words.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgZorroAntdModule } from 'ng-zorro-antd';




@NgModule({
  declarations: [LeanningWordsComponent],
  imports: [
    CommonModule,
    LeanningWordsRouters,
    FormModule,
    CommonModule,
    NgZorroAntdModule,
  ],
  exports: [LeanningWordsComponent]
})
export class LeanningWordsModule { }
