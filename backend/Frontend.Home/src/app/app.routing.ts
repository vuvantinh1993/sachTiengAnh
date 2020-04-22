import { Routes, RouterModule } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./layout/layout.module').then(m => m.LayoutModule),
    // canActivate: [AuthorizeGuard]
  },
  { path: '**', redirectTo: '' },
];

export const AppRoutes = RouterModule.forRoot(routes);
