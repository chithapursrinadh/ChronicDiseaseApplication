export interface HealthMetric {
  id?: number;
  patientId: number;
  metricType: string;  
  value: string;       
  recordedAt: Date;
}
