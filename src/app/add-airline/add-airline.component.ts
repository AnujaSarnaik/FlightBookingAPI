import { Component, OnInit } from '@angular/core';
import{AirlineService} from '../services/airline.service'

@Component({
  selector: 'app-add-airline',
  templateUrl: './add-airline.component.html',
  styleUrls: ['./add-airline.component.css']
})
export class AddAirlineComponent implements OnInit {
  



  constructor(private userData:AirlineService) {
   }

  ngOnInit(): void {
  }
  //getAirline()
  addAirline(data:any)
  {
    this.userData.saveFlight(data);
    //this.userData.getAirline().subscribe();
  }
}
