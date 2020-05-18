import { HomeComponent } from './home/home.component';
import { AuthGuard } from './../auth/auth.guard';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
  {
    path: '', component: LayoutComponent, canActivate: [AuthGuard], children: [
      {
        path: 'home',
        loadChildren: () => import('./home/home.module').then(m => m.HomeModule)
      },
      {
        path: 'phim/:id',
        loadChildren: () => import('./list-words-film/list-words-film.module').then(m => m.ListWordsFilmModule)
      },
      {
        path: 'leanning-words/:style/:idfilm',
        loadChildren: () => import('./leanning-words/leanning-words.module').then(m => m.LeanningWordsModule)
      },
      {
        path: 'finish-cours/:idfilm/:point',
        loadChildren: () => import('./finish-cours/finish-cours.module').then(m => m.FinishCoursModule)
      },
      {
        path: 'profile',
        loadChildren: () => import('./show-profile/show-profile.module').then(m => m.ShowProfileModule)
      }
    ]
  }
];

export const LayoutRoutes = RouterModule.forChild(routes);
