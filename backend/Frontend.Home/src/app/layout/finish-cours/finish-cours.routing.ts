import { FinishCoursComponent } from './finish-cours.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: FinishCoursComponent },
];

export const FinishCoursModuleRouters = RouterModule.forChild(routes);
