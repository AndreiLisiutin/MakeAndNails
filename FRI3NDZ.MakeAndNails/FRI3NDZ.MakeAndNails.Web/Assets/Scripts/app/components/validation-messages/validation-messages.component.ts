import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, AbstractControl, Validator } from '@angular/forms';
import { ValidationService } from "services/validation.service";

/**
 * Компонент валидации поля.
 */
@Component({
	selector: 'validation-messages',
	template: `<div *ngIf="errorMessage !== null">{{errorMessage}}</div>`
})
export class ValidationMessagesComponent {
	/**
	 * Контрол на форме, который проверяется.
	 */
	@Input() control: AbstractControl;
	/**
	 * CSS-класс для дива с ошибками.
	 */
	@Input() class: string;

	/**
	 * Конструктор компонента валидации поля.
	 * @param validationService Сервис валидации, где прописаны тексты ошибок.
	 */
	constructor(private validationService: ValidationService) {
	}

	/**
	 * Сообщение об ошибке, полученное для контрола, или NULL.
	 */
	get errorMessage(): string {
		//получение валидатора, который бросил ошибку
		var validators: Array<Validator> = [];

		try {
			validators = (this.control as any)._rawValidators as Array<Validator>;
			var errorValidator: any = {};
			if (validators) {
				for (let validator of validators) {
					var error: any = validator.validate(this.control);
					if (!error) {
						continue;
					}
					for (var name in error) {
						errorValidator[name] = validator;
					}
				}
			}
		} catch (ex) {
			console.log(ex);
		}

		//получаем сообщение об ошибке
		for (let propertyName in this.control.errors) {
			if (this.control.errors.hasOwnProperty(propertyName) && this.control.touched) {
				return this.validationService.getErrorMessage(propertyName, errorValidator[propertyName]);
			}
		}

		return null;
	}

	ngOnInit(): void {
		this._mergeWithLocalConfiguration();
	}

	/**
	 * Поставить класс дива с ошибкой по умолчанию.
	 */
	private _mergeWithLocalConfiguration(): void {
		if (!this.class) {
			this.class = 'has-error';
		}
	}
}