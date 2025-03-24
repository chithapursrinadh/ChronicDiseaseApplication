import { Component, OnInit } from '@angular/core';
import { HealthMetricService } from '../../services/health-metric.service';
import { HealthMetric } from '../../models/health-metric.model';

@Component({
  selector: 'app-health-metric',
  templateUrl: './health-metric.component.html',
  styleUrls: ['./health-metric.component.css']
})
export class HealthMetricComponent implements OnInit {
  metrics: HealthMetric[] = [];
  errorMessage: string = '';

  constructor(private healthMetricService: HealthMetricService) { }

  ngOnInit(): void {
    this.loadMetrics();
  }

  loadMetrics(): void {
    this.healthMetricService.getMetrics().subscribe({
      next: (data) => this.metrics = data,
      error: (err) => this.errorMessage = 'Error loading health metrics'
    });
  }
}
