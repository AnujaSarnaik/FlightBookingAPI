import { Component, OnInit } from '@angular/core';
import { AirlineService } from '../services/airline.service';

@Component({
  selector: 'app-get-airlines',
  templateUrl: './get-airlines.component.html',
  styleUrls: ['./get-airlines.component.css']
})
export class GetAirlinesComponent implements OnInit {
  airlines = new Array<any>();

  constructor(private airlineData:AirlineService) { }

  ngOnInit(): void {
    this.getAirline();
  }

  getAirline()
  {
    this.airlineData.getAirline().subscribe(Response=>{
      this.airlines = Response;
    });

  }
  removeAirline(data:any)
  {
      this.airlineData.removeAirline(data);
      window.location.reload();
  }

}
