import { ListWordsFilmComponent } from './list-words-film.component';
import { ListWordsFilmRouters } from './list-words-film.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormModule } from 'src/app/_base/modules/form/form.module';

@NgModule({
  declarations: [ListWordsFilmComponent],
  imports: [
    CommonModule,
    ListWordsFilmRouters,
    FormModule
  ]
})
export class ListWordsFilmModule { }
