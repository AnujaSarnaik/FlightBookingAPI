import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AirlineService {

  
constructor(private http: HttpClient) {

}

  httpOption = {
    headers: new HttpHeaders({
    'Content-Type': 'application/json',
    })
    };

    saveFlight(data: any) {
      console.log("result",data);
      var data1=
      {
        "FlightNumber" : data.FlightNumber,
        //"FlightNumber" : "f115025",
        "Airline":data.Airline,
        "FromPlace" : data.FromPlace,
        "ToPlace": data.ToPlace,
        "ScheduledDays": data.ScheduledDays,
        "InstrumentUsed": data.InstrumentUsed,
        "BusinessSeats": data.BusinessSeats,
        "NonBusinessSeats" :data.NonBusinessSeats,
        "TicketCost" : data.TicketCost,
        "Rows" : data.Rows,
        "Meal" : data.Meal,
        "Status" : data.Status,
        "Date" : data.Date
        }
           
        return this.http.post("http://localhost:9015/api/Airlines/AddFlight", data1, this.httpOption).subscribe((data1) => {
          console.warn("result", data);
          })
      }

      getAirline():Observable<any> {
        return this.http.get("http://localhost:9015/api/Airlines/GetFlights",this.httpOption).pipe();
        
        }
      
        removeAirline(data:any) {
          
          return this.http.delete("http://localhost:9015/api/Airlines/DeleteFlight/"+data,this.httpOption).subscribe((data) => {
            console.warn("result", data);
        })
          
        }

        bookFlight(data: any) {
          console.log("result",data);
          var data1=
          {
            "FlightNumber" : data.FlightNumber,
            "EmailId":data.EmailId,
            "Meal":data.Meal,
            "NoOfSeats" : data.NoOfSeats,
            "SeatNo": data.SeatNo
            }
               
            return this.http.post("http://localhost:9015/api/Booking/bookFlight", data1, this.httpOption).subscribe((data1) => {
              
              })
          }
      
}
