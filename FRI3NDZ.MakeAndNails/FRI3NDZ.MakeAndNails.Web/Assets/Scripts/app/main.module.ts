import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from "@angular/http";
import { Http, RequestOptions } from '@angular/http';
import { RouterModule } from '@angular/router';

import { RootComponent } from 'components/root/root.component';
import { ComponentsModule } from 'components/components.module';
import { ServicesModule } from 'services/services.module';
import { RoutingModule } from 'routing.module';
import { AuthenticationModule } from 'services/authentication/authentication.module';
/**
 * Главный модуль приложения.
 */
@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
		FormsModule,
		RouterModule,
		ComponentsModule,
		ServicesModule,
		RoutingModule,
		AuthenticationModule
    ],
    declarations: [],
	bootstrap: [RootComponent],
	providers: []
})
export class MainModule { }
