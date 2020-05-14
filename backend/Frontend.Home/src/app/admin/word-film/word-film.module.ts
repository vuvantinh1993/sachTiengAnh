import { FormModule } from './../../_base/modules/form/form.module';
import { WordFilmRoutes } from './word-film.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WordFilmComponent } from './word-film.component';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { WordFilmDataComponent } from './word-film-data/word-film-data.component';
import { NzUploadModule } from 'ng-zorro-antd/upload';

@NgModule({
  declarations: [WordFilmComponent, WordFilmDataComponent],
  imports: [
    CommonModule,
    WordFilmRoutes,
    NgZorroAntdModule,
    FormModule,
    NzUploadModule
  ],
  exports: [WordFilmComponent]
})
export class WordFilmModule { }
