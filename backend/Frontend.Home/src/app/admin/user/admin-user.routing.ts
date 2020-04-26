import { AdminUserComponent } from './admin-user.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: AdminUserComponent },
];

export const AdminUserRoutes = RouterModule.forChild(routes);
