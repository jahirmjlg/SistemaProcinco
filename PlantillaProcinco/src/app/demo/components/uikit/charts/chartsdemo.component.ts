import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription, debounceTime } from 'rxjs';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import {CursosImpartidosService} from '../../../../Services/cursosimpartidos.service'
import { Chart, registerables  } from 'chart.js/auto';
import ChartDataLabels from 'chartjs-plugin-datalabels';

@Component({
    templateUrl: './chartsdemo.component.html'
})
export class ChartsDemoComponent implements OnInit, OnDestroy {



    //DATOS DASH #1
    cursosBarData: any;
    categoriasBarData: any;
    empleadosBarData: any;
    horasBarData: any;
    barOptions: any;
    selectedMes: number;
    cursosChart: any;
    categoriasChart: any;
    empleadosChart: any;
    horasChart: any;


    meses = [
      { value: 1, label: 'Enero' },
      { value: 2, label: 'Febrero' },
      { value: 3, label: 'Marzo' },
      { value: 4, label: 'Abril' },
      { value: 5, label: 'Mayo' },
      { value: 6, label: 'Junio' },
      { value: 7, label: 'Julio' },
      { value: 8, label: 'Agosto' },
      { value: 9, label: 'Septiembre' },
      { value: 10, label: 'Octubre' },
      { value: 11, label: 'Noviembre' },
      { value: 12, label: 'Diciembre' }
    ];

    subscription: Subscription;
    constructor(private cursosimpservice: CursosImpartidosService) {

        Chart.register(...registerables, ChartDataLabels);
    }

    ngOnInit() {
        this.selectedMes = new Date().getMonth() + 1;
        this.loadChartData();
        this.initializeChartOptions();
    }


    onMonthChange(event: any): void {
        const mes = event.target.value;
        console.log(`Mes seleccionado: ${mes}`);
        this.selectedMes = mes;
        this.loadChartData();
      }



      loadChartData(): void {
        this.loadCursosChartData(this.selectedMes);
        this.loadCategoriasChartData(this.selectedMes);
        this.loadEmpleadosChartData(this.selectedMes);
        this.loadHorasChartData(this.selectedMes);
      }





      ngOnDestroy() {
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }




    loadCursosChartData(mes: number): void {
        console.log(`Cargando datos de cursos para el mes: ${mes}`);
        this.cursosimpservice.getCursosImpartidosTop5PorMeses(mes).subscribe(data => {
          console.log('Datos de cursos recibidos:', data);
          const cursos = data.map((curso: any) => curso.curso_Descripcion);
          const vecesImpartido = data.map((curso: any) => curso.vecesImpartido);

          const backgroundColors = [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)'
          ];

          const borderColors = [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)'
          ];

          this.cursosBarData = {
            labels: cursos,
            datasets: [{
              label: 'Veces Impartido',
              data: vecesImpartido,
              backgroundColor: backgroundColors,
              borderColor: borderColors,
              borderWidth: 1
            }]
          };

          this.renderCursosChart();
        }, error => {
          console.error('Error al cargar los datos de cursos:', error);
        });
      }

      loadCategoriasChartData(mes: number): void {
        console.log(`Cargando datos de categorías para el mes: ${mes}`);
        this.cursosimpservice.getCursosImpartidosCategoriasMES(mes).subscribe(data => {
          console.log('Datos de categorías recibidos:', data);
          const categorias = data.map((categoria: any) => categoria.cate_Descripcion);
          const vecesImpartido = data.map((categoria: any) => categoria.vecesImpartido);

          const backgroundColors = [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)'
          ];

          const borderColors = [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)'
          ];

          this.categoriasBarData = {
            labels: categorias,
            datasets: [{
              label: 'Veces Impartido',
              data: vecesImpartido,
              backgroundColor: backgroundColors,
              borderColor: borderColors,
              borderWidth: 1
            }]
          };

          this.renderCategoriasChart();
        }, error => {
          console.error('Error al cargar los datos de categorías:', error);
        });
      }

      loadEmpleadosChartData(mes: number): void {
        console.log(`Cargando datos de empleados para el mes: ${mes}`);
        this.cursosimpservice.getEmpleadosMejorPagadosFiltro(mes).subscribe(data => {
          console.log('Datos de empleados recibidos:', data);
          const empleados = data.map((empleado: any) => `${empleado.empl_Nombre}`);
          const totalPagado = data.map((empleado: any) => empleado.empl_Total);

          const backgroundColors = [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)'
          ];

          const borderColors = [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)'
          ];

          this.empleadosBarData = {
            labels: empleados,
            datasets: [{
              label: 'Total Pagado',
              data: totalPagado,
              backgroundColor: backgroundColors,
              borderColor: borderColors,
              borderWidth: 1
            }]
          };

          this.renderEmpleadosChart();
        }, error => {
          console.error('Error al cargar los datos de empleados:', error);
        });
      }

      loadHorasChartData(mes: number): void {
        console.log(`Cargando datos de horas impartidas por categoría para el mes: ${mes}`);
        this.cursosimpservice.getHorasImpartidasPorCategoriaFiltrado(mes).subscribe(data => {
          console.log('Datos de horas impartidas por categoría recibidos:', data);
          const categorias = data.map((categoria: any) => categoria.cate_Descripcion);
          const horasImpartidas = data.map((categoria: any) => categoria.curso_DuracionHoras);

          const backgroundColors = [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)'
          ];

          const borderColors = [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)'
          ];

          this.horasBarData = {
            labels: categorias,
            datasets: [{
              label: 'Horas Impartidas',
              data: horasImpartidas,
              backgroundColor: backgroundColors,
              borderColor: borderColors,
              borderWidth: 1
            }]
          };

          this.renderHorasChart();
        }, error => {
          console.error('Error al cargar los datos de horas impartidas por categoría:', error);
        });
      }

      initializeChartOptions(): void {
        const textColor = '#495057';
        const textColorSecondary = '#6c757d';
        const surfaceBorder = '#dee2e6';

        this.barOptions = {
          plugins: {
            legend: {
              labels: {
                color: textColor
              }
            },
            datalabels: {
              anchor: 'end',
              align: 'top',
              color: textColor,
              font: {
                weight: 'bold'
              },
              formatter: (value: any) => {
                return value;
              }
            }
          },
          scales: {
            x: {
              ticks: {
                color: textColorSecondary,
                font: {
                  weight: 500
                }
              },
              grid: {
                display: false,
                drawBorder: false
              }
            },
            y: {
              ticks: {
                color: textColorSecondary
              },
              grid: {
                color: surfaceBorder,
                drawBorder: false
              }
            }
          }
        };
      }

      renderCursosChart(): void {
        const canvas = document.getElementById('cursosChart') as HTMLCanvasElement;
        if (canvas) {
          if (this.cursosChart) {
            this.cursosChart.destroy();
          }
          const ctx = canvas.getContext('2d');
          if (ctx) {
            this.cursosChart = new Chart(ctx, {
              type: 'bar',
              data: this.cursosBarData,
              options: this.barOptions
            });
          }
        }
      }

      renderCategoriasChart(): void {
        const canvas = document.getElementById('categoriasChart') as HTMLCanvasElement;
        if (canvas) {
          if (this.categoriasChart) {
            this.categoriasChart.destroy();
          }
          const ctx = canvas.getContext('2d');
          if (ctx) {
            this.categoriasChart = new Chart(ctx, {
              type: 'bar',
              data: this.categoriasBarData,
              options: this.barOptions
            });
          }
        }
      }

      renderEmpleadosChart(): void {
        const canvas = document.getElementById('empleadosChart') as HTMLCanvasElement;
        if (canvas) {
          if (this.empleadosChart) {
            this.empleadosChart.destroy();
          }
          const ctx = canvas.getContext('2d');
          if (ctx) {
            this.empleadosChart = new Chart(ctx, {
              type: 'bar',
              data: this.empleadosBarData,
              options: this.barOptions
            });
          }
        }
      }

      renderHorasChart(): void {
        const canvas = document.getElementById('horasChart') as HTMLCanvasElement;
        if (canvas) {
          if (this.horasChart) {
            this.horasChart.destroy();
          }
          const ctx = canvas.getContext('2d');
          if (ctx) {
            this.horasChart = new Chart(ctx, {
              type: 'bar',
              data: this.horasBarData,
              options: this.barOptions
            });
          }
        }
      }


}
