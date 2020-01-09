import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      {
        path: 'bidding-model',
        loadChildren: () => import('./bidding-model/bidding-model.module').then(m => m.BiddingModelModule)
      }
    ]
  }
];

export const LayoutRoutes = RouterModule.forChild(routes);
