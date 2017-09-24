import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

export class MenuCategories {
  categoryName: string;
  dishes: string[];
}

@Injectable()
export class MenuService {
  constructor(private http: Http) { }

  getMenu() {
    return this.http
      .get('./assets/menu.json')
      .map((response: Response) => <MenuCategories[]>response.json().categories);     
  }

  private handleError(error: Response) {
    console.error(error);
    let msg = `Error status code ${error.status} at ${error.url}`;
    return Observable.throw(msg);
  }
}