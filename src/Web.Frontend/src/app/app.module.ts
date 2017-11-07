import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { SignalRService, DevicesService } from 'services';

import { BingMapDirective } from 'directives';

import { AppComponent } from './app.component';
import { DashboardComponent } from 'dashboard';

@NgModule({
    declarations: [
        AppComponent,
        DashboardComponent,
        BingMapDirective
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    providers: [
        SignalRService,
        DevicesService
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }