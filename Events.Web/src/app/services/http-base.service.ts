import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpBaseService {
  http = inject(HttpClient);
  baseUrl = environment.apiUrl;

  constructor() { }
}
