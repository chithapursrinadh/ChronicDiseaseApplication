import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HealthMetric } from '../models/health-metric.model';

@Injectable({
  providedIn: 'root'
})
export class HealthMetricService {
  private apiUrl = 'http://localhost:5190/api/HealthMetric';

  constructor(private http: HttpClient) { }

  getMetrics(): Observable<HealthMetric[]> {
    return this.http.get<HealthMetric[]>(this.apiUrl);
  }

  addMetric(metric: HealthMetric): Observable<HealthMetric> {
    return this.http.post<HealthMetric>(this.apiUrl, metric);
  }
}
