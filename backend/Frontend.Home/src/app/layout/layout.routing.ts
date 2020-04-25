import { AuthGuard } from './../auth/auth.guard';
import { UserComponent } from './user/user.component';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
  { path: 'user', component: UserComponent },
  {
    path: '', component: LayoutComponent, canActivate: [AuthGuard], children: [
      { path: '', redirectTo: '/home', pathMatch: 'full' }, // redirect to `first-component`
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
