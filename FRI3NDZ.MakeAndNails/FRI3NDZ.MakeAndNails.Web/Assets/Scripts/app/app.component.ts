import { Component } from '@angular/core';
import { OnInit } from '@angular/core';


@Component({
    selector: 'app',
    providers: [],
    template: `
<h1>{{title}}</h1>
  `
})
export class AppComponent implements OnInit {
    title = 'Привет, мир!';
    constructor() {
    }
    
    ngOnInit(): void {
    }
}