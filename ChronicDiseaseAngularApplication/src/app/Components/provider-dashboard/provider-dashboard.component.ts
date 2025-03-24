import { Component, OnInit } from '@angular/core';
import { MetricsService } from '../../services/metrics.service';
import { HealthMetric } from '../../models/health-metric.model';

@Component({
  selector: 'app-provider-dashboard',
  templateUrl: './provider-dashboard.component.html',
  styleUrls: ['./provider-dashboard.component.css']
})
export class ProviderDashboardComponent implements OnInit {
  patientMetrics: { patientName: string; metrics: HealthMetric[] }[] = [];

  constructor(private metricsService: MetricsService) { }

  ngOnInit() {
    const assignedPatientIds = [1, 2];  // Replace with actual provider's assigned patients
    assignedPatientIds.forEach(patientId => {
      this.metricsService.getMetricsForPatient(patientId).subscribe({
        next: metrics => {
          this.patientMetrics.push({ patientName: `Patient ${patientId}`, metrics });
        },
        error: err => console.error('Error fetching patient metrics', err)
      });
    });
  }
}
