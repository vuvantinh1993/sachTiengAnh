import { ShowProfileComponent } from './show-profile.component';
import { ShowProfileModuleRouters } from './show-profile.routing';
import { ProfileModule } from './../finish-cours/profile/profile.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [ShowProfileComponent],
  imports: [
    CommonModule,
    ProfileModule,
    ShowProfileModuleRouters
  ]
})
export class ShowProfileModule { }
