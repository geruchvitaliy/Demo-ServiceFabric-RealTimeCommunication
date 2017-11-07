import { Component, OnInit, OnDestroy, ChangeDetectionStrategy, ChangeDetectorRef, NgZone, ViewChild } from '@angular/core'
import { IDeviceId, IDeviceStatus, DeviceStatusEnum } from 'models'
import { SignalRService, DevicesService, ISignalRSession } from 'services'
import { BingMapDirective, IBingMapPushpin, IBingMapInfobox, IBingMapCell, IMarkerSelectedEventArgs, ICellSelectedEventArgs } from 'directives'
import { Subscription } from "rxjs/Subscription"

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class DashboardComponent implements OnInit, OnDestroy {
    private subscription: Subscription;
    private signalRSession: ISignalRSession;
    private loading: boolean = true;
    private loadPageNumber: any;
    private loadTempData: IDeviceStatus[] = [];
    private displaying: boolean;
    private displayTimer: any;
    private displayLeftListItemsCount: number = 100;

    @ViewChild(BingMapDirective) bingMapDirective: BingMapDirective;
    dataToDisplayOnView: IDeviceStatus[] = [];
    dataToDisplayOnMap: IDeviceStatus[] = [];
    cellData: any;

    constructor(private readonly changeDetectorRef: ChangeDetectorRef,
        private readonly zone: NgZone,
        private readonly signalRService: SignalRService,
        private readonly devicesService: DevicesService)
    { }

    private onMapLoaded() {
        this.loadDevicesAndStatuses();
    }

    private loadDevicesAndStatuses() {
        this.devicesService
            .getDevicesCount()
            .then(count => {
                this.loadPageNumber = 0;

                this.onLoadDevicesAndStatuses(count)
                    .then(statuses => {
                        this.zone.run(() => {
                            this.dataToDisplayOnView = statuses.splice(0, this.displayLeftListItemsCount);
                        });
                        this.changeDetectorRef.markForCheck();
                    });
            });
    }

    private onLoadDevicesAndStatuses(count: number): Promise<IDeviceStatus[]> {
        const pageSize = 50000;

        return this.devicesService
            .getDevicesAndStatuses(this.loadPageNumber, pageSize)
            .then(statuses => {
                this.loadTempData = this.loadTempData.concat(statuses);

                this.receiveDevicesAndStatuses(this.loadTempData, null, true);
                while (this.dataToDisplayOnMap.length)
                    this.displayDevicesAndStatuses();

                if (this.loadTempData.length >= count) {
                    this.loadTempData = [];
                    this.loading = false;

                    this.displayTimer = setInterval(() => this.displayDevicesAndStatuses(), 100);
                }
                else {
                    this.loadPageNumber++;
                    this.onLoadDevicesAndStatuses(count);
                }

                return statuses;
            });
    }

    private displayDevicesAndStatuses() {
        if (this.displaying || !this.dataToDisplayOnMap.length)
            return;

        this.displaying = true;

        const takeCount = 10000;
        let group = this.dataToDisplayOnMap.splice(0, takeCount);

        group.forEach(status => {
            let details: IBingMapPushpin = {
                color: status.status === DeviceStatusEnum.Ok ? 'Green' :
                    status.status === DeviceStatusEnum.Warning ? 'Orange' : 'Red'
            };
            this.bingMapDirective.addMarker(status.lastLocation, status, details);
        });

        console.log(`Updated ${group.length} locations. Pending: ${this.dataToDisplayOnMap.length}`);
        group = null;

        let signalRSessionEnded = this.signalRSession ? this.signalRSession.sentObjects >= this.signalRSession.totalObjects : true;
        if (!this.dataToDisplayOnMap.length && signalRSessionEnded) {
            let details = <IBingMapCell>{
                aggregationProperty: 'lastCommunicationElapsedTime',
                colorCallback: this.getCellColor,
            };
            this.bingMapDirective.displayMap(details);
            console.log(`Displayed all locations`);
        }

        this.displaying = false;
    }

    private receiveDevicesAndStatuses(statuses: IDeviceStatus[], session?: ISignalRSession, clear: boolean = false) {
        if (!statuses || !statuses.length)
            return;

        this.signalRSession = session;
        this.dataToDisplayOnMap = clear ? [].concat(statuses) : this.dataToDisplayOnMap.concat(statuses);
        console.log(`Received ${statuses.length} locations`);
    }

    private getCellColor(bin, min, max) {
        if (bin.metrics.average < 720)
            return 'rgba(0,128,0,0.3)';
        else if (bin.metrics.average >= 720 && bin.metrics.average < 1440)
            return 'rgba(255,165,0,0.3)';
        else
            return 'rgba(255,0,0,0.3)';
    }

    private onMarkerSelected($event: IMarkerSelectedEventArgs) {
        let status = <IDeviceStatus>$event.metadata;
        this.devicesService
            .getDeviceProfile(status.deviceId)
            .then(res => {
                let statusString = status.status === 2 ? 'Ok' : status.status === 1 ? 'Warning' : 'Error';
                let details: IBingMapInfobox = {
                    title: res.name,
                    description: `Device Id: ${status.deviceId.id};<br/> Status: ${statusString};<br/> Last Communication: ${status.lastCommunicationDate};`
                };
                this.bingMapDirective.displayInfobox(status.lastLocation, details);
            });
    }

    private getCellValues(e: ICellSelectedEventArgs) {
        if (!e)
            return null;

        let minValue = Math.min.apply(null, e.metadata.map(x => (<IDeviceStatus>x).lastCommunicationElapsedTime));
        let maxValue = Math.max.apply(null, e.metadata.map(x => (<IDeviceStatus>x).lastCommunicationElapsedTime));

        return `Average: ${e.average}; Min: ${minValue}; Max: ${maxValue}; Devices Count: ${e.count}`;
    }

    private onCellSelected($event: ICellSelectedEventArgs) {
        if (!$event)
            return;

        alert(`In minutes. ${this.getCellValues($event)}`);
    }

    private onCellOver($event: ICellSelectedEventArgs) {
        this.cellData = this.getCellValues($event);
    }

    ngOnInit() {
        this.subscription = this.signalRService
            .subscribeOnDevicesUpdates()
            .subscribe(message => {
                if (!this.loading)
                    this.receiveDevicesAndStatuses(message.data, message.session);
            });
    }

    ngOnDestroy() {
        if (this.subscription) {
            this.subscription.unsubscribe();
            this.subscription = null;
        }

        if (this.displayTimer) {
            clearInterval(this.displayTimer);
            this.displayTimer = null;
        }
    }
}