import { UserRouters } from './user.routing';
import { RegistrationComponent } from './registration/registration.component';
import { FormModule } from './../../_base/modules/form/form.module';
import { UserComponent } from './user.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginTLNComponent } from './login-tln/login-tln.component';



@NgModule({
  declarations: [UserComponent],
  imports: [
    CommonModule,
    FormModule,
    UserRouters
  ],
  exports: [UserComponent]
})
export class UserModule { }
