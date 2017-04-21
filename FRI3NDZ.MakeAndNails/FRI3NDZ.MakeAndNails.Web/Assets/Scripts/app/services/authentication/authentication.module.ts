import { NgModule } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { AuthHttp, AuthConfig } from 'angular2-jwt';
import { AuthenticationService } from "services/authentication/authentication.service";

/**
 * Фабрика сервиса AuthHttp.
 * @param http Http сервис.
 * @param options Опции http запроса.
 * @param authenticationService Сервис авторизации.
 */
function authHttpServiceFactory(http: Http, options: RequestOptions, authenticationService: AuthenticationService) {
	return new AuthHttp(new AuthConfig({
		tokenName: authenticationService._TOKEN_KEY,
		tokenGetter: (() => authenticationService.getToken()),
		globalHeaders: [{ 'Content-Type': 'application/json' }],
	}), http, options);
}

/**
 * Модуль аутентификации.
 */
@NgModule({
	providers: [
		AuthenticationService,
		{
			provide: AuthHttp,
			useFactory: authHttpServiceFactory,
			deps: [Http, RequestOptions, AuthenticationService]
		}
	]
})
export class AuthenticationModule { }
