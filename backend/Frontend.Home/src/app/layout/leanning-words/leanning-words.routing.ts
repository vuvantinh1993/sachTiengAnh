import { LeanningWordsComponent } from './leanning-words.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: LeanningWordsComponent },
];

export const LeanningWordsRouters = RouterModule.forChild(routes);
