import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-card-list',
  templateUrl: './card-list.component.html'
})
export class CardListComponent {
  public cards: CardArray[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<CardArray[]>(baseUrl + 'cards-list').subscribe(result => {
      this.cards = result;
    }, error => console.error(error));
  }
}

interface CardArray {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
