import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService, DataInfo } from './api.service';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'KsApp';
  data: DataInfo[] = [];

  constructor(private apiService: ApiService) {}

  getData() {
    return this.apiService.getData().pipe(tap((d) => {
        this.data = d;
    })).subscribe();
  }
}
