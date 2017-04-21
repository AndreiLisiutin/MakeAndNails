import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RootComponent } from 'components/root/root.component';
import { LoginComponent } from 'components/login/login.component';
import { RegistrationComponent } from 'components/registration/registration.component';
import { AuthenticationModule } from 'services/authentication/authentication.module';

/**
 * Маршруты приложения.
 */
const routes: Routes = [
	{ path: '', pathMatch: 'full', redirectTo: 'login' },
	{ path: 'register', component: RegistrationComponent },
	{ path: 'login', component: LoginComponent }
];

/**
 * Модуль навигации.
 */
@NgModule({
	imports: [RouterModule.forRoot(routes, { useHash: true })],
	exports: [RouterModule]
})
export class RoutingModule { }