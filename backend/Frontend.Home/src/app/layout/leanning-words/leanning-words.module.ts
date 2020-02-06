import { LeanningWordsComponent } from './leanning-words.component';
import { LeanningWordsRouters } from './leanning-words.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [LeanningWordsComponent],
  imports: [
    CommonModule,
    LeanningWordsRouters
  ],
  exports: [LeanningWordsComponent]
})
export class LeanningWordsModule { }
