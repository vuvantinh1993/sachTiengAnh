import { TipsComponent } from './tips.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: TipsComponent },
];

export const TipsRoutes = RouterModule.forChild(routes);
