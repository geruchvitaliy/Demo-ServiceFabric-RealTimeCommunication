import { Injectable } from '@angular/core'
import { Http } from "@angular/http";
import { IDeviceId, IDevice, IDeviceStatus } from 'models'
import { environment } from 'environments/environment'
import 'rxjs/add/operator/toPromise';

@Injectable()
export class DevicesService {

    constructor(private readonly http: Http)
    { }

    getDevicesCount(): Promise<number> {
        return this.http
            .get(`${environment.apiServiceAddress}api/device/count`)
            .toPromise()
            .then(x => x.json());
    }

    getDevicesAndStatuses(pageNumber: number, pageSize: number): Promise<IDeviceStatus[]> {
        return this.http
            .get(`${environment.apiServiceAddress}api/device/statuses?pageNumber=${pageNumber}&pageSize=${pageSize}`)
            .toPromise()
            .then(x => x.json());
    }

    getDeviceProfile(deviceId: IDeviceId): Promise<IDevice> {
        return this.http
            .get(`${environment.apiServiceAddress}api/device/${deviceId.id}/profile`)
            .toPromise()
            .then(x => x.json());
    }
}