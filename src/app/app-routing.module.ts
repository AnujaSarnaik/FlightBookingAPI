import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddAirlineComponent } from './add-airline/add-airline.component';
import { GetAirlinesComponent } from './get-airlines/get-airlines.component';
import { BookFlightComponent } from './book-flight/book-flight.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {
    path:'AddFlight',
    component:AddAirlineComponent
  },
  {
    path:'showFlights',
    component:GetAirlinesComponent
  },
  {
    path:'bookFlights',
    component:BookFlightComponent
  },
  {
    path:'login',
    component:LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
