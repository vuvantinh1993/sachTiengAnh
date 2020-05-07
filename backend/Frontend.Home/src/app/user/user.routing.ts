import { UserComponent } from './user.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '', component: UserComponent, children: [
      { path: '', redirectTo: 'user/login', pathMatch: 'full' }, // redirect to `first-component`
      { path: 'user', redirectTo: 'user/login', pathMatch: 'full' }, // redirect to `first-component`
      { path: 'user/login', loadChildren: () => import('./login-tln/login-tln.module').then(x => x.LoginTLNModule) },
      { path: 'user/registration', loadChildren: () => import('./registration/registration.module').then(x => x.RegistrationModule) },
    ]
  },
];

export const UserRouters = RouterModule.forChild(routes);
