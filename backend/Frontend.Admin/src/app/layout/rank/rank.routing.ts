import { RankComponent } from './rank.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: RankComponent },
];

export const RankRoutes = RouterModule.forChild(routes);
