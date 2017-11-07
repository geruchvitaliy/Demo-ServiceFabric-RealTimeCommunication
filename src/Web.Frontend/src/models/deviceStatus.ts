import { IDeviceId, ILocation } from 'models'

export interface IDeviceStatus {
    deviceId: IDeviceId;
    lastLocation: ILocation;
    lastCommunicationElapsedTime: number;
    lastCommunicationDate: string;
    status: DeviceStatusEnum;
}

export enum DeviceStatusEnum {
    Error,
    Warning,
    Ok
}