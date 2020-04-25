import { AdminNavbarComponent } from './admin-navbar.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    AdminNavbarComponent
  ],
  declarations: [AdminNavbarComponent]
})
export class AdminNavbarModule { }
