import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CardListComponent } from './card-list.component';

var httpOptions = { headers: new HttpHeaders({ "Content-Type": "application/json" }) };

@Injectable({
  providedIn: 'root'
})
export class CardService {

  url = 'https://localhost:44354/api/Card';

  constructor(private http: HttpClient) { }

  //ListaCard(): Observable<CardService> {
  //  return this.http.get.apply()
  //}

 
}
