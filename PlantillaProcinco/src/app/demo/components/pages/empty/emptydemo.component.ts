import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription, debounceTime } from 'rxjs';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import { CursosImpartidosService } from '../../../../Services/cursosimpartidos.service';
import { Chart, registerables  } from 'chart.js/auto';
import ChartDataLabels from 'chartjs-plugin-datalabels';

@Component({
    templateUrl: './emptydemo.component.html'
})
export class EmptyDemoComponent implements OnInit, OnDestroy {

    barData: any;
    pieData: any;
    polarData: any;
    radarData: any;
    lineOptions: any;
    barOptions: any;
    pieOptions: any;
    polarOptions: any;
    radarOptions: any;
    subscription: Subscription;

    // Variables para almacenar los datos del dashboard
    cursosTop5Mes: any;
    cursosCategorias: any;
    empleadosMejorPagados: any;
    horasPorCategoria: any;

    constructor(private layoutService: LayoutService, private cursosimpservice: CursosImpartidosService) {
        this.subscription = this.layoutService.configUpdate$
            .pipe(debounceTime(25))
            .subscribe((config) => {
                this.initCharts();
            });

            Chart.register(...registerables, ChartDataLabels);
    }

    ngOnInit() {
        this.initCharts();

        this.cursosimpservice.getCursosImpartidosTop5Mes().subscribe(data => {
            const labels = data.map(item => item.curso_Descripcion);
            const values = data.map(item => item.vecesImpartido);
            this.cursosTop5Mes = {
                labels: labels,
                datasets: [
                    {
                        data: values,
                        backgroundColor: [
                            '#FF6384',
                            '#36A2EB',
                            '#FFCE56',
                            '#4BC0C0',
                            '#9966FF'
                        ],
                        hoverBackgroundColor: [
                            '#FF6384',
                            '#36A2EB',
                            '#FFCE56',
                            '#4BC0C0',
                            '#9966FF'
                        ]
                    }
                ]
            };
        }, error => {
            console.error('Error fetching top 5 courses of the month', error);
        });



        this.cursosimpservice.getCursosImpartidosCategorias().subscribe(data => {
            const labels = data.map(item => item.cate_Descripcion);
            const values = data.map(item => item.vecesImpartido);
            this.cursosCategorias = {
                labels: labels,
                datasets: [
                    {
                        label: 'Cursos Impartidos por Categorías',
                        backgroundColor: [
                            '#66BB6A',
                            '#FFA726',
                            '#42A5F5',
                            '#AB47BC',
                            '#FF7043'
                        ],
                        hoverBackgroundColor: [
                            '#81C784',
                            '#FFB74D',
                            '#64B5F6',
                            '#BA68C8',
                            '#FF8A65'
                        ],
                        data: values
                    }
                ]
            };
        }, error => {
            console.error('Error fetching course categories', error);
        });



        this.cursosimpservice.getEmpleadosMejorPagados().subscribe(data => {
            const labels = data.map(item => item.empl_Nombre);
            const values = data.map(item => item.empl_Total);
            this.empleadosMejorPagados = {
                labels: labels,
                datasets: [
                    {
                        label: 'Empleados Mejor Pagados',
                        backgroundColor: '#FFA726',
                        borderColor: '#FB8C00',
                        data: values
                    }
                ]
            };
        }, error => {
            console.error('Error fetching top paid employees', error);
        });


        this.cursosimpservice.getHorasImpartidasPorCategoria().subscribe(data => {
            const labels = data.map(item => item.cate_Descripcion);
            const values = data.map(item => item.horasTotales);
            this.horasPorCategoria = {
                labels: labels,
                datasets: [
                    {
                        label: 'Horas Impartidas por Categoría',
                        backgroundColor: '#AB47BC',
                        borderColor: '#8E24AA',
                        data: values
                    }
                ]
            };
        }, error => {
            console.error('Error fetching hours by category', error);
        });
    }

    initCharts() {
        const documentStyle = getComputedStyle(document.documentElement);
        const textColor = documentStyle.getPropertyValue('--text-color');
        const textColorSecondary = documentStyle.getPropertyValue('--text-color-secondary');
        const surfaceBorder = documentStyle.getPropertyValue('--surface-border');

        this.cursosimpservice.getCursoPorMesData().subscribe(data => {
            const months = data.map(item => new Date(item.year, item.month - 1).toLocaleString('default', { month: 'long' }));
            const courseCounts = data.map(item => item.totalCursos);

            this.barData = {
                labels: months,
                datasets: [
                    {
                        label: 'Cursos Totales',
                        backgroundColor: '#633394',
                        borderColor: '#1E88E5',
                        data: courseCounts
                    }
                ]
            };

            this.lineOptions = {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true,
                        ticks: {
                            precision: 0  // Omitir decimales
                        }
                    },
                    x: {

                    }
                },
                plugins: {
                    legend: {
                        display: true
                    }
                }
            };
        });

        this.barOptions = {
            plugins: {
                legend: {
                    labels: {
                        fontColor: textColor
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
                },
            }
        };

        this.pieData = {
            labels: ['A', 'B', 'C'],
            datasets: [
                {
                    data: [540, 325, 702],
                    backgroundColor: [
                        documentStyle.getPropertyValue('--indigo-500'),
                        documentStyle.getPropertyValue('--purple-500'),
                        documentStyle.getPropertyValue('--teal-500')
                    ],
                    hoverBackgroundColor: [
                        documentStyle.getPropertyValue('--indigo-400'),
                        documentStyle.getPropertyValue('--purple-400'),
                        documentStyle.getPropertyValue('--teal-400')
                    ]
                }]
        };

        this.pieOptions = {
            plugins: {
                legend: {
                    labels: {
                        usePointStyle: true,
                        color: textColor
                    }
                }
            }
        };


        this.polarData = {
            datasets: [{
                data: [
                    11,
                    16,
                    7,
                    3
                ],
                backgroundColor: [
                    documentStyle.getPropertyValue('--indigo-500'),
                    documentStyle.getPropertyValue('--purple-500'),
                    documentStyle.getPropertyValue('--teal-500'),
                    documentStyle.getPropertyValue('--orange-500')
                ],
                label: 'My dataset'
            }],
            labels: [
                'Indigo',
                'Purple',
                'Teal',
                'Orange'
            ]
        };

        this.polarOptions = {
            plugins: {
                legend: {
                    labels: {
                        color: textColor
                    }
                }
            },
            scales: {
                r: {
                    grid: {
                        color: surfaceBorder
                    }
                }
            }
        };

        this.radarData = {
            labels: ['Eating', 'Drinking', 'Sleeping', 'Designing', 'Coding', 'Cycling', 'Running'],
            datasets: [
                {
                    label: 'My First dataset',
                    borderColor: documentStyle.getPropertyValue('--indigo-400'),
                    pointBackgroundColor: documentStyle.getPropertyValue('--indigo-400'),
                    pointBorderColor: documentStyle.getPropertyValue('--indigo-400'),
                    pointHoverBackgroundColor: textColor,
                    pointHoverBorderColor: documentStyle.getPropertyValue('--indigo-400'),
                    data: [65, 59, 90, 81, 56, 55, 40]
                },
                {
                    label: 'My Second dataset',
                    borderColor: documentStyle.getPropertyValue('--purple-400'),
                    pointBackgroundColor: documentStyle.getPropertyValue('--purple-400'),
                    pointBorderColor: documentStyle.getPropertyValue('--purple-400'),
                    pointHoverBackgroundColor: textColor,
                    pointHoverBorderColor: documentStyle.getPropertyValue('--purple-400'),
                    data: [28, 48, 40, 19, 96, 27, 100]
                }
            ]
        };

        this.radarOptions = {
            plugins: {
                legend: {
                    labels: {
                        fontColor: textColor
                    }
                }
            },
            scales: {
                r: {
                    grid: {
                        color: textColorSecondary
                    }
                }
            }
        };
    }

    ngOnDestroy() {
        if (this.subscription) {
            this.subscription.unsubscribe();
        }
    }
}
