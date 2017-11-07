import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable'
import { IDeviceId, IDeviceStatus } from 'models'
import { environment } from 'environments/environment'

@Injectable()
export class SignalRService {
    private connection: SignalR.Hub.Connection;
    private devicesProxy: SignalR.Hub.Proxy;
    private devicesData: Observable<ISignalRMessage<IDeviceStatus[]>>;

    constructor() {
        this.connection = $.hubConnection();

        this.startDevicesProxy();

        this.connection.stateChanged(state => {
            switch (state.newState) {
                case $.signalR.connectionState.connecting:
                    console.log("SignalR hub connecting");
                    break;
                case $.signalR.connectionState.connected:
                    console.log("SignalR hub connected");
                    break;
                case $.signalR.connectionState.reconnecting:
                    console.log("SignalR hub reconnecting");
                    break;
                case $.signalR.connectionState.disconnected:
                    console.log("SignalR hub disconnected");
                    break;
            }
        });

        this.connection.error(error => {
            console.log("SignalR hub error:");
            console.log(error);
        });

        this.connection.url = `${environment.signalRServiceAddress}signalr`;
        this.connection.start();
    }

    private startDevicesProxy() {
        this.devicesProxy = this.connection.createHubProxy('DevicesHub');

        this.devicesData = new Observable(observer => {
            this.devicesProxy.on("statusesReceived", (statuses: IDeviceStatus[], session: ISignalRSession) => {
                let message = <ISignalRMessage<IDeviceStatus[]>>{ data: statuses, session };
                observer.next(message);
            });
        });
    }

    subscribeOnDevicesUpdates(): Observable<ISignalRMessage<IDeviceStatus[]>> {
        return this.devicesData;
    }
}

export interface ISignalRMessage<T> {
    data: T;
    session: ISignalRSession;
}

export interface ISignalRSession {
    sentObjects: number;
    totalObjects: number;
}