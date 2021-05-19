import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-clock',
  templateUrl: './clock.component.html',
  styleUrls: ['./clock.component.css']
})
export class ClockComponent implements OnInit {

  backendResponse: string;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get("https://localhost:44333/" + "account/" + "/getUser").subscribe()
  }

  sendRequestToBackend() {
    this.http.get("https://localhost:44333/" + "clock" + "/getMessage").subscribe(response => { this.backendResponse = response.toString(); },
      error => { this.backendResponse = error; });

  }

}
