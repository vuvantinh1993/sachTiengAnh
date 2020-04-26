import { FormModule } from './../../_base/modules/form/form.module';
import { RegistrationRouters } from './registration.routing';
import { RegistrationComponent } from './registration.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [RegistrationComponent],
  imports: [
    CommonModule,
    FormModule,
    RegistrationRouters
  ],
  exports: [RegistrationComponent]
})
export class RegistrationModule { }
