import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MetricsService } from '../../services/metrics.service';

@Component({
  selector: 'app-metrics',
  templateUrl: './metrics.component.html',
  styleUrls: ['./metrics.component.css']
})
export class MetricsComponent {
  metricForm: FormGroup;

  constructor(private fb: FormBuilder, private metricsService: MetricsService) {
    this.metricForm = this.fb.group({
      metricType: ['', Validators.required],
      value: ['', Validators.required]
    });
  }

  submitMetric() {
    if (this.metricForm.valid) {
      const newMetric = {
        patientId: 1, // Replace with actual logged-in patient ID
        metricType: this.metricForm.value.metricType,
        value: this.metricForm.value.value,
        recordedAt: new Date()
      };

      this.metricsService.submitMetric(newMetric).subscribe({
        next: () => alert('Metric submitted successfully!'),
        error: err => console.error('Error submitting metric', err)
      });
    }
  }
}
