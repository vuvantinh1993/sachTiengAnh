import { LoginTLNComponent } from './user/login-tln/login-tln.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      {
        path: '',
        loadChildren: () => import('./user/user.module').then(m => m.UserModule)
      },
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
      }
    ]
  }
];

export const LayoutRoutes = RouterModule.forChild(routes);
