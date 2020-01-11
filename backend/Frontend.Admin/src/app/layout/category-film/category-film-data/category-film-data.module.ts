import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryFilmDataComponent } from './category-film-data.component';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { FormModule } from 'src/app/_base/modules/form/form.module';



@NgModule({
  declarations: [CategoryFilmDataComponent],
  exports: [CategoryFilmDataComponent],
  imports: [
    CommonModule,
    NgZorroAntdModule,
    FormModule
  ]
})
export class CategoryFilmDataModule { }
