import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      {
        path: '',
        loadChildren: () => import('./home/home.module').then(m => m.HomeModule)
      },
      {
        path: 'login',
        loadChildren: () => import('./login/login.module').then(m => m.LoginModule)
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
        path: 'finish-cours/:idfilm/:sttword/:point',
        loadChildren: () => import('./finish-cours/finish-cours.module').then(m => m.FinishCoursModule)
      }
    ]
  }
];

export const LayoutRoutes = RouterModule.forChild(routes);
