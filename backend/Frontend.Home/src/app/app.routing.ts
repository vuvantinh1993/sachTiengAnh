import { AuthGuard } from './auth/auth.guard';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { UserComponent } from './user/user.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'user', component: UserComponent },
  { path: 'forbidden', loadChildren: () => import('./forbidden/forbidden.module').then(m => m.ForbiddenModule) },
  { path: '', loadChildren: () => import('./layout/layout.module').then(m => m.LayoutModule), pathMatch: 'full' },
  { path: 'adminTinhdeptrai', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule) },
  { path: 'notExist', loadChildren: () => import('./forbidden/forbidden.module').then(m => m.ForbiddenModule) },
  { path: '**', redirectTo: 'notExist' },
];

export const AppRoutes = RouterModule.forRoot(routes);
