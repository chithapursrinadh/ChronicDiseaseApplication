import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { MetricsComponent } from './Components/metrics/metrics.component';
import { ProviderDashboardComponent } from './Components/provider-dashboard/provider-dashboard.component';
import { HealthMetricComponent } from './Components/health-metrics/health-metrics.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'submit-metric', component: MetricsComponent },
  { path: 'provider-dashboard', component: ProviderDashboardComponent },
  { path: 'health-metrics', component: HealthMetricComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
