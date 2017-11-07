webpackJsonp([1,5],{

/***/ 199:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return environment; });
// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `angular-cli.json`.
var environment = {
    production: false,
    apiServiceAddress: 'http://localhost:8105/',
    signalRServiceAddress: 'http://localhost:8104/'
};
//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/environment.js.map

/***/ }),

/***/ 303:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__bing_map_directive__ = __webpack_require__(467);
/* harmony namespace reexport (by used) */ __webpack_require__.d(__webpack_exports__, "a", function() { return __WEBPACK_IMPORTED_MODULE_0__bing_map_directive__["a"]; });

//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/index.js.map

/***/ }),

/***/ 304:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__signalr_service__ = __webpack_require__(474);
/* harmony namespace reexport (by used) */ __webpack_require__.d(__webpack_exports__, "a", function() { return __WEBPACK_IMPORTED_MODULE_0__signalr_service__["a"]; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__devices_service__ = __webpack_require__(473);
/* harmony namespace reexport (by used) */ __webpack_require__.d(__webpack_exports__, "b", function() { return __WEBPACK_IMPORTED_MODULE_1__devices_service__["a"]; });


//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/index.js.map

/***/ }),

/***/ 351:
/***/ (function(module, exports) {

function webpackEmptyContext(req) {
	throw new Error("Cannot find module '" + req + "'.");
}
webpackEmptyContext.keys = function() { return []; };
webpackEmptyContext.resolve = webpackEmptyContext;
module.exports = webpackEmptyContext;
webpackEmptyContext.id = 351;


/***/ }),

/***/ 352:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser_dynamic__ = __webpack_require__(443);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__(0);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__environments_environment__ = __webpack_require__(199);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__app_app_module__ = __webpack_require__(464);




if (__WEBPACK_IMPORTED_MODULE_2__environments_environment__["a" /* environment */].production) {
    __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["a" /* enableProdMode */])();
}
__webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_platform_browser_dynamic__["a" /* platformBrowserDynamic */])().bootstrapModule(__WEBPACK_IMPORTED_MODULE_3__app_app_module__["a" /* AppModule */]);
//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/main.js.map

/***/ }),

/***/ 463:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(0);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppComponent; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var AppComponent = (function () {
    function AppComponent() {
    }
    AppComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["V" /* Component */])({
            selector: 'app-root',
            template: __webpack_require__(633),
            styles: [__webpack_require__(631)]
        }), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
}());
//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/app.component.js.map

/***/ }),

/***/ 464:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser__ = __webpack_require__(191);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_core__ = __webpack_require__(0);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__(434);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_http__ = __webpack_require__(285);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_services__ = __webpack_require__(304);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_directives__ = __webpack_require__(303);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__app_component__ = __webpack_require__(463);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7_dashboard__ = __webpack_require__(466);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppModule; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1__angular_core__["b" /* NgModule */])({
            declarations: [
                __WEBPACK_IMPORTED_MODULE_6__app_component__["a" /* AppComponent */],
                __WEBPACK_IMPORTED_MODULE_7_dashboard__["a" /* DashboardComponent */],
                __WEBPACK_IMPORTED_MODULE_5_directives__["a" /* BingMapDirective */]
            ],
            imports: [
                __WEBPACK_IMPORTED_MODULE_0__angular_platform_browser__["a" /* BrowserModule */],
                __WEBPACK_IMPORTED_MODULE_2__angular_forms__["a" /* FormsModule */],
                __WEBPACK_IMPORTED_MODULE_3__angular_http__["a" /* HttpModule */]
            ],
            providers: [
                __WEBPACK_IMPORTED_MODULE_4_services__["a" /* SignalRService */],
                __WEBPACK_IMPORTED_MODULE_4_services__["b" /* DevicesService */]
            ],
            bootstrap: [
                __WEBPACK_IMPORTED_MODULE_6__app_component__["a" /* AppComponent */]
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], AppModule);
    return AppModule;
}());
//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/app.module.js.map

/***/ }),

/***/ 465:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(0);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_models__ = __webpack_require__(471);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_services__ = __webpack_require__(304);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_directives__ = __webpack_require__(303);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DashboardComponent; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var DashboardComponent = (function () {
    function DashboardComponent(changeDetectorRef, zone, signalRService, devicesService) {
        this.changeDetectorRef = changeDetectorRef;
        this.zone = zone;
        this.signalRService = signalRService;
        this.devicesService = devicesService;
        this.loading = true;
        this.loadTempData = [];
        this.displayLeftListItemsCount = 100;
        this.dataToDisplayOnView = [];
        this.dataToDisplayOnMap = [];
    }
    DashboardComponent.prototype.onMapLoaded = function () {
        this.loadDevicesAndStatuses();
    };
    DashboardComponent.prototype.loadDevicesAndStatuses = function () {
        var _this = this;
        this.devicesService
            .getDevicesCount()
            .then(function (count) {
            _this.loadPageNumber = 0;
            _this.onLoadDevicesAndStatuses(count)
                .then(function (statuses) {
                _this.zone.run(function () {
                    _this.dataToDisplayOnView = statuses.splice(0, _this.displayLeftListItemsCount);
                });
                _this.changeDetectorRef.markForCheck();
            });
        });
    };
    DashboardComponent.prototype.onLoadDevicesAndStatuses = function (count) {
        var _this = this;
        var pageSize = 50000;
        return this.devicesService
            .getDevicesAndStatuses(this.loadPageNumber, pageSize)
            .then(function (statuses) {
            _this.loadTempData = _this.loadTempData.concat(statuses);
            _this.receiveDevicesAndStatuses(_this.loadTempData, null, true);
            while (_this.dataToDisplayOnMap.length)
                _this.displayDevicesAndStatuses();
            if (_this.loadTempData.length >= count) {
                _this.loadTempData = [];
                _this.loading = false;
                _this.displayTimer = setInterval(function () { return _this.displayDevicesAndStatuses(); }, 100);
            }
            else {
                _this.loadPageNumber++;
                _this.onLoadDevicesAndStatuses(count);
            }
            return statuses;
        });
    };
    DashboardComponent.prototype.displayDevicesAndStatuses = function () {
        var _this = this;
        if (this.displaying || !this.dataToDisplayOnMap.length)
            return;
        this.displaying = true;
        var takeCount = 10000;
        var group = this.dataToDisplayOnMap.splice(0, takeCount);
        group.forEach(function (status) {
            var details = {
                color: status.status === __WEBPACK_IMPORTED_MODULE_1_models__["DeviceStatusEnum"].Ok ? 'Green' :
                    status.status === __WEBPACK_IMPORTED_MODULE_1_models__["DeviceStatusEnum"].Warning ? 'Orange' : 'Red'
            };
            _this.bingMapDirective.addMarker(status.lastLocation, status, details);
        });
        console.log("Updated " + group.length + " locations. Pending: " + this.dataToDisplayOnMap.length);
        group = null;
        var signalRSessionEnded = this.signalRSession ? this.signalRSession.sentObjects >= this.signalRSession.totalObjects : true;
        if (!this.dataToDisplayOnMap.length && signalRSessionEnded) {
            var details = {
                aggregationProperty: 'lastCommunicationElapsedTime',
                colorCallback: this.getCellColor,
            };
            this.bingMapDirective.displayMap(details);
            console.log("Displayed all locations");
        }
        this.displaying = false;
    };
    DashboardComponent.prototype.receiveDevicesAndStatuses = function (statuses, session, clear) {
        if (clear === void 0) { clear = false; }
        if (!statuses || !statuses.length)
            return;
        this.signalRSession = session;
        this.dataToDisplayOnMap = clear ? [].concat(statuses) : this.dataToDisplayOnMap.concat(statuses);
        console.log("Received " + statuses.length + " locations");
    };
    DashboardComponent.prototype.getCellColor = function (bin, min, max) {
        if (bin.metrics.average < 720)
            return 'rgba(0,128,0,0.3)';
        else if (bin.metrics.average >= 720 && bin.metrics.average < 1440)
            return 'rgba(255,165,0,0.3)';
        else
            return 'rgba(255,0,0,0.3)';
    };
    DashboardComponent.prototype.onMarkerSelected = function ($event) {
        var _this = this;
        var status = $event.metadata;
        this.devicesService
            .getDeviceProfile(status.deviceId)
            .then(function (res) {
            var statusString = status.status === 2 ? 'Ok' : status.status === 1 ? 'Warning' : 'Error';
            var details = {
                title: res.name,
                description: "Device Id: " + status.deviceId.id + ";<br/> Status: " + statusString + ";<br/> Last Communication: " + status.lastCommunicationDate + ";"
            };
            _this.bingMapDirective.displayInfobox(status.lastLocation, details);
        });
    };
    DashboardComponent.prototype.getCellValues = function (e) {
        if (!e)
            return null;
        var minValue = Math.min.apply(null, e.metadata.map(function (x) { return x.lastCommunicationElapsedTime; }));
        var maxValue = Math.max.apply(null, e.metadata.map(function (x) { return x.lastCommunicationElapsedTime; }));
        return "Average: " + e.average + "; Min: " + minValue + "; Max: " + maxValue + "; Devices Count: " + e.count;
    };
    DashboardComponent.prototype.onCellSelected = function ($event) {
        if (!$event)
            return;
        alert("In minutes. " + this.getCellValues($event));
    };
    DashboardComponent.prototype.onCellOver = function ($event) {
        this.cellData = this.getCellValues($event);
    };
    DashboardComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.subscription = this.signalRService
            .subscribeOnDevicesUpdates()
            .subscribe(function (message) {
            if (!_this.loading)
                _this.receiveDevicesAndStatuses(message.data, message.session);
        });
    };
    DashboardComponent.prototype.ngOnDestroy = function () {
        if (this.subscription) {
            this.subscription.unsubscribe();
            this.subscription = null;
        }
        if (this.displayTimer) {
            clearInterval(this.displayTimer);
            this.displayTimer = null;
        }
    };
    __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["U" /* ViewChild */])(__WEBPACK_IMPORTED_MODULE_3_directives__["a" /* BingMapDirective */]), 
        __metadata('design:type', (typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_3_directives__["a" /* BingMapDirective */] !== 'undefined' && __WEBPACK_IMPORTED_MODULE_3_directives__["a" /* BingMapDirective */]) === 'function' && _a) || Object)
    ], DashboardComponent.prototype, "bingMapDirective", void 0);
    DashboardComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["V" /* Component */])({
            selector: 'dashboard',
            template: __webpack_require__(634),
            changeDetection: __WEBPACK_IMPORTED_MODULE_0__angular_core__["W" /* ChangeDetectionStrategy */].OnPush
        }), 
        __metadata('design:paramtypes', [(typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_0__angular_core__["t" /* ChangeDetectorRef */] !== 'undefined' && __WEBPACK_IMPORTED_MODULE_0__angular_core__["t" /* ChangeDetectorRef */]) === 'function' && _b) || Object, (typeof (_c = typeof __WEBPACK_IMPORTED_MODULE_0__angular_core__["I" /* NgZone */] !== 'undefined' && __WEBPACK_IMPORTED_MODULE_0__angular_core__["I" /* NgZone */]) === 'function' && _c) || Object, (typeof (_d = typeof __WEBPACK_IMPORTED_MODULE_2_services__["a" /* SignalRService */] !== 'undefined' && __WEBPACK_IMPORTED_MODULE_2_services__["a" /* SignalRService */]) === 'function' && _d) || Object, (typeof (_e = typeof __WEBPACK_IMPORTED_MODULE_2_services__["b" /* DevicesService */] !== 'undefined' && __WEBPACK_IMPORTED_MODULE_2_services__["b" /* DevicesService */]) === 'function' && _e) || Object])
    ], DashboardComponent);
    return DashboardComponent;
    var _a, _b, _c, _d, _e;
}());
//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/dashboard.component.js.map

/***/ }),

/***/ 466:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__dashboard_component__ = __webpack_require__(465);
/* harmony namespace reexport (by used) */ __webpack_require__.d(__webpack_exports__, "a", function() { return __WEBPACK_IMPORTED_MODULE_0__dashboard_component__["a"]; });

//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/index.js.map

/***/ }),

/***/ 467:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(0);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return BingMapDirective; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var BingMapDirective = (function () {
    function BingMapDirective(elementRef) {
        this.elementRef = elementRef;
        this.retryCount = 5;
        this.clusterLayerGridSize = 100;
        this.dataBinningRadius = 25;
        this.markers = [];
        this.mapLoaded = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["G" /* EventEmitter */](true);
        this.markerSelected = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["G" /* EventEmitter */](true);
        this.cellSelected = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["G" /* EventEmitter */](true);
        this.cellOver = new __WEBPACK_IMPORTED_MODULE_0__angular_core__["G" /* EventEmitter */](true);
    }
    BingMapDirective.prototype.waitForScriptLoads = function (loadCount) {
        var _this = this;
        if (loadCount === void 0) { loadCount = 0; }
        setTimeout(function () {
            if (Microsoft)
                _this.initializeMap();
            else {
                if (++loadCount < _this.retryCount)
                    _this.waitForScriptLoads(loadCount);
            }
        }, 500);
    };
    BingMapDirective.prototype.initializeMap = function () {
        var _this = this;
        this.map = new Microsoft.Maps.Map(this.elementRef.nativeElement, {
            credentials: 'Amm1YyItq9vB1Bj839nYBNdTUsTNEcwZi3hgjwqrE6NjwoZ0MZMs4sc-c_Mxlht2',
            bounds: new Microsoft.Maps.LocationRect(new Microsoft.Maps.Location(0, 38), 8, 7) //Kenya
        });
        Microsoft.Maps.loadModule('Microsoft.Maps.DataBinning', function () {
            _this.dataBinningLayer = new Microsoft.Maps.DataBinningLayer();
            Microsoft.Maps.Events.addHandler(_this.dataBinningLayer, 'click', function (e) {
                _this.cellSelected.emit(_this.getCellSelectedEventArgs(e));
            });
            Microsoft.Maps.Events.addHandler(_this.dataBinningLayer, 'mouseover', function (e) {
                e.primitive.setOptions({ strokeColor: 'blue' });
                _this.cellOver.emit(_this.getCellSelectedEventArgs(e));
            });
            Microsoft.Maps.Events.addHandler(_this.dataBinningLayer, 'mouseout', function (e) {
                e.primitive.setOptions({ strokeColor: 'white' });
                _this.cellSelected.emit(null);
                _this.cellOver.emit(null);
            });
            _this.map.layers.insert(_this.dataBinningLayer);
        });
        Microsoft.Maps.loadModule('Microsoft.Maps.Clustering', function () {
            _this.clusterLayer = new Microsoft.Maps.ClusterLayer([], { gridSize: _this.clusterLayerGridSize });
            Microsoft.Maps.Events.addHandler(_this.clusterLayer, 'click', function (e) {
                if (!e.primitive || !e.primitive.metadata)
                    return;
                var model = {
                    metadata: e.primitive.metadata
                };
                _this.markerSelected.emit(model);
            });
            _this.map.layers.insert(_this.clusterLayer);
        });
        this.mapLoaded.emit();
    };
    BingMapDirective.prototype.getCellSelectedEventArgs = function (e) {
        var primitive = e.primitive;
        var info = primitive.dataBinInfo;
        return {
            metadata: info.containedPushpins.map(function (x) { return x.metadata; }),
            average: info.metrics.average,
            count: info.metrics.count,
            sum: info.metrics.sum
        };
    };
    BingMapDirective.prototype.ngAfterContentInit = function () {
        this.waitForScriptLoads();
    };
    BingMapDirective.prototype.addMarker = function (location, metadata, markerOptions) {
        if (!location)
            return;
        var pushpin = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(location.latitude, location.longitude));
        pushpin.setOptions(markerOptions);
        pushpin.metadata = metadata;
        this.markers.push(pushpin);
    };
    BingMapDirective.prototype.displayMap = function (cellOptions) {
        if (this.dataBinningLayer && cellOptions) {
            this.dataBinningLayer.clear();
            var options = {
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
    };
    BingMapDirective.prototype.displayInfobox = function (location, infoboxOptions) {
        if (!location || !infoboxOptions)
            return;
        var options = infoboxOptions;
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
    };
    BingMapDirective.prototype.hideInfobox = function () {
        if (!this.infobox)
            return;
        var options = this.infobox.getOptions();
        options.visible = false;
    };
    BingMapDirective = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["v" /* Directive */])({
            selector: 'bing-map',
            outputs: ['mapLoaded', 'markerSelected', 'cellSelected', 'cellOver'],
            inputs: []
        }), 
        __metadata('design:paramtypes', [(typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_0__angular_core__["C" /* ElementRef */] !== 'undefined' && __WEBPACK_IMPORTED_MODULE_0__angular_core__["C" /* ElementRef */]) === 'function' && _a) || Object])
    ], BingMapDirective);
    return BingMapDirective;
    var _a;
}());
//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/bing-map.directive.js.map

/***/ }),

/***/ 468:
/***/ (function(module, exports) {

//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/device.js.map

/***/ }),

/***/ 469:
/***/ (function(module, exports) {

//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/deviceId.js.map

/***/ }),

/***/ 470:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DeviceStatusEnum; });
var DeviceStatusEnum;
(function (DeviceStatusEnum) {
    DeviceStatusEnum[DeviceStatusEnum["Error"] = 0] = "Error";
    DeviceStatusEnum[DeviceStatusEnum["Warning"] = 1] = "Warning";
    DeviceStatusEnum[DeviceStatusEnum["Ok"] = 2] = "Ok";
})(DeviceStatusEnum || (DeviceStatusEnum = {}));
//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/deviceStatus.js.map

/***/ }),

/***/ 471:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__deviceId__ = __webpack_require__(469);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__deviceId___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0__deviceId__);
/* harmony namespace reexport (by used) */ if(__webpack_require__.o(__WEBPACK_IMPORTED_MODULE_0__deviceId__, "DeviceStatusEnum")) __webpack_require__.d(__webpack_exports__, "DeviceStatusEnum", function() { return __WEBPACK_IMPORTED_MODULE_0__deviceId__["DeviceStatusEnum"]; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__device__ = __webpack_require__(468);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__device___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1__device__);
/* harmony namespace reexport (by used) */ if(__webpack_require__.o(__WEBPACK_IMPORTED_MODULE_1__device__, "DeviceStatusEnum")) __webpack_require__.d(__webpack_exports__, "DeviceStatusEnum", function() { return __WEBPACK_IMPORTED_MODULE_1__device__["DeviceStatusEnum"]; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__location__ = __webpack_require__(472);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__location___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2__location__);
/* harmony namespace reexport (by used) */ if(__webpack_require__.o(__WEBPACK_IMPORTED_MODULE_2__location__, "DeviceStatusEnum")) __webpack_require__.d(__webpack_exports__, "DeviceStatusEnum", function() { return __WEBPACK_IMPORTED_MODULE_2__location__["DeviceStatusEnum"]; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__deviceStatus__ = __webpack_require__(470);
/* harmony namespace reexport (by used) */ __webpack_require__.d(__webpack_exports__, "DeviceStatusEnum", function() { return __WEBPACK_IMPORTED_MODULE_3__deviceStatus__["a"]; });




//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/index.js.map

/***/ }),

/***/ 472:
/***/ (function(module, exports) {

//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/location.js.map

/***/ }),

/***/ 473:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(0);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__(285);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_environments_environment__ = __webpack_require__(199);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_toPromise__ = __webpack_require__(636);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_toPromise___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_toPromise__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DevicesService; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var DevicesService = (function () {
    function DevicesService(http) {
        this.http = http;
    }
    DevicesService.prototype.getDevicesCount = function () {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_2_environments_environment__["a" /* environment */].apiServiceAddress + "api/device/count")
            .toPromise()
            .then(function (x) { return x.json(); });
    };
    DevicesService.prototype.getDevicesAndStatuses = function (pageNumber, pageSize) {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_2_environments_environment__["a" /* environment */].apiServiceAddress + "api/device/statuses?pageNumber=" + pageNumber + "&pageSize=" + pageSize)
            .toPromise()
            .then(function (x) { return x.json(); });
    };
    DevicesService.prototype.getDeviceProfile = function (deviceId) {
        return this.http
            .get(__WEBPACK_IMPORTED_MODULE_2_environments_environment__["a" /* environment */].apiServiceAddress + "api/device/" + deviceId.id + "/profile")
            .toPromise()
            .then(function (x) { return x.json(); });
    };
    DevicesService = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["c" /* Injectable */])(), 
        __metadata('design:paramtypes', [(typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */] !== 'undefined' && __WEBPACK_IMPORTED_MODULE_1__angular_http__["b" /* Http */]) === 'function' && _a) || Object])
    ], DevicesService);
    return DevicesService;
    var _a;
}());
//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/devices.service.js.map

/***/ }),

/***/ 474:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(0);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__ = __webpack_require__(53);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_environments_environment__ = __webpack_require__(199);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SignalRService; });
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var SignalRService = (function () {
    function SignalRService() {
        this.connection = $.hubConnection();
        this.startDevicesProxy();
        this.connection.stateChanged(function (state) {
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
        this.connection.error(function (error) {
            console.log("SignalR hub error:");
            console.log(error);
        });
        this.connection.url = __WEBPACK_IMPORTED_MODULE_2_environments_environment__["a" /* environment */].signalRServiceAddress + "signalr";
        this.connection.start();
    }
    SignalRService.prototype.startDevicesProxy = function () {
        var _this = this;
        this.devicesProxy = this.connection.createHubProxy('DevicesHub');
        this.devicesData = new __WEBPACK_IMPORTED_MODULE_1_rxjs_Observable__["Observable"](function (observer) {
            _this.devicesProxy.on("statusesReceived", function (statuses, session) {
                var message = { data: statuses, session: session };
                observer.next(message);
            });
        });
    };
    SignalRService.prototype.subscribeOnDevicesUpdates = function () {
        return this.devicesData;
    };
    SignalRService = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["c" /* Injectable */])(), 
        __metadata('design:paramtypes', [])
    ], SignalRService);
    return SignalRService;
}());
//# sourceMappingURL=C:/Users/Vitaliy/Source/Repos/M2M.RealTime/M2M.Realtime.SampleApp/Web.Frontend/src/signalr.service.js.map

/***/ }),

/***/ 631:
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ 633:
/***/ (function(module, exports) {

module.exports = "<dashboard></dashboard>\r\n"

/***/ }),

/***/ 634:
/***/ (function(module, exports) {

module.exports = "<div class=\"row\">\r\n    <div class=\"col-sm-4\">\r\n        <h4>Devices and Locations (left side list displays first {{displayLeftListItemsCount}} items):</h4>\r\n        <ul style=\"height: 700px; overflow:auto;\">\r\n            <li *ngFor=\"let item of dataToDisplayOnView\">\r\n                DeviceId: {{ item.deviceId.id }}; Latitude: {{ item.lastLocation.latitude }}; Longitude: {{ item.lastLocation.longitude }}\r\n            </li>\r\n        </ul>\r\n    </div>\r\n    <div class=\"col-sm-8\">\r\n        <h4>Cell values (in minutes): {{cellData}}</h4>\r\n        <bing-map (mapLoaded)=\"onMapLoaded()\"\r\n                  (markerSelected)=\"onMarkerSelected($event)\"\r\n                  (cellSelected)=\"onCellSelected($event)\"\r\n                  (cellOver)=\"onCellOver($event)\"\r\n                  style=\"height: 700px; position:absolute;\">\r\n        </bing-map>\r\n    </div>\r\n</div>"

/***/ }),

/***/ 650:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(352);


/***/ })

},[650]);
//# sourceMappingURL=main.bundle.map