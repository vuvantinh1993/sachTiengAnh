import { Injectable, EventEmitter } from '@angular/core';
import { environment } from 'src/environments/environment';
import * as signalR from '@aspnet/signalr';
import { ChartModel } from '../services/chartModel.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRHubService {

  public data: ChartModel[];
  private hubConnection: signalR.HubConnection;

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/chart')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection hub started ddax connet'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addTransferChartDataListener = () => {
    this.hubConnection.on('transferchartdata', (message) => {
      console.log('log o dy', message);
    });
  }

  constructor(
  ) {

    // const connection = new signalR.HubConnectionBuilder()
    //   .configureLogging(signalR.LogLevel.Information)
    //   .withUrl(environment.apiUrl + '/signalRHub')
    //   .build();

    // connection.start().then(() => {
    //   console.log('Connected!');
    // }).catch((err) => {
    //   return console.error(err.toString());
    // });

    // console.log('oke2');

    // connection.on('SendAsync', (type: string, payload: string) => {
    //   console.log(type, payload);

    // });
  }
}
