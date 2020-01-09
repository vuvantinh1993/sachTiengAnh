import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      {
        path: 'bidding-model',
        loadChildren: () => import('./bidding-model/bidding-model.module').then(m => m.BiddingModelModule)
      },
      {
        path: 'category-film',
        loadChildren: () => import('./category-film/category-film.module').then(m => m.CategoryFilmModule)
      }
    ]
  }
];

export const LayoutRoutes = RouterModule.forChild(routes);
