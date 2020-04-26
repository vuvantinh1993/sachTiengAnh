import { AdminUserDataComponent } from './admin-user-data/admin-user-data.component';
import { AdminUserComponent } from './admin-user.component';
import { AdminUserRoutes } from './admin-user.routing';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { FormModule } from 'src/app/_base/modules/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';




@NgModule({
  declarations: [AdminUserComponent, AdminUserDataComponent],
  imports: [
    CommonModule,
    AdminUserRoutes,
    FormModule,
    NgZorroAntdModule
  ]
})
export class AdminUserModule { }
