import { AdminMenuModule } from './../_shared/admin-menu/admin-menu.module';
import { AdminNavbarModule } from './../_shared/admin-navbar/admin-navbar.module';
import { AdminFooterModule } from './../_shared/admin-footer/admin-footer.module';
import { FormModule } from './../_base/modules/form/form.module';
import { AdminComponent } from './Admin.component';
import { AdminRoutes } from './Admin.routing';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [AdminComponent],
  imports: [
    CommonModule,
    AdminRoutes,
    FormModule,
    NgZorroAntdModule,
    AdminRoutes,
    AdminFooterModule,
    AdminNavbarModule,
    AdminMenuModule
  ]
})
export class AdminModule { }
