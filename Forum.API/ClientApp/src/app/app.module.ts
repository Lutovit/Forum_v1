import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';

import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { UserListComponent } from './user-list.component';

import { NotFoundComponent } from './not-found.component';

import { DataService } from './data.service';


// определение маршрутов
const appRoutes: Routes = [
    { path: '', component: UserListComponent },

    { path: '**', component: NotFoundComponent }
];


@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, UserListComponent,  NotFoundComponent],
    providers: [DataService], // регистрация сервисов
    bootstrap: [AppComponent]
})

export class AppModule { }