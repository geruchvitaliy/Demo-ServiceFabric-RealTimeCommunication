import { Directive, EventEmitter, ElementRef, AfterContentInit } from '@angular/core'
import { ILocation } from "models";

@Directive({
    selector: 'bing-map',
    outputs: ['mapLoaded', 'markerSelected', 'cellSelected', 'cellOver'],
    inputs: []
})
export class BingMapDirective implements AfterContentInit {
    private readonly retryCount = 5;
    private readonly clusterLayerGridSize = 100;
    private readonly dataBinningRadius = 25;
    private map: Microsoft.Maps.Map;
    private clusterLayer: Microsoft.Maps.ClusterLayer;
    private dataBinningLayer: Microsoft.Maps.DataBinningLayer;
    private markers: Microsoft.Maps.Pushpin[] = [];
    private infobox: Microsoft.Maps.Infobox;

    mapLoaded: EventEmitter<any>;
    markerSelected: EventEmitter<IMarkerSelectedEventArgs>;
    cellSelected: EventEmitter<ICellSelectedEventArgs>;
    cellOver: EventEmitter<ICellSelectedEventArgs>;

    constructor(private elementRef: ElementRef) {
        this.mapLoaded = new EventEmitter(true);
        this.markerSelected = new EventEmitter<IMarkerSelectedEventArgs>(true);
        this.cellSelected = new EventEmitter<ICellSelectedEventArgs>(true);
        this.cellOver = new EventEmitter<ICellSelectedEventArgs>(true);
    }

    private waitForScriptLoads(loadCount: number = 0) {
        setTimeout(() => {
            if (Microsoft)
                this.initializeMap();
            else {
                if (++loadCount < this.retryCount)
                    this.waitForScriptLoads(loadCount);
            }
        }, 500);
    }

    private initializeMap() {
        this.map = new Microsoft.Maps.Map(this.elementRef.nativeElement, {
            credentials: 'Amm1YyItq9vB1Bj839nYBNdTUsTNEcwZi3hgjwqrE6NjwoZ0MZMs4sc-c_Mxlht2',
            bounds: new Microsoft.Maps.LocationRect(new Microsoft.Maps.Location(0, 38), 8, 7) //Kenya
        });

        Microsoft.Maps.loadModule('Microsoft.Maps.DataBinning', () => {
            this.dataBinningLayer = new Microsoft.Maps.DataBinningLayer();
            Microsoft.Maps.Events.addHandler(this.dataBinningLayer, 'click', (e) => {
                this.cellSelected.emit(this.getCellSelectedEventArgs(e));
            });
            Microsoft.Maps.Events.addHandler(this.dataBinningLayer, 'mouseover', (e) => {
                e.primitive.setOptions(<Microsoft.Maps.IDataBinningOptions>{ strokeColor: 'blue' });
                this.cellOver.emit(this.getCellSelectedEventArgs(e));
            });
            Microsoft.Maps.Events.addHandler(this.dataBinningLayer, 'mouseout', (e) => {
                e.primitive.setOptions(<Microsoft.Maps.IDataBinningOptions>{ strokeColor: 'white' });
                this.cellSelected.emit(null);
                this.cellOver.emit(null);
            });

            this.map.layers.insert(this.dataBinningLayer);
        });

        Microsoft.Maps.loadModule('Microsoft.Maps.Clustering', () => {
            this.clusterLayer = new Microsoft.Maps.ClusterLayer([], { gridSize: this.clusterLayerGridSize });
            Microsoft.Maps.Events.addHandler(this.clusterLayer, 'click', (e) => {
                if (!e.primitive || !e.primitive.metadata)
                    return;

                let model = <IMarkerSelectedEventArgs>{
                    metadata: e.primitive.metadata
                };
                this.markerSelected.emit(model);
            });

            this.map.layers.insert(this.clusterLayer);
        });

        this.mapLoaded.emit();
    }

    private getCellSelectedEventArgs(e: Microsoft.Maps.IMouseEventArgs): ICellSelectedEventArgs {
        let primitive = <any>e.primitive;
        let info = <Microsoft.Maps.IDataBinInfo>primitive.dataBinInfo;

        return <ICellSelectedEventArgs>{
            metadata: info.containedPushpins.map(x => x.metadata),
            average: info.metrics.average,
            count: info.metrics.count,
            sum: info.metrics.sum
        };
    }

    ngAfterContentInit() {
        this.waitForScriptLoads();
    }

    addMarker(location: ILocation, metadata?: any, markerOptions?: IBingMapPushpin) {
        if (!location)
            return;

        let pushpin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(location.latitude, location.longitude));
        pushpin.setOptions(markerOptions);
        pushpin.metadata = metadata;

        this.markers.push(pushpin);
    }

    displayMap(cellOptions?: IBingMapCell) {
        if (this.dataBinningLayer && cellOptions) {
            this.dataBinningLayer.clear();

            let options = <Microsoft.Maps.IDataBinningOptions>{
                dataBinType: Microsoft.Maps.DataBinType.square,
                radius: this.dataBinningRadius,
                distanceUnits: Microsoft.Maps.SpatialMath.DistanceUnits.Miles,
                aggregationProperty: cellOptions.aggregationProperty,
                colorCallback: cellOptions.colorCallback,
                polygonOptions: { strokeColor: 'white' }
            };
            this.dataBinningLayer.setOptions(options);

            this.dataBinningLayer.setPushpins(this.markers);
        }

        if (this.clusterLayer) {
            this.clusterLayer.clear();

            this.clusterLayer.setPushpins(this.markers);
        }

        this.markers = [];
    }

    displayInfobox(location: ILocation, infoboxOptions: IBingMapInfobox) {
        if (!location || !infoboxOptions)
            return;

        let options = <Microsoft.Maps.IInfoboxOptions>infoboxOptions;
        options.visible = true;

        if (!this.infobox) {
            this.infobox = new Microsoft.Maps.Infobox(new Microsoft.Maps.Location(location.latitude, location.longitude));
            this.infobox.setOptions(options);
            this.infobox.setMap(this.map);
        }
        else {
            this.infobox.setLocation(new Microsoft.Maps.Location(location.latitude, location.longitude));
            this.infobox.setOptions(options);
        }
    }

    hideInfobox() {
        if (!this.infobox)
            return;

        let options = this.infobox.getOptions();
        options.visible = false;
    }
}

export interface ICellSelectedEventArgs {
    metadata: any[];
    average?: number;
    count?: number;
    sum?: number;
}

export interface IMarkerSelectedEventArgs {
    metadata: any;
}

export interface IBingMapCell {
    aggregationProperty: string;
    colorCallback: (binInfo: any, min: any, max: any) => string;
}

export interface IBingMapPushpin {
    color?: string;
    icon?: string;
    title?: string;
}

export interface IBingMapInfobox {
    description?: string;
    htmlContent?: string;
    maxHeight?: number;
    maxWidth?: number;
    showCloseButton?: boolean;
    showPointer?: boolean;
    title?: string;
}