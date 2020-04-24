import { UserComponent } from './user.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  // { path: '', component: UserComponent },
  {
    path: '', component: UserComponent, children: [
      { path: '', redirectTo: '/login', pathMatch: 'full' }, // redirect to `first-component`
      { path: 'login', loadChildren: () => import('./login-tln/login-tln.module').then(x => x.LoginTLNModule) },
      { path: 'registration', loadChildren: () => import('./registration/registration.module').then(x => x.RegistrationModule) },
    ]
  },
];

export const UserRouters = RouterModule.forChild(routes);
