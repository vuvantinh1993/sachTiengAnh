import { NgZorroAntdModule } from 'ng-zorro-antd';
import { FormModule } from 'src/app/_base/modules/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import { UserRoutes } from './user.routing';



@NgModule({
  declarations: [UserComponent],
  imports: [
    CommonModule,
    UserRoutes,
    FormModule,
    NgZorroAntdModule
  ]
})
export class UserModule { }
