import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HealthMetric } from '../models/health-metric.model';

@Injectable({ providedIn: 'root' })
export class MetricsService {
  private apiUrl = 'http://localhost:5190/api/metrics';

  constructor(private http: HttpClient) { }

  getMetricsForPatient(patientId: number): Observable<HealthMetric[]> {
    return this.http.get<HealthMetric[]>(`${this.apiUrl}/patient/${patientId}`);
  }

  submitMetric(metric: HealthMetric): Observable<any> {
    return this.http.post(`${this.apiUrl}`, metric);
  }
}
