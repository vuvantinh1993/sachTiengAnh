import { RegistrationComponent } from './registration.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: RegistrationComponent },
];

export const RegistrationRouters = RouterModule.forChild(routes);
