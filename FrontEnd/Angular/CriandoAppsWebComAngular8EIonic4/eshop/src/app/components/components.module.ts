import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingComponent } from './loading/loading.component';
import { IonicModule } from '@ionic/angular';
import { MontlySalesChartComponent } from './montly-sales-chart/montly-sales-chart.component';
import { NavbarComponent } from './navbar/navbar.component';
import { UserCardComponent } from './user-card/user-card.component';

@NgModule({
  declarations: [
    LoadingComponent,
    MontlySalesChartComponent,
    NavbarComponent,
    UserCardComponent
  ],
  imports: [
    CommonModule,
    IonicModule
  ],
  exports: [
    LoadingComponent,
    MontlySalesChartComponent,
    NavbarComponent,
    UserCardComponent
  ]
})
export class ComponentsModule { }
