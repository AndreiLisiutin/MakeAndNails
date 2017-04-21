import { Injectable } from "@angular/core";
import { ErrorMessages } from "models/ErrorMessages";
import { Validator } from '@angular/forms';

/**
 * Сервис валидации контролов.
 */
@Injectable()
export class ValidationService {

	/**
	 * Сообщения об ошибках.
	 */
	private defaultMessages: ErrorMessages = {
		required: 'Это поле обязательно.',
		pattern: 'Значение поля задано некорректно.',
		minLength: 'Минимальная длина этого поля {0}!',
		maxLength: 'Максимальная длина этого поля {0}!',

		rangeLength: 'Это поле должно содержать адрес электронной почты.',
		min: 'Минимальное значение этого поля {0}.',
		gt: 'Значение этого поля должно быть больше {0}.',
		gte: 'Значение этого поля должно быть больше или равно {0}.',
		max: 'Максимальное значение этого поля {0}.',
		lt: 'Значение этого поля должно быть меньше {0}.',
		lte: 'Значение этого поля должно быть меньше или равно {0}.',
		range: 'Значение этого поля должно быть в следующем диапазоне: {0}.',
		digits: 'Это поле должно содержать только цифры.',
		number: 'Значение этого поля должно быть числом.',
		url: 'Значение этого поля должно быть корректным URL адресом.',
		email: 'Значение этого поля должно быть корректным адресом электронной почты.',
		date: 'Значение этого поля должно быть датой.',
		minDate: 'Минимальное значение этого поля {0}.',
		maxDate: 'Максиимальное значение этого поля {0}!',
		dateISO: 'Значение этого поля должно быть датой в формате ISO.',
		creditCard: 'Значение этого поля должно быть номером кредитной карты.',
		json: 'Значение этого поля должно быть JSON-объектом.',
		base64: 'Значение этого поля должно быть Base-64 строкой.',
		phone: 'Значение этого поля должно быть корректным номером телефона.',
		uuid: 'Значение этого поля должно быть корректным идентификатором.',
		equal: 'Значение этого поля должно быть равно {0}.',
		notEqual: 'Значение этого поля не должно быть равно {0}.',
		equalTo: 'Введенные значения должны совпадать.',
		notEqualTo: 'Введенные значения не должны совпадать.',

		unknownError: 'Значение поля задано некорректно.'
	};

	/**
	 * Получить текст ошибки.
	 * @param errorType Тип ошибки.
	 * @param validator Валидатор, который, предположительно, бросил ошибку.
	 */
	getErrorMessage(errorType: string, validator: any): string {
		var errorMessage: string = this.defaultMessages[errorType];

		switch (errorType) {
			case 'required':
			case 'base64':
			case 'creditCard':
			case 'date':
			case 'dateISO':
			case 'digits':
			case 'email':
			case 'json':
			case 'number':
			case 'url':
			case 'uuid':
			case 'phone':
				return errorMessage;
				
			case 'equal':
			case 'gt':
			case 'gte':
			case 'lt':
			case 'lte':
			case 'max':
			case 'maxDate':
			case 'min':
			case 'minDate':
			case 'notEqual':
				return this._stringFormat(errorMessage, validator && validator[errorType]);

			case 'equalTo':
			case 'notEqualTo':
				return this._stringFormat(errorMessage, validator && validator[errorType] && validator[errorType].value);
			case 'range':
			case 'rangeLength':
				return this._stringFormat(errorMessage, validator && validator[errorType] && validator[errorType].join(', '));

			default:
					return this.defaultMessages.unknownError;
		}
	}

	/**
	 * String.Format.
	 * @param text Шаблон.
	 * @param params Параметры.
	 */
	private _stringFormat(text: string, params: any): string {
		if (params) {
			if (!Array.isArray(params)) {
				params = [params];
			}

			params.forEach((value: any, index: number) => {
				text = text.replace(new RegExp('\\{' + index + '\\}', 'g'), value);
			});
		}

		return text;
	}
}
