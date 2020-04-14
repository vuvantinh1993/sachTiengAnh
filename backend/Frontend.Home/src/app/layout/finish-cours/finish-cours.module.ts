import { FinishCoursComponent } from './finish-cours.component';
import { FinishCoursModuleRouters } from './finish-cours.routing';
import { FormModule } from './../../_base/modules/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [FinishCoursComponent],
  imports: [
    CommonModule,
    FormModule,
    FinishCoursModuleRouters
  ]
})
export class FinishCoursModule { }
