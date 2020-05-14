import { Routes, RouterModule } from '@angular/router';
import { WordFilmComponent } from './word-film.component';

const routes: Routes = [
  { path: '', component: WordFilmComponent },
];

export const WordFilmRoutes = RouterModule.forChild(routes);
