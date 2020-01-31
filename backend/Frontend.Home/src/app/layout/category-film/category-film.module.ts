import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryFilmRoutes } from './category-film.routing';
import { FormModule } from 'src/app/_base/modules/form/form.module';
import { ExtentionTableService } from 'src/app/_base/services/extention-table.service';
import { CategoryFilmComponent } from './category-film.component';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CategoryFilmDataModule } from './category-film-data/category-film-data.module';



@NgModule({
  declarations: [CategoryFilmComponent],
  exports: [CategoryFilmComponent],
  imports: [
    CommonModule,
    CategoryFilmRoutes,
    FormModule,
    NgZorroAntdModule,
    CategoryFilmDataModule
  ],
})
export class CategoryFilmModule { }
