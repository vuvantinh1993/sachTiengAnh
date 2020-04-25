import { ForbiddenComponent } from './layout/forbidden/forbidden.component';
import { LayoutComponent } from './layout/layout.component';
import { UserComponent } from './layout/user/user.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
  {
    path: '', loadChildren: () => import('./layout/layout.module').then(m => m.LayoutModule)
  },
  { path: 'forbidden', component: ForbiddenComponent },
  {
    path: 'adminTinhdeptrai', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
  },
  { path: '**', redirectTo: '' },
];

export const AppRoutes = RouterModule.forRoot(routes);
