import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { CardComponent } from './components/card/card.component';
import { ButtonComponent } from './components/button/button.component';
import { UserCardComponent } from './components/user-card/user-card.component';
import { TabsComponent } from './components/tabs/tabs.component';
import { TodoListComponent } from './components/todo-list/todo-list.component';

import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { AllComponent } from './pages/all/all.component';
import { TodayComponent } from './pages/today/today.component';
import { TomorrowComponent } from './pages/tomorrow/tomorrow.component';
import { NewComponent } from './pages/new/new.component';
import { environment } from 'src/environments/environment';

import { AngularFireModule } from '@angular/fire';

@NgModule({
  declarations: [
    //Componentes
    AppComponent,
    CardComponent,
    ButtonComponent,
    UserCardComponent,
    TabsComponent,
    TodoListComponent,

    //Paginas
    LoginComponent,
    HomeComponent,
    AllComponent,
    TodayComponent,
    TomorrowComponent,
    NewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularFireModule.initializeApp(environment.firebase),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
