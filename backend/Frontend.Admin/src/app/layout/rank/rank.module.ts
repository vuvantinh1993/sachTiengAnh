import { RankDataComponent } from './rank-data/rank-data.component';
import { RankComponent } from './rank.component';
import { RankRoutes } from './rank.routing';
import { FormModule } from './../../_base/modules/form/form.module';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


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
