import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { AuthenticationService } from "services/authentication/authentication.service";
import { AuthHttp } from 'angular2-jwt';
import { TokenInfo, UserLoginModel } from 'models/viewModels/AuthenticationViewModels';

/**
 * Компонент регистрации нового пользователя.
 */
@Component({
	selector: 'registration',
	moduleId: module.id,
	templateUrl: 'registration.html',
	styleUrls: []
})
export class RegistrationComponent implements OnInit {
	/**
	 * Модель логина.
	 */
	private userLoginModel: UserLoginModel;

	/**
	 * Конструктор компонента регистрации нового пользователя.
	 * @param authService Сервис аутентификации.
	 */
	constructor(private authService: AuthenticationService) {
	}

	/**
	 * Обработчик загрузки компонента.
	 */
	ngOnInit(): void {
		this.userLoginModel = new UserLoginModel();
	}

	/**
	 * Зарегистрироваться в приложении.
	 */
	login() {
		this.authService.register(this.userLoginModel)
			.then((result: TokenInfo) => {
				console.log('Регистрация успешна: ' + JSON.stringify(result));
			})
			.catch(error => {
				alert(error.text && error.text() || 'Ошибка.');
			});
	}

	/**
	 * Тест - проверить логин через запрос по защищенному маршруту.
	 */
	checkLogin() {
		var tokenInfo = this.authService.getTokenInfo();
		console.log('Инфа о токене: ' + JSON.stringify(tokenInfo));
	}
}
