import { LoginTLNComponent } from './login-tln.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: LoginTLNComponent },
];

export const LoginTLNRouters = RouterModule.forChild(routes);
