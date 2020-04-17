import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingComponent } from './loading/loading.component';
import { IonicModule } from '@ionic/angular';
import { MontlySalesChartComponent } from './montly-sales-chart/montly-sales-chart.component';

@NgModule({
  declarations: [
    LoadingComponent,
    MontlySalesChartComponent
  ],
  imports: [
    CommonModule,
    IonicModule
  ],
  exports: [
    LoadingComponent,
    MontlySalesChartComponent
  ]
})
export class ComponentsModule { }
