import { Routes, RouterModule } from '@angular/router';
import { ExtraOneComponent } from './extra-one.component';

const routes: Routes = [
  { path: '', component: ExtraOneComponent },
];

export const ExtraoneRoutes = RouterModule.forChild(routes);
