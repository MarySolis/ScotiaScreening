import { Component, OnInit } from '@angular/core';

import { MenuCategories, MenuService  } from './menu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'], 
  providers: [MenuService]
})

export class MenuComponent implements OnInit {
  menuCategories: MenuCategories[];

  constructor(private menuService: MenuService) { }

  ngOnInit() {
    this.menuCategories = [];
    this.menuService.getMenu()
      .subscribe(menuCategories => this.menuCategories = menuCategories);
  }
}