import { ForbiddenComponent } from './forbidden/forbidden.component';
import { UserComponent } from './user/user.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: () => import('./layout/layout.module').then(m => m.LayoutModule) },
  { path: 'user', component: UserComponent },
  // { path: 'forbidden', component: ForbiddenComponent },
  // {
  //   // path: 'adminTinhdeptrai', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
  // },
  // { path: '**', redirectTo: 'user/login' },
];

export const AppRoutes = RouterModule.forRoot(routes);
