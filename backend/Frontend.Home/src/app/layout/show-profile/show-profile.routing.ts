import { ShowProfileComponent } from './show-profile.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: ShowProfileComponent },
];

export const ShowProfileModuleRouters = RouterModule.forChild(routes);
