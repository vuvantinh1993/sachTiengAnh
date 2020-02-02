import { HomeRoutes } from './home.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { MenuModule } from 'src/app/_shared/menu/menu.module';


@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    HomeRoutes,
    MenuModule
  ],
  exports: [HomeComponent]
})
export class HomeModule { }
