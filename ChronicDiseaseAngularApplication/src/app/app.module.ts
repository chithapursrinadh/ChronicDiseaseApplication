import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { MetricsComponent } from './Components/metrics/metrics.component';
import { ProviderDashboardComponent } from './Components/provider-dashboard/provider-dashboard.component';
import { HealthMetricComponent } from './Components/health-metrics/health-metrics.component';

@NgModule({
  declarations: [AppComponent, LoginComponent, RegisterComponent, MetricsComponent, ProviderDashboardComponent, HealthMetricComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, ReactiveFormsModule],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
