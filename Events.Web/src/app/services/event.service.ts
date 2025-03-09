import { Injectable } from '@angular/core';
import { HttpBaseService } from './http-base.service';

@Injectable({
  providedIn: 'root'
})
export class EventService extends HttpBaseService {

  constructor() { super();}

  getEvents(){
    return this.http.get(this.baseUrl + "Event/GetEvents")
  }
}
