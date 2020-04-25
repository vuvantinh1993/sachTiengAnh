import { ForbiddenComponent } from './forbidden.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: ForbiddenComponent },
];

export const ForbiddenRouters = RouterModule.forChild(routes);
