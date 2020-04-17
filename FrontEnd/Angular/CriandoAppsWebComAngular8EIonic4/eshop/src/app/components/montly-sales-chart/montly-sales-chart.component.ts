import { Component, AfterViewInit } from '@angular/core';
import { DataService } from 'src/app/data.service';

declare var Chart: any;

@Component({
  selector: 'app-montly-sales-chart',
  templateUrl: './montly-sales-chart.component.html',
  styleUrls: ['./montly-sales-chart.component.scss'],
})

export class MontlySalesChartComponent implements AfterViewInit {
  public data: any = null;

  constructor(private service: DataService) { }

  ngAfterViewInit(): void {
    this.service.getMonthlySalesChartData()
      .subscribe((res) => {
        this.data = res;
        this.render()
      });
  }

  render() {
    var el: any = document.getElementById('myChart');
    var ctx = el.getContext('2d');
    var myChart = new Chart(ctx, {
      type: 'bar',
      data: this.data,
      options: {
        scales: {
          yAxes: [
            {
              ticks: {
                beginAtZero: true
              }
            }
          ]
        }
      }
    });
  }
}
