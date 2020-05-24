import { HttpClient } from '@angular/common/http';
import { Component, OnInit, } from '@angular/core';
import { SignalRHubService } from './_shared/services/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {

  constructor(public signalRService: SignalRHubService, private http: HttpClient) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addTransferChartDataListener();
  }
}
