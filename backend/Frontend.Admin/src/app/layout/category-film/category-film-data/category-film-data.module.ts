import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryFilmDataComponent } from './category-film-data.component';
import { NgZorroAntdModule } from 'ng-zorro-antd';



@NgModule({
  declarations: [CategoryFilmDataComponent],
  exports: [CategoryFilmDataComponent],
  imports: [
    CommonModule,
    NgZorroAntdModule
  ]
})
export class CategoryFilmDataModule { }
