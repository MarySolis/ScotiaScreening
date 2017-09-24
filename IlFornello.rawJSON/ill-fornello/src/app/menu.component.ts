import { Component, Input } from '@angular/core';
import { Http }      from '@angular/http';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {  
    menu;
 
    constructor(private http:Http) {
        this.http.get('./assets/menu.json')
                 .subscribe(res => this.menu = res.json());
    }
}