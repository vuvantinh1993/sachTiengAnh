import { ListWordsFilmComponent } from './list-words-film.component';
import { ListWordsFilmRouters } from './list-words-film.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [ListWordsFilmComponent],
  imports: [
    CommonModule,
    ListWordsFilmRouters
  ]
})
export class ListWordsFilmModule { }
