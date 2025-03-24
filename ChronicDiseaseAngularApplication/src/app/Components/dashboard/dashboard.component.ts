import { Component, OnInit } from '@angular/core';
import { MetricsService } from '../../services/metrics.service';
import { HealthMetric } from '../../models/health-metric.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  metrics: HealthMetric[] = [];

  constructor(private metricsService: MetricsService) { }

  ngOnInit() {
    const patientId = 1;  
    this.metricsService.getMetricsForPatient(patientId).subscribe({
      next: data => this.metrics = data,
      error: err => console.error('Error fetching metrics', err)
    });
  }
}
