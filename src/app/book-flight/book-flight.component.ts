import { Component, OnInit } from '@angular/core';
import { AirlineService } from '../services/airline.service';

@Component({
  selector: 'app-book-flight',
  templateUrl: './book-flight.component.html',
  styleUrls: ['./book-flight.component.css']
})
export class BookFlightComponent implements OnInit {

  constructor(private userData:AirlineService) { }

  ngOnInit(): void {
  }

  bookFlight(data:any)
  {
    this.userData.bookFlight(data);
  }

}
