import { AuthGuard } from './../auth/auth.guard';
import { AdminComponent } from './Admin.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '', component: AdminComponent, canActivate: [AuthGuard], children: [
      { path: '', redirectTo: '/adminTinhdeptrai', pathMatch: 'full' }, // redirect to `first-component`
      { path: 'rank', loadChildren: () => import('./rank/rank.module').then(x => x.RankModule) },
      {
        path: 'user',
        loadChildren: () => import('./user/admin-user.module').then(m => m.AdminUserModule)
      },
      {
        path: 'tips',
        loadChildren: () => import('./tips/tips.module').then(m => m.TipsModule)
      },
      {
        path: 'category-film',
        loadChildren: () => import('./category-film/category-film.module').then(m => m.CategoryFilmModule)
      },
      {
        path: 'extra-one',
        loadChildren: () => import('./extra-one/extra-one.module').then(m => m.ExtraOneModule)
      }
    ]
  },
];

export const AdminRoutes = RouterModule.forChild(routes);
