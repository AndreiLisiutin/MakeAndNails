import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";
import 'rxjs/add/operator/toPromise';
import { JwtHelper } from 'angular2-jwt';

import { TokenInfo, UserLoginModel } from 'models/viewModels/AuthenticationViewModels';

/**
 * Сервис аутентификации через jwt токены.
 */
@Injectable()
export class AuthenticationService {
	private jwtHelper: JwtHelper = new JwtHelper();
	/**
	 * Ключ, по которому лежит токен в sessionStorage.
	 */
	_TOKEN_KEY = "token";

	constructor(private http: Http)
	{ }

	/**
	 * Залогиниться.
	 * @param userName Данные для авторизации пользователя.
	 */
	login(userLoginModel: UserLoginModel): Promise<TokenInfo> {
		return this.http.post("/api/Authentication/Login", userLoginModel)
			.toPromise()
			.then((response) => {
				var result: TokenInfo = response.json() as TokenInfo;
				if (result) {
					sessionStorage.setItem(this._TOKEN_KEY, result.token);
				}
				return result;
			})
			.catch((error) => {
				this.handleError(error);
				return Promise.reject(error);
			});
	}

	/**
	 * Зарегистрировать нового пользователя.
	 * @param userLoginModel Данные для регистрации пользователя.
	 */
	register(userLoginModel: UserLoginModel): Promise<TokenInfo> {
		return this.http.post("/api/Authentication/SignUp", userLoginModel)
			.toPromise()
			.then((response) => {
				var result: TokenInfo = response.json() as TokenInfo;
				if (result) {
					sessionStorage.setItem(this._TOKEN_KEY, result.token);
				}
				return result;
			})
			.catch((error) => {
				this.handleError(error);
				return Promise.reject(error);
			});
	}

	/**
	 * Разлогиниться.
	 */
	logout(): void {
		sessionStorage.removeItem(this._TOKEN_KEY);
	}

	/**
	 * Получить токен из хранилища сессии.
	 */
	getToken(): string {
		return sessionStorage.getItem(this._TOKEN_KEY);
	}

	/**
	 * Проверить, аутентифицирован ли текущий пользователь.
	 */
	isAuthenticated(): boolean {
		var token = this.getToken();
		return token && !this.jwtHelper.isTokenExpired(token);
	}

	/**
	 * Получить инфу по токену. TODO: переписать на модель.
	 */
	getTokenInfo(): any {
		var token = this.getToken();
		return token && this.jwtHelper.decodeToken(token);
	}

	private handleError(error: any) {
		console.error('Ошибка: ', error);
	}
}