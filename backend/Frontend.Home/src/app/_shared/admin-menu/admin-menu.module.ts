import { AdminMenuComponent } from './admin-menu.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    AdminMenuComponent
  ],
  declarations: [AdminMenuComponent]
})
export class AdminMenuModule { }
