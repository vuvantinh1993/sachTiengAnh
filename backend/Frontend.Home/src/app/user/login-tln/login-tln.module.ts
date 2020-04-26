import { FormModule } from './../../_base/modules/form/form.module';
import { LoginTLNRouters } from './login-tln.routing';
import { LoginTLNComponent } from './login-tln.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [LoginTLNComponent],
  imports: [
    CommonModule,
    FormModule,
    LoginTLNRouters
  ],
  exports: [LoginTLNComponent]
})
export class LoginTLNModule { }
