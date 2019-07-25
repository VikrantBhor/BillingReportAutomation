import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { SharedObject } from "../DTO/SharedObject";


@Injectable()
export class DataService {

  private _sharedData = new BehaviorSubject<SharedObject>(new SharedObject('', '', '', '', '', '','','','','',''));
  currentSharedData = this._sharedData.asObservable();

  constructor() {

  }

  changeMessage(_data: SharedObject) {
    this._sharedData.next(_data);
  }
  
}
