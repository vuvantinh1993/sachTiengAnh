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
      },
      {
        path: 'extra-one',
        loadChildren: () => import('./extra-one/extra-one.module').then(m => m.ExtraOneModule)
      },
      {
        path: 'user',
        loadChildren: () => import('./user/user.module').then(m => m.UserModule)
      },
      {
        path: 'tips',
        loadChildren: () => import('./tips/tips.module').then(m => m.TipsModule)
      }
    ]
  }
];

export const LayoutRoutes = RouterModule.forChild(routes);
