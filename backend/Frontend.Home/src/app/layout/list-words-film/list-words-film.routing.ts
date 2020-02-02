import { ListWordsFilmComponent } from './list-words-film.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: ListWordsFilmComponent },
];

export const ListWordsFilmRouters = RouterModule.forChild(routes);
