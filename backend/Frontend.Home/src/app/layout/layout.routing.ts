import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      {
        path: '',
        loadChildren: () => import('./home/home.module').then(m => m.HomeModule)
      },
      {
        path: 'extra-1',
        loadChildren: () => import('./list-words-film/list-words-film.module').then(m => m.ListWordsFilmModule)
      }
    ]
  }
];

export const LayoutRoutes = RouterModule.forChild(routes);
