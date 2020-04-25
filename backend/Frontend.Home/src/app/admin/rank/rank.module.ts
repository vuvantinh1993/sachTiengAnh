import { RankDataComponent } from './rank-data/rank-data.component';
import { RankComponent } from './rank.component';
import { RankRoutes } from './rank.routing';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormModule } from 'src/app/_base/modules/form/form.module';


@NgModule({
  declarations: [RankComponent, RankDataComponent],
  imports: [
    CommonModule,
    RankRoutes,
    FormModule,
    NgZorroAntdModule,
    RankRoutes
  ]
})
export class RankModule { }
