import { FormModule } from 'src/app/_base/modules/form/form.module';
import { ForbiddenRouters } from './forbidden.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ForbiddenComponent } from './forbidden.component';



@NgModule({
  declarations: [ForbiddenComponent],
  imports: [
    CommonModule,
    FormModule,
    ForbiddenRouters
  ],
  exports: [ForbiddenComponent]
})
export class ForbiddenModule { }
