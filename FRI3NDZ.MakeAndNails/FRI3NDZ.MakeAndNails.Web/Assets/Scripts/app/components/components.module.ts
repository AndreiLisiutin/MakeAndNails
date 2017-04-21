import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RoutingModule } from 'routing.module';
import { HttpModule } from "@angular/http";
import { CustomFormsModule } from 'ng2-validation';

import { AuthenticationModule } from 'services/authentication/authentication.module';
import { RootComponent } from 'components/root/root.component';
import { LoginComponent } from 'components/login/login.component';
import { RegistrationComponent } from 'components/registration/registration.component';
import { ValidationMessagesComponent } from 'components/validation-messages/validation-messages.component';

/**
 * Модуль регистрации компонентов приложения.
 */
@NgModule({
	imports: [
		FormsModule,
		HttpModule,
		BrowserModule,
		RoutingModule,
		CustomFormsModule
	],
	exports: [
		RootComponent,
		LoginComponent,
		RegistrationComponent,
		ValidationMessagesComponent
	],
	declarations: [
		RootComponent,
		LoginComponent,
		RegistrationComponent,
		ValidationMessagesComponent
	],
	providers: []
})
export class ComponentsModule { }
