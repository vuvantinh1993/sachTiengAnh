import { Injectable } from '@angular/core';
import { BehaviorSubject, concat, from, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Common {


  private static openComponentViewFinishSource = new BehaviorSubject(true);
  public static currentOpenComponentViewFinish = Common.openComponentViewFinishSource.asObservable();

  private static idFilmSource = new BehaviorSubject(0);
  public static currentIdFilm = Common.idFilmSource.asObservable();
  private static sttWordSource = new BehaviorSubject(0);
  public static currentSttWord = Common.sttWordSource.asObservable();

  public static observable: any;

  static ChangeOpenComponentViewFinish(isShow: boolean) {
    this.openComponentViewFinishSource.next(isShow);
  }
  static ChangeidFilm(idFilm: number) {
    this.idFilmSource.next(idFilm);
    this.idFilmSource.subscribe(e => {
      if (e === 0) {
        Common.ChangeOpenComponentViewFinish(true);
      } else {
        Common.ChangeOpenComponentViewFinish(false);
      }
    });
  }

  static ChangesttWord(sttWord: number) {
    this.sttWordSource.next(sttWord);
  }
}
