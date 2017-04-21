import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { AuthenticationService } from "services/authentication/authentication.service";
import { AuthHttp } from 'angular2-jwt';

/**
 * Корневой компонент приложения.
 */
@Component({
	selector: 'root',
	providers: [],
	moduleId: module.id,
	templateUrl: 'root.html',
	styles: ['.is-active {color: cornflowerblue;}']
})
export class RootComponent {
}