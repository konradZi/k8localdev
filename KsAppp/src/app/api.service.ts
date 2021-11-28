import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getData(): Observable<DataInfo[]> {
    return this.http.get<DataInfo[]>(`${environment.api}/api/Proxy`);
  }

}

export interface DataInfo {
  date: Date;
  value: number;
}
