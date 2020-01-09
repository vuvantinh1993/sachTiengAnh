import { Routes, RouterModule } from '@angular/router';
import { CategoryFilmComponent } from './category-film.component';

const routes: Routes = [
  { path: '', component: CategoryFilmComponent },
];

export const CategoryFilmRoutes = RouterModule.forChild(routes);
